using GenericRepository;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    internal sealed class DepotRepository : Repository<Depot, ApplicationDbContext>, IDepotRepository
    {
        public DepotRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
