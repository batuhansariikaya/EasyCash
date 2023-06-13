using EasyCash.Application.Abstractions.Services.Mail;
using EasyCash.Infrastructure.Services.Mail;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureSerivce(this IServiceCollection services)
		{
			services.AddScoped<ISendMail,SendMail>();
		}
	}
}
