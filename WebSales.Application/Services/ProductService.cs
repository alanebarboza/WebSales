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
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<APIResult<ErrorResult, Product>> Get(int id)
        {
            Product product = await _productRepository.Get(id);
            if (product == null)
                return new ErrorResult(new List<string>() { "Product invalid." });
            return await _productRepository.Get(id);
        }
        
        public async Task<APIResult<ErrorResult, List<Product>>> Get() => await _productRepository.Get();

        public async Task<APIResult<ErrorResult, Product>> Post(ProductModel productModel)
        {
            var validationResult = ExecuteValidator(productModel);
            if (validationResult.Count > 0)
                return new ErrorResult(validationResult);

            Product product = new (0, productModel.Name, productModel.Description, productModel.Price, productModel.Stock);
            return await _productRepository.Post(product);
        }

        public async Task<APIResult<ErrorResult, string>> Put(ProductModel productModel)
        {
            var validationResult = ExecuteValidator(productModel);
            if (validationResult.Count > 0)
                return new ErrorResult(validationResult);
            
            Product product = await _productRepository.Get(productModel.Id);
            if (product == null)
                return new ErrorResult(new List<string>() { "Product invalid." });
            
            product.MergeProperties(product, productModel);
            await _productRepository.Put(product);
            return "Product successfully updated.";
        }

        public async Task<APIResult<ErrorResult, string>> Delete(int id)
        {
            Product product = await _productRepository.Get(id);
            if (product == null)
                return new ErrorResult(new List<string>() { "Product invalid." });
            await _productRepository.Delete(product);
            return "Product successfully removed.";
        }

        private static ICollection<string> ExecuteValidator(ProductModel productModel)
        {
            ProductValidator validator = new();
            return ValidatorResult<ProductModel>.Validate(validator, productModel);
        }
    }
}
