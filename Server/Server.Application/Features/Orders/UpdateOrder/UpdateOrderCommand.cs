using MediatR;
using Server.Domain.Dtos;
using TS.Result;

namespace Server.Application.Features.Orders.UpdateOrder
{
    public sealed record UpdateOrderCommand(
        Guid Id,
        Guid CustomerId,
        DateOnly Date,
        DateOnly DeliveryDate,
        List<OrderDetailDto> OrderDetails) : IRequest<Result<string>>;
}
