using GenericRepository;
using MediatR;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Recipes.CreateRecipe
{
    public sealed class CreateRecipeCommandHandler(
        IRecipeRepository recipeRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateRecipeCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var isRecipeExsist = await recipeRepository.AnyAsync(r => r.ProductId == request.ProductId, cancellationToken);

            if (isRecipeExsist)
            {
                return Result<string>.Failure("Bu Ürüne Ait Reçete Daha Önce Oluşturulmuştur");
            }

            Recipe recipe = new()
            {
                ProductId = request.ProductId,
                Details = request.Details.Select(s =>
                new RecipeDetail()
                {
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()
            };

            await recipeRepository.AddAsync(recipe);
            await unitOfWork.SaveChangesAsync();

            return "Reçete Kayıdı Başarıyla Tamamlandı";
        }
    }
}
