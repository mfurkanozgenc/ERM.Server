using GenericRepository;
using MediatR;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Recipes.DeleteRecipeById
{
    public sealed class DeleeRecipeByIdCommandHandler(
        IRecipeRepository recipeRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
        {
            var recipe = await recipeRepository.GetByExpressionAsync(r => r.Id == request.Id, cancellationToken);

            if (recipe is null)
            {
                return Result<string>.Failure("Reçete Bulunamadı");
            }

            recipeRepository.Delete(recipe);
            await unitOfWork.SaveChangesAsync();

            return "Reçete Silme İşlemi Başarılı";
        }
    }
}
