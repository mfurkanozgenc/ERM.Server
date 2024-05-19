using GenericRepository;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories
{
    internal sealed class RecipeRepository : Repository<Recipe, ApplicationDbContext>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
