using MediatR;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Customers.GetAllCustomer
{
    public sealed class GetAllCustomerQuery() : IRequest<Result<List<Customer>>>
    {
    }
}
    