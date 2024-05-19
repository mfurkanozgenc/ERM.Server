using MediatR;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Recipes.GetAllRecipe
{
    public sealed record GetAllRecipeQuery () : IRequest<Result<List<Recipe>>>;
}
