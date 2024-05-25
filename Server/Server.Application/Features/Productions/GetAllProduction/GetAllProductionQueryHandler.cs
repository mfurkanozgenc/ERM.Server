using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Productions.GetAllProduction
{
    internal sealed class GetAllProductionQueryHandler(
        IProductionRepository productionRepository) : IRequestHandler<GetAllProductionQuery, Result<List<Production>>>
    {
        public async Task<Result<List<Production>>> Handle(GetAllProductionQuery request, CancellationToken cancellationToken)
        {
            List<Production> productions = await productionRepository
                .GetAll()
                .Include(p => p.Product)
                .Include(p => p.Depot)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync(cancellationToken);

            return productions;
        }
    }
}
