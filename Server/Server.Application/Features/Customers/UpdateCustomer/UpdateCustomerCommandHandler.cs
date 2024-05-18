using AutoMapper;
using GenericRepository;
using MediatR;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Customers.UpdateCustomer
{
    internal sealed class UpdateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCustomerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetByExpressionWithTrackingAsync(c => c.Id == request.Id, cancellationToken);

            if(customer is null)
            {
                return Result<string>.Failure("Müşteri Bulunamadı");
            }

            if(customer.TaxNumber != request.TaxNumber)
            {
                bool isTaxNumberExsist = await customerRepository.AnyAsync(c => c.TaxNumber == request.TaxNumber, cancellationToken);

                if (isTaxNumberExsist)
                {
                    return Result<string>.Failure("Vergi Numarası Daha Önce Kayıt Edilmiştir");
                }
            }

            mapper.Map(request,customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Müşteri Güncelleme Başarıyla Tamamlandı";
        }
    }
}
