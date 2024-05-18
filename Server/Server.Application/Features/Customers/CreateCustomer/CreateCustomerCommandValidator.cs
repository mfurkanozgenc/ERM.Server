using FluentValidation;
using Server.Domain.Entities;

namespace Server.Application.Features.Customers.CreateCustomer
{
    public sealed class CreateCustomerCommandValidator : AbstractValidator<Customer>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.TaxDepartment).MinimumLength(10).MaximumLength(11);
            RuleFor(c => c.Name).MinimumLength(3);
        }
    }
}
