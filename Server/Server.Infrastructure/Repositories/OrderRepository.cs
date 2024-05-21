using GenericRepository;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories
{
    internal sealed class OrderRepository : Repository<Order, ApplicationDbContext>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
