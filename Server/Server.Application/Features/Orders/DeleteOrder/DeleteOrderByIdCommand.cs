using MediatR;
using TS.Result;

namespace Server.Application.Features.Orders.DeleteOrder
{
    public sealed record DeleteOrderByIdCommand (Guid OrderId) : IRequest<Result<string>>;
}
