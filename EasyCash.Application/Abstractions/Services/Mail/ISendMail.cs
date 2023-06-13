using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Application.Abstractions.Services.Mail
{
	public interface ISendMail
	{
		void SendConfirmMail(string mail,int code);
	}
}
