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

namespace Server.Application.Features.Products.CreateProduct
{
    public sealed class CreateProductCommandHandler(
        IProductRepository productRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isNameExsist = await productRepository.AnyAsync(p => p.Name == request.Name);

            if(isNameExsist)
            {
                return Result<string>.Failure("Ayn İsimli Ürün Daha Önce Kaydedilmiştir");
            }
            
            var product = mapper.Map<Product>(request);
            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return "Ürün Kaydı Başarıyla Gerçekleşti";
        }
    }
}
