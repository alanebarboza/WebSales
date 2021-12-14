using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Domain.Entities;

namespace WebSales.Domain.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        public Task<Sale> Get(int id);
        public Task<List<Sale>> Get();
        public Task<Sale> Post(Sale sale);
        public Task Put(Sale sale);
        public Task Delete(Sale sale);
        public Task<bool> Any(int id);
        public Task<bool> AnyProduct(int id);
        public Task<bool> AnyUser(int id);

    }
}
