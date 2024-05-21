using MediatR;
using Server.Domain.Dtos;
using TS.Result;

namespace Server.Application.Features.Orders.CreateOrder
{
    public sealed record CreateOrderCommand(
        Guid CustomerId,
        DateTime Date,
        DateTime DeliveryDate,
        List<OrderDetailDto> OrderDetails) : IRequest<Result<string>>;
}
