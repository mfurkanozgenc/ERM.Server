using GenericRepository;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories
{
    internal sealed class RecipeDetailRepository : Repository<RecipeDetail, ApplicationDbContext>, IRecipeDetailRepository
    {
        public RecipeDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
