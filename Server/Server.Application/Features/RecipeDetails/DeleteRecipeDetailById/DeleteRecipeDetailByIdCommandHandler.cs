using GenericRepository;
using MediatR;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.RecipeDetails.DeleteRecipeDetailById
{
    internal sealed class DeleteRecipeDetailByIdCommandHandler(
        IRecipeDetailRepository recipeDetailRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeDetailByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRecipeDetailByIdCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail? recipeDetail = await recipeDetailRepository.GetByExpressionAsync(rd => rd.Id == request.Id, cancellationToken);

            if(recipeDetail is  null)
            {
                return Result<string>.Failure("Reçete Detayı Bulunamadı");
            }

            recipeDetailRepository.Delete(recipeDetail);
            await unitOfWork.SaveChangesAsync();

            return "Reçete Detayı Silme Başarılı";
        }
    }
}
