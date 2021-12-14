using FluentValidation;
using WebSales.Domain.Models;

namespace WebSales.Domain.Validators
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name most have a value.")
                .MaximumLength(50).WithMessage("Name should've less than 30 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description most have a value.")
                .MaximumLength(150).WithMessage("Description should've contain less than 80 characters.");
        }
    }
}
