using MediatR;
using TS.Result;

namespace Server.Application.Features.Products.GetAllProduct
{
    public sealed record GetAllProductQuery() : IRequest<Result<List<GetAllProductQueryResponse>>>;

}
