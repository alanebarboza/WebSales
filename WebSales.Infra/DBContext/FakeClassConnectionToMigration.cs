using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebSales.Infra.DBContext
{
    public class FakeClassConnectionToMigration : IDesignTimeDbContextFactory<SQLDbContext>
    {
        public SQLDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SQLDbContext>();
            optionsBuilder.UseSqlServer("Server=SERVER_HERE;Database=Sales;User Id=USER_HERE;Password=PASSWORD_HERE;");
            return new SQLDbContext(optionsBuilder.Options);
        }
    }
}
