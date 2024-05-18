using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Customers.GetAllCustomer
{
    internal sealed class GetAllCustomerQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetAllCustomerQuery, Result<List<Customer>>>
    {
        public async Task<Result<List<Customer>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customers = await customerRepository.GetAll().OrderBy(c => c.Name).ToListAsync();
            return customers;
        }
    }
}
    