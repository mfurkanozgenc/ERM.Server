using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Products.GetAllProduct
{
    public sealed class GetAllProductQueryHandler(
        IProductRepository productRepository) : IRequestHandler<GetAllProductQuery, Result<List<Product>>>
    {
        public async Task<Result<List<Product>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetAll().OrderBy(p => p.Name).ToListAsync();

            return product;
        }
    }
}
