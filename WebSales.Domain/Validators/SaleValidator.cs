using FluentValidation;
using WebSales.Domain.Repositories.Interfaces;
using WebSales.Domain.Models;

namespace WebSales.Domain.Validators
{
    public class SaleValidator : AbstractValidator<SaleModel>
    {
        public SaleValidator(ISaleRepository _saleRepository)
        {
            RuleFor(x => x.PaidBy)
                .NotEmpty().WithMessage("PaidBy most have a value.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount should be greater than 0");
            RuleFor(x => x.CreditCardNumber)
                .MaximumLength(16).WithMessage("CreditCardNumber should've contain less than 16 characters.");
            RuleFor(x => x.BarCode)
                .MaximumLength(43).WithMessage("CreditCardNumber should've contain less than 43 characters.");

            RuleFor(x => x.UserId).MustAsync(async (saleItemsModel, id, cancellation) =>
            {
                return await _saleRepository.AnyUser(saleItemsModel.UserId);
            }).WithMessage("User is invalid.");

            RuleForEach(x => x.SaleItems).SetValidator(new SaleItemsValidator(_saleRepository));
        }
    }
}
