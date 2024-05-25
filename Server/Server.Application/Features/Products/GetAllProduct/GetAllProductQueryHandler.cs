using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Products.GetAllProduct
{
    public sealed class GetAllProductQueryHandler(
        IProductRepository productRepository,
        IStockMovementRepository stockMovementRepository) : IRequestHandler<GetAllProductQuery, Result<List<GetAllProductQueryResponse>>>
    {
        public async Task<Result<List<GetAllProductQueryResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetAll().OrderBy(p => p.Name).ToListAsync();

            List<GetAllProductQueryResponse> responses = product.Select(s =>new GetAllProductQueryResponse
            {
                Id = s.Id,
                Name = s.Name,
                Type = s.Type
            }).ToList();

            foreach (var res in responses)
            {
                decimal stock = await stockMovementRepository
                    .Where(s => s.ProductId == res.Id)
                    .SumAsync(p => p.NumberOfEntries - p.NumberOfOutputs);

                res.Stock = stock;
            }
            return responses;
        }
    }
}
