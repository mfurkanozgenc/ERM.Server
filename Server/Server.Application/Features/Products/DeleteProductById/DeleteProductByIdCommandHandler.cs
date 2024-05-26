using GenericRepository;
using MediatR;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Products.DeleteProductById
{
    public sealed class DeleteProductByIdCommandHandler(
        IProductRepository productRepository,
        IInvoiceDetailRepository invoiceDetailRepository,
        IRecipeDetailRepository recipeDetailRepository,
        IOrderDetailRepository orderDetailRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByExpressionAsync(p => p.Id == request.Id);

            if(product is null)
            {
                return Result<string>.Failure("Ürün Bulunamadı");
            }

            bool invoiceControl = await invoiceDetailRepository.AnyAsync(p => p.ProductId == request.Id);
            if (invoiceControl)
            {
                return Result<string>.Failure("Ürün Faturalarda Kullanılmaktadır.Silinemez");
            }

            bool recipeControl = await recipeDetailRepository.AnyAsync(p => p.ProductId == request.Id);
            if (invoiceControl)
            {
                return Result<string>.Failure("Ürün Reçetelrde Kullanılmaktadır.Silinemez");
            }
            bool orderControl = await orderDetailRepository.AnyAsync(p => p.ProductId == request.Id);
            if (orderControl)
            {
                return Result<string>.Failure("Ürün Siparişlerde Kullanılmaktadır.Silinemez");
            }
            productRepository.Delete(product);
            await unitOfWork.SaveChangesAsync();

            return "Ürün Silme İşlemi Başarılı";
        }
    }
}
