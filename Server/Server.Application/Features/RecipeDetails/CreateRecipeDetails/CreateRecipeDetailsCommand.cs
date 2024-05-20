using MediatR;
using TS.Result;

namespace Server.Application.Features.RecipeDetails.CreateRecipeDetails
{
    public sealed record CreateRecipeDetailsCommand (
        Guid RecipeId,
        Guid ProductId,
        decimal Quantity) : IRequest<Result<string>>;
}
