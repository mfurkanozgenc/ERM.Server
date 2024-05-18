using AutoMapper;
using GenericRepository;
using MediatR;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Customers.CreateCustomer
{
    internal sealed class CreateCustomerCommandHandler(
        ICustomerRepository customerRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateCustomerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            bool isTaxNumberExsist = await customerRepository.AnyAsync(c => c.TaxNumber == request.TaxNumber, cancellationToken);

            if(isTaxNumberExsist)
            {
                return Result<string>.Failure("Vergi Numarası Daha Önce Kayıt Edilmiştir");
            }

            var customer = mapper.Map<Customer>(request);

            await customerRepository.AddAsync(customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Müşteri Kaydı Başarıyla Tamamlandı";
        }
    }
}
