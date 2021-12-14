using Microsoft.EntityFrameworkCore;
using WebSales.Domain.Entities;
using WebSales.Infra.EntityConfigurations;

namespace WebSales.Infra.DBContext
{
    public class SQLDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleItems> SaleItems { get; set; }

        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(UserSettings).Assembly);

            base.OnModelCreating(modelbuilder);
        }
    }
}
