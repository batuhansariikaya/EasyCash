using EasyCash.Application.Abstractions.Services;
using EasyCash.Application.Repositories;
using EasyCash.Application.Validators;
using EasyCash.Domain.Entities.Identity;
using EasyCash.Persistence.Contexts;
using EasyCash.Persistence.Repositories;
using EasyCash.Persistence.Services;
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
            
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<EasyCashDbContext>().AddErrorDescriber<CustomIdentityValidation>();
            // IOC and Dependency Container

            services.AddScoped<ICustomerAccountReadRepository, CustomerAccountReadRepository>();
            services.AddScoped<ICustomerAccountWriteRepository, CustomerAccountWriteRepository>();

            services.AddScoped<IAccountProcessReadRepository, AccountProcessReadRepository>();
            services.AddScoped<IAccountProcessWriteRepository, AccountProcessWriteRepository>();

            services.AddScoped<IRandomNumber, RandomNumber>();
            
        }
    }
}
