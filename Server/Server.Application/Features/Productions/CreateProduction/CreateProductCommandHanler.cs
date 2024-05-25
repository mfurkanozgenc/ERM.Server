using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Productions.CreateProduction
{
    internal sealed class CreateProductCommandHanler(
        IProductionRepository productionRepository,
        IStockMovementRepository stockMovementRepository,
        IRecipeRepository recipeRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateProductionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateProductionCommand request, CancellationToken cancellationToken)
        {
            Recipe? recipe = await recipeRepository
                .Where(p => p.ProductId == request.ProductId)
                .Include(p => p.Details!)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync();

            Production production = mapper.Map<Production>(request);
            List<StockMovement> newStockMovements = new();

            if (recipe is not null && recipe.Details is not null)
            {
                var details = recipe.Details;

                foreach (var item in details)
                {
                    List<StockMovement> stockMovements = await stockMovementRepository
                        .Where(p => p.ProductId == item.ProductId)
                        .ToListAsync(cancellationToken);

                    List<Guid> depotIds = stockMovements.GroupBy(d => d.DepotId).Select(d => d.Key).ToList();

                    decimal stock = stockMovements.Sum(p => p.NumberOfEntries) - stockMovements.Sum(p => p.NumberOfOutputs);

                    if (item.Quantity > stock)
                    {
                        return Result<string>.Failure(item.Product!.Name + " ürününden üretim için yeterli miktarda yok.Eksik Miktar : " + (item.Quantity - stock));
                    }

                    foreach (var depotId in depotIds)
                    {
                        if (item.Quantity <= 0) break;

                        decimal quantity = stockMovements.Where(d => d.DepotId == depotId).Sum(s => s.NumberOfEntries - s.NumberOfOutputs);

                        decimal totalPrice = stockMovements.Where(d => d.DepotId == depotId && d.NumberOfEntries > 0).Sum(s => s.Price * s.NumberOfEntries);

                        decimal totalEntriesQuantity = stockMovements.Where(d => d.DepotId == depotId && d.NumberOfEntries > 0).Sum(s => s.NumberOfEntries);

                        decimal price = totalPrice / totalEntriesQuantity;

                        StockMovement stockMovement = new()
                        {
                            ProductionId = production.Id,
                            DepotId = depotId,
                            Price = price,
                            ProductId = item.ProductId
                        };

                        if (item.Quantity <= quantity)
                        {
                            stockMovement.NumberOfOutputs = item.Quantity;
                        }
                        else
                        {
                            stockMovement.NumberOfOutputs = quantity;
                        }

                        item.Quantity -= quantity;

                        newStockMovements.Add(stockMovement);
                    }
                }
            }

            await stockMovementRepository.AddRangeAsync(newStockMovements);
            await productionRepository.AddAsync(production, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün Başarıyla Oluşturuldu";
        }
    }
}
