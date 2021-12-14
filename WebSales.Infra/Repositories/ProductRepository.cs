using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Domain.Entities;
using WebSales.Infra.DBContext;
using WebSales.Domain.Repositories.Interfaces;

namespace WebSales.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SQLDbContext _sqlDbContext;
        public ProductRepository(SQLDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }
        public async Task<List<Product>> Get() => await _sqlDbContext.Product.AsNoTracking().ToListAsync();

        public async Task<Product> Get(int id) => await _sqlDbContext.Product.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Product> Post(Product product)
        {
            _sqlDbContext.Product.Add(product);
            await _sqlDbContext.SaveChangesAsync();
            return product;
        }

        public async Task Put(Product product)
        {
            _sqlDbContext.Product.Update(product);
            await _sqlDbContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _sqlDbContext.Product.Remove(product);
            await _sqlDbContext.SaveChangesAsync();
        }
        public async Task<bool> Any(int id) => await _sqlDbContext.Product.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
