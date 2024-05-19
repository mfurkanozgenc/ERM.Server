using MediatR;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Products.GetAllProduct
{
    public sealed record GetAllProductQuery () : IRequest<Result<List<Product>>>;
}
