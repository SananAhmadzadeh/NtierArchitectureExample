using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NtierArchitecture.DataAccess.Repositories.Concrete.EFCore;

namespace NtierArchitecture.DataAccess
{
    public static class ConfigurationServices
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddDataAccessConfiguration(IConfiguration configuration)
            {
                services.AddDbContext<ExampleDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });

                services.AddScoped<ICategoryRepository, EfCategoryRepository>();
                services.AddScoped<IProductRepository, EfProductRepository>();
                services.AddScoped<IOrderRepository, EfOrderRepository>();
                services.AddScoped<IOrderItemRepository, EfOrderItemRepository>();

                return services;
            }   
        }
    }
}
