using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Recipes.GetByIdRecipteWithDetails
{
    internal sealed class GetRecipeByIdWithDetailsQueryHandler(
        IRecipeRepository recipeRepository) : IRequestHandler<GetRecipeByIdWithDetailsQuery, Result<Recipe>>
    {
        public async Task<Result<Recipe>> Handle(GetRecipeByIdWithDetailsQuery request, CancellationToken cancellationToken)
        {
            Recipe? recipe = await recipeRepository
                       .Where(r => r.Id == request.RecipeId)
                       .Include(d => d.Product)
                       .Include(d => d.Details!.OrderBy(p=>p.Product!.Name))
                       .ThenInclude(dt => dt.Product)
                       .FirstOrDefaultAsync();

            if(recipe is null)
            {
                return Result<Recipe>.Failure("Ürüne Ait Reçee Bulunamad");
            }

            return recipe;
        }
    }
}
