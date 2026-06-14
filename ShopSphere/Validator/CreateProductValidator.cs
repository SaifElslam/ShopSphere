using FluentValidation;
using ShopSphere.DTOs;

namespace ShopSphere.Validator
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.StokeQuantity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
