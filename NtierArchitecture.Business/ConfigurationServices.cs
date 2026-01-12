
using Microsoft.Extensions.DependencyInjection;
using NtierArchitecture.Business.Services.Abstract;
using NtierArchitecture.Business.Services.Concrete;
using System.Reflection;

namespace NtierArchitecture.Business
{
    public static class ConfigurationServices 
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddBusinessConfiguration()
            {
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
                services.AddScoped<IProductService, ProductManager>();
                return services;
            }
        }
    }
}
