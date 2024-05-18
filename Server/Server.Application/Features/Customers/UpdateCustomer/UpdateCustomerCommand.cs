using MediatR;
using Server.Application.Features.Customers.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Server.Application.Features.Customers.UpdateCustomer
{
    public sealed record UpdateCustomerCommand(
        Guid Id,
        string Name,
        string TaxDepartment,
        string TaxNumber,
        string City,
        string Town,
        string FullAddress) : IRequest<Result<string>>;
}
