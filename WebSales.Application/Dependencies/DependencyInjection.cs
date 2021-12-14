using Microsoft.Extensions.DependencyInjection;
using WebSales.Application.Services;
using WebSales.Domain.Services.Interfaces;
using WebSales.Infra.Repositories;
using WebSales.Domain.Repositories.Interfaces;

namespace WebSales.Application.Dependencies
{
    public static class DependencyInjection
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
        }

        public static void AddRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
        }
    }
}
