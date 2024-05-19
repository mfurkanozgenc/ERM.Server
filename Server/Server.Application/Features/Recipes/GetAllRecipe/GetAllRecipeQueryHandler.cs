using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Recipes.GetAllRecipe
{
    public sealed class GetAllRecipeQueryHandler(
        IRecipeRepository recipeRepository) : IRequestHandler<GetAllRecipeQuery, Result<List<Recipe>>>
    {
        public async Task<Result<List<Recipe>>> Handle(GetAllRecipeQuery request, CancellationToken cancellationToken)
        {
            var recipes = await recipeRepository
                .GetAll()
                .Include(r => r.Product)
                .OrderBy(r => r.Product!.Name)
                .ToListAsync();

            return recipes;
        }
    }
}
