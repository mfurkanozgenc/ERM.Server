using MediatR;
using TS.Result;

namespace Server.Application.Features.Recipes.DeleteRecipeById
{
    public sealed record DeleteRecipeByIdCommand(Guid Id) : IRequest<Result<string>>;
}
