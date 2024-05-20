using MediatR;
using TS.Result;

namespace Server.Application.Features.RecipeDetails.DeleteRecipeDetailById
{
    public sealed record DeleteRecipeDetailByIdCommand (Guid Id) : IRequest<Result<string>>;
}
