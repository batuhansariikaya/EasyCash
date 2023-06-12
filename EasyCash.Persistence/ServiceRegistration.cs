using EasyCash.Application.Repositories;
using EasyCash.Persistence.Contexts;
using EasyCash.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EasyCash.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\EasyCash.Web"));
            configurationManager.AddJsonFile("appsettings.json");
            services.AddDbContext<EasyCashDbContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("SQLServer")));


            // IOC and Dependency Container

            services.AddSingleton<ICustomerAccountReadRepository, CustomerAccountReadRepository>();
            services.AddSingleton<ICustomerAccountWriteRepository, CustomerAccountWriteRepository>();
            services.AddSingleton<IAccountProcessReadRepository, AccountProcessReadRepository>();
            services.AddSingleton<IAccountProcessWriteRepository, AccountProcessWriteRepository>();
            
        }
    }
}
