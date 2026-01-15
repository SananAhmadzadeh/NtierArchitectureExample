using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NtierArchitecture.DataAccess.UnitOfWork.Abstract;


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

                services.AddScoped<IUnitOfWork, UnitOfWork.Concrete.UnitOfWork>();

                return services;
            }
        }
    }
}
