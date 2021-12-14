
using FluentValidation;
using WebSales.Domain.Models;

namespace WebSales.Domain.Validators
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName most have a value.")
                .Length(4, 20).WithMessage("UserName should've contain between 4 and 20 characters.");

            RuleFor(x => x.PassWord)
                .NotEmpty().WithMessage("PassWord most have a value.")
                .Length(4, 20).WithMessage("PassWord should've contain between 4 and 20 characters.");
        }
    }
}
