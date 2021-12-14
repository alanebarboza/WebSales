using FluentValidation;
using WebSales.Domain.Models;

namespace WebSales.Domain.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName most have a value.")
                .Length(4, 20).WithMessage("UserName should've contain between 4 and 20 characters.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name most have a value.")
                .MaximumLength(50).WithMessage("Name should've less than 50 characters.");
            RuleFor(x => x.PassWord)
                .NotEmpty().WithMessage("PassWord most have a value.")
                .MaximumLength(50).WithMessage("PassWord should've less than 45 characters.");
            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender most have a value.");
            RuleFor(x => x.Phone)
                .MaximumLength(15).WithMessage("Phone should've less than 15 characters.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address most have a value.")
                .MaximumLength(150).WithMessage("Address should've less than 150 characters.");
            RuleFor(x => x.Email)
                .MaximumLength(50).WithMessage("Email should've less than 50 characters.");
        }
    }
}
