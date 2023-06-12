using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));

        }
    }
}
