using EasyCash.Application.Abstractions.Services.Mail;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Infrastructure.Services.Mail
{
	public class SendMail : ISendMail
	{
		public void SendConfirmMail(string mail,int code)
		{
			MimeMessage mimeMessage= new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "batuhansarikaya008@gmail.com");
			MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail);
			mimeMessage.From.Add(mailboxAddressFrom);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = $" Kayıt işlemi için onay kodunuz: {code}";
			mimeMessage.Body = bodyBuilder.ToMessageBody();
			mimeMessage.Subject = "Easy Cash Onay Kodu";
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("batuhansarikaya008@gmail.com", "iwgiaaqwllzxyjzo");
			client.Send(mimeMessage);
			client.Disconnect(true);
		}
	}
}
