using FluentValidation;
using WebSales.Domain.Repositories.Interfaces;
using WebSales.Domain.Models;

namespace WebSales.Domain.Validators
{
    public class SaleItemsValidator : AbstractValidator<SaleItemsModel>
    {
        public SaleItemsValidator(ISaleRepository _saleRepository)
        {
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price should be greater than 0");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity should be greater than 0");

            RuleFor(x => x.ProductId).MustAsync(async (saleItemsModel, id, cancellation) =>
            {
                return await _saleRepository.AnyProduct(saleItemsModel.ProductId);
            }).WithMessage("Product is invalid.");
        }
    }
}
