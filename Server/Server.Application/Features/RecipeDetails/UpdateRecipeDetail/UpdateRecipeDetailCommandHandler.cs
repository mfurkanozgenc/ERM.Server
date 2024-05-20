using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.RecipeDetails.UpdateRecipeDetail
{
    internal sealed class UpdateRecipeDetailCommandHandler(
        IRecipeDetailRepository recipeDetailRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateRecipeDetailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail? recipeDetail = await recipeDetailRepository.GetByExpressionWithTrackingAsync(rd => rd.Id == request.Id, cancellationToken);

            if(recipeDetail is null)
            {
                return Result<string>.Failure("Reçete Detayı Bulunamadı");
            }

            RecipeDetail? oldRecipeDetail = await recipeDetailRepository
                        .Where(rd => rd.Id != request.Id && rd.ProductId == request.ProductId &&
                         rd.RecipeId == recipeDetail.RecipeId).FirstOrDefaultAsync();

            if(oldRecipeDetail is not null)
            {
                recipeDetailRepository.Delete(recipeDetail);

                oldRecipeDetail.Quantity += request.Quantity;
                recipeDetailRepository.Update(oldRecipeDetail);
            }
            else
            {
                mapper.Map(request, recipeDetail);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçete Detayı Güncelleme Başarılı";
        }
    }
}
