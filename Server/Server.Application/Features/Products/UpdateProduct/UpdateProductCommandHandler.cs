using AutoMapper;
using GenericRepository;
using MediatR;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Server.Application.Features.Products.UpdateProduct
{
    public sealed class UpdateProductCommandHandler(
        IProductRepository productRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if(product is null)
            {
                return Result<string>.Failure("Ürün Bulunamadı");
            }

            if (product.Name != request.Name)
            {
                var isNameExsist = await productRepository.AnyAsync(d => d.Name == request.Name);

                if (isNameExsist)
                {
                    return Result<string>.Failure("Aynı Ürün İsmi Daha Önce Kayıt Edilmiştir");
                }
            }

            mapper.Map(request, product);
            await unitOfWork.SaveChangesAsync();

            return "Ürün Güncelleme İşlemi Başarılı";
        }
    }
}
