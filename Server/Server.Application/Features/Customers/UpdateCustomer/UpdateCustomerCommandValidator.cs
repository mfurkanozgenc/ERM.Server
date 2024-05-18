using FluentValidation;
using Server.Domain.Entities;

namespace Server.Application.Features.Customers.UpdateCustomer
{
    public sealed class UpdateCustomerCommandValidator : AbstractValidator<Customer>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.TaxDepartment).MinimumLength(10).MaximumLength(11);
            RuleFor(c => c.Name).MinimumLength(3);
            RuleFor(c => c.Id).NotEmpty().NotNull();
        }
    }
}
