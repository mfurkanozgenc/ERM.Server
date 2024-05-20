using AutoMapper;
using GenericRepository;
using MediatR;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.RecipeDetails.CreateRecipeDetails
{
    internal sealed class CreateRecipeDetailsCommandHandler(
        IRecipeDetailRepository recipeDetailRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateRecipeDetailsCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateRecipeDetailsCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail? recipeDetail = await recipeDetailRepository
                                  .GetByExpressionWithTrackingAsync(rd => rd.RecipeId == request.RecipeId && 
                                  rd.ProductId == request.ProductId,cancellationToken);

            if(recipeDetail is not null)
            {
                recipeDetail.Quantity += request.Quantity;
            }
            else
            {
                recipeDetail = mapper.Map<RecipeDetail>(request);
                await recipeDetailRepository.AddAsync(recipeDetail);
            }

            await unitOfWork.SaveChangesAsync();
            return "Reçeteye Ekleme İşlemi Başarılı";
        }
    }
}
