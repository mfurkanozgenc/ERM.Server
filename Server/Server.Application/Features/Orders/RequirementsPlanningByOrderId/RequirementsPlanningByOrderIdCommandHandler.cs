using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Dtos;
using Server.Domain.Entities;
using Server.Domain.Enums;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Orders.RequirementsPlanningByOrderId
{
    public sealed class RequirementsPlanningByOrderIdCommandHandler(
        IOrderRepository orderRepository,
        IStockMovementRepository stockMovementRepository,
        IRecipeRepository recipeRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<RequirementsPlanningByOrderIdCommand, Result<RequirementsPlanningByOrderIdCommandResponse>>
    {
        public async Task<Result<RequirementsPlanningByOrderIdCommandResponse>> Handle(RequirementsPlanningByOrderIdCommand request, CancellationToken cancellationToken)
        {
            Order? order = await orderRepository
                .Where(o => o.Id == request.OrderId)
                .Include(d => d.OrderDetails!)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync();

            if (order is null)
            {
                return Result<RequirementsPlanningByOrderIdCommandResponse>.Failure("Sipariş Bulunamadı");
            }

            List<ProductDto> listOfProductsToBeProduced = new();
            List<ProductDto> requirementsPlanningProducts = new();
            if (order.OrderDetails is not null)
            {
                foreach (var detail in order.OrderDetails)
                {
                    var product = detail.Product;
                    List<StockMovement> movements = await stockMovementRepository
                        .Where(p => p.ProductId == product!.Id)
                        .ToListAsync(cancellationToken);

                    decimal stock = movements.Sum(p => p.NumberOfEntries) - movements.Sum(p => p.NumberOfOutputs);

                    if (stock < detail.Quantity)
                    {
                        ProductDto producedProduct = new()
                        {
                            ProductId = detail!.ProductId,
                            Name = product!.Name,
                            Quantity = detail.Quantity - stock
                        };

                        listOfProductsToBeProduced.Add(producedProduct);
                    }
                }

                foreach (var item in listOfProductsToBeProduced)
                {
                    Recipe? recipe = await recipeRepository
                        .Where(p => p.ProductId == item.ProductId)
                        .Include(p => p.Details!)
                        .ThenInclude(p => p.Product)
                        .FirstOrDefaultAsync(cancellationToken);

                    if (recipe is not null && recipe.Details is not null)
                    {
                        foreach (var detail in recipe.Details)
                        {
                            List<StockMovement> urunMovements = await stockMovementRepository
                                .Where(p => p.ProductId == detail!.ProductId)
                                .ToListAsync(cancellationToken);

                            decimal stock = urunMovements.Sum(p => p.NumberOfEntries) - urunMovements.Sum(p => p.NumberOfOutputs);

                            if (stock < detail.Quantity)
                            {
                                ProductDto producedProduct = new()
                                {
                                    ProductId = detail!.Id,
                                    Name = detail.Product!.Name,
                                    Quantity = detail.Quantity - stock
                                };

                                requirementsPlanningProducts.Add(producedProduct);
                            }
                        }
                    }
                }
            }
            requirementsPlanningProducts = requirementsPlanningProducts
                .GroupBy(g => g.ProductId)
                .Select(g => new ProductDto
                {
                    ProductId = g.Key,
                    Name = g.First().Name,
                    Quantity = g.Sum(item => item.Quantity)
                }).ToList();

            order.Status = OrderStatusEnum.RequirementsPlanWorked;
            orderRepository.Update(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new RequirementsPlanningByOrderIdCommandResponse(
               DateOnly.FromDateTime(DateTime.Now),
               order.OrderNumber + "Nolu Siparişin İhtiyaç PWlanlaması",
               requirementsPlanningProducts);
        }
    }
}
