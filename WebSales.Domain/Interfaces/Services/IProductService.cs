using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Entities;
using WebSales.Domain.Models;

namespace WebSales.Domain.Services.Interfaces
{
    public interface IProductService
    {
        public Task<APIResult<ErrorResult, Product>> Get(int id);
        public Task<APIResult<ErrorResult, List<Product>>> Get();
        public Task<APIResult<ErrorResult, Product>> Post(ProductModel productModel);
        public Task<APIResult<ErrorResult, string>> Put(ProductModel productModel);
        public Task<APIResult<ErrorResult, string>> Delete(int id);
    }
}
