using MediatR;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Orders.GetAllOrderQuery
{
    public sealed record GetAllOrderQuery() : IRequest<Result<List<Order>>>;
}
