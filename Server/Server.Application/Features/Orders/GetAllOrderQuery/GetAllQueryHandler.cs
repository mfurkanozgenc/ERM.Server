using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Orders.GetAllOrderQuery
{
    internal sealed class GetAllQueryHandler(
        IOrderRepository orderRepository) : IRequestHandler<GetAllOrderQuery, Result<List<Order>>>
    {
        public async Task<Result<List<Order>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            List<Order> orders = await orderRepository
                              .GetAll()
                             .Include(c => c.Customer)
                             .Include(o => o.OrderDetails!)
                             .ThenInclude(d => d.Product)
                             .OrderByDescending(o => o.Date)
                             .ToListAsync();

            return orders;
        }
    }
}
