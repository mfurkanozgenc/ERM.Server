using GenericRepository;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories
{
    internal sealed class OrderDetailRepository : Repository<OrderDetail, ApplicationDbContext>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
