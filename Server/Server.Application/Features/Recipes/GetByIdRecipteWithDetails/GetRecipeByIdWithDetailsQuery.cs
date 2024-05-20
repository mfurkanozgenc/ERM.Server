using MediatR;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Recipes.GetByIdRecipteWithDetails
{
    public sealed record GetRecipeByIdWithDetailsQuery(Guid RecipeId) : IRequest<Result<Recipe>>;
}
