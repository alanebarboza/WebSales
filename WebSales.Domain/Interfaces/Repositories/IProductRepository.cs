using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Domain.Entities;

namespace WebSales.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> Get(int id);
        public Task<List<Product>> Get();
        public Task<Product> Post(Product product);
        public Task Put(Product product);
        public Task Delete(Product product);
        public Task<bool> Any(int id);
    }
}
