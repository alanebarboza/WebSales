using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Services.Interfaces;
using WebSales.Domain.Entities;
using WebSales.Domain.Models;
using WebSales.Domain.Validators;
using WebSales.Domain.Repositories.Interfaces;

namespace WebSales.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository) => _saleRepository = saleRepository;

        public async Task<APIResult<ErrorResult, Sale>> Get(int id)
        {
            Sale sale = await _saleRepository.Get(id);
            if (sale == null)
                return new ErrorResult(new List<string>() { "Sale invalid." });
            return await _saleRepository.Get(id);
        }

        public async Task<APIResult<ErrorResult, List<Sale>>> Get() => await _saleRepository.Get();

        public async Task<APIResult<ErrorResult, Sale>> Post(SaleModel saleModel)
        {
            var validationResult = ExecuteValidator(saleModel);
            if (validationResult.Count > 0)
                return new ErrorResult(validationResult);

            ICollection<SaleItems> saleItems = new List<SaleItems>();
            foreach (var item in saleModel.SaleItems)
                saleItems.Add(new SaleItems(item.Id, item.Quantity, item.Price, item.ProductId));
            Sale sale = new(0, saleModel.PaidBy, saleModel.CreditCardNumber, saleModel.BarCode, saleModel.Amount, saleModel.UserId, saleItems);
            return await _saleRepository.Post(sale);
        }

        public async Task<APIResult<ErrorResult, string>> Put(SaleModel saleModel)
        {
            var validationResult = ExecuteValidator(saleModel);
            if (validationResult.Count > 0)
                return new ErrorResult(validationResult);

            Sale sale = await _saleRepository.Get(saleModel.Id);
            if (sale == null)
                return new ErrorResult(new List<string>() { "Sale invalid." });

            sale.MergeProperties(sale, saleModel);
            if (sale == null)
                return new ErrorResult(new List<string>() { "Sale invalid." });

            await _saleRepository.Put(sale);
            return "Sale successfully updated.";
        }
        public async Task<APIResult<ErrorResult, string>> Delete(int id)
        {
            Sale sale = await _saleRepository.Get(id);
            if (sale == null)
                return new ErrorResult(new List<string>() { "Sale invalid." });
            await _saleRepository.Delete(sale);
            return "Sale successfully removed.";
        }

        private ICollection<string> ExecuteValidator(SaleModel saleModel)
        {
            SaleValidator validator = new(_saleRepository);
            return ValidatorResult<SaleModel>.Validate(validator, saleModel);
        }
    }
}
