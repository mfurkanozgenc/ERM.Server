using MediatR;
using TS.Result;

namespace Server.Application.Features.Products.DeleteProductById
{
    public sealed record DeleteProductByIdCommand (Guid Id) : IRequest<Result<string>>;
}
