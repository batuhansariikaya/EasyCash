using EasyCash.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/EasyCash.Web"));
            configurationManager.AddJsonFile("appsettings.json");
            services.AddDbContext<EasyCashDbContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("SQLServer")));


        }
    }
}
