using GenericRepository;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories
{
    internal sealed class ProductionRepository : Repository<Production, ApplicationDbContext>, IProductionRepository
    {
        public ProductionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
