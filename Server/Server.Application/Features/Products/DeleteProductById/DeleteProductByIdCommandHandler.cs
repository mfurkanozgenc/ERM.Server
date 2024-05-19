using GenericRepository;
using MediatR;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Products.DeleteProductById
{
    public sealed class DeleteProductByIdCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByExpressionAsync(p => p.Id == request.Id);

            if(product is null)
            {
                return Result<string>.Failure("Ürün Bulunamadı");
            }

            productRepository.Delete(product);
            await unitOfWork.SaveChangesAsync();

            return "Ürün Silme İşlemi Başarılı";
        }
    }
}
