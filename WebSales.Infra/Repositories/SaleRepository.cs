using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Domain.Entities;
using WebSales.Domain.Repositories.Interfaces;
using WebSales.Infra.DBContext;

namespace WebSales.Infra.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SQLDbContext _sqlDbContext;
        public SaleRepository(SQLDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }
        public async Task<List<Sale>> Get() => await _sqlDbContext.Sale.AsNoTracking().ToListAsync();

        public async Task<Sale> Get(int id) => await _sqlDbContext.Sale.Include( x => x.SaleItems).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Sale> Post(Sale sale)
        {
            _sqlDbContext.Sale.Add(sale);
            await _sqlDbContext.SaveChangesAsync();
            return sale;
        }

        public async Task Put(Sale sale)
        {
            _sqlDbContext.Sale.Update(sale);
            await _sqlDbContext.SaveChangesAsync();
        }

        public async Task Delete(Sale sale)
        {
            _sqlDbContext.Sale.Remove(sale);
            await _sqlDbContext.SaveChangesAsync();
        }
        public async Task<bool> Any(int id) => await _sqlDbContext.Sale.AsNoTracking().AnyAsync(x => x.Id == id);
        public async Task<bool> AnyProduct(int id) => await _sqlDbContext.Product.AsNoTracking().AnyAsync(x => x.Id == id);
        public async Task<bool> AnyUser(int id) => await _sqlDbContext.User.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
