using MediatR;
using Server.Domain.Dtos;
using TS.Result;

namespace Server.Application.Features.Recipes.CreateRecipe
{
    public sealed record CreateRecipeCommand(
        Guid ProductId,
        List<RecipeDetailDTO> Details) : IRequest<Result<string>>;
}
