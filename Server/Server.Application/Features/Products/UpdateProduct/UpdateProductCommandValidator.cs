using FluentValidation;
using Server.Application.Features.Products.CreateProduct;

namespace Server.Application.Features.Products.UpdateProduct
{
    public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.TypeValue).GreaterThan(0);
        }
    }
}
