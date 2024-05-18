using GenericRepository;
using MediatR;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Customers.DeleteCustomerById
{
    internal sealed class DeleteCustomerByIdHandler (
        ICustomerRepository  customerRepository,
        IUnitOfWork unitOfWork): IRequestHandler<DeleteCustomerByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetByExpressionAsync(c => c.Id == request.Id,cancellationToken);

            if(customer is null)
            {
                return Result<string>.Failure("Müşteri Bulunamadı");
            }

            customerRepository.Delete(customer);
            await unitOfWork.SaveChangesAsync();

            return "Müşteri Silme İşlemi Başarılı";
        }
    }
}
