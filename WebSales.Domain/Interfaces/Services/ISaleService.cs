using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Entities;
using WebSales.Domain.Models;

namespace WebSales.Domain.Services.Interfaces
{
    public interface ISaleService
    {
        public Task<APIResult<ErrorResult, Sale>> Get(int id);
        public Task<APIResult<ErrorResult, List<Sale>>> Get();
        public Task<APIResult<ErrorResult, Sale>> Post(SaleModel saleModel);
        public Task<APIResult<ErrorResult, string>> Put(SaleModel saleModel);
        public Task<APIResult<ErrorResult, string>> Delete(int id);
    }
}
