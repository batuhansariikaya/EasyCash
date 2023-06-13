using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Application.Validators
{
	public class CustomIdentityValidation:IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Şifre minimum {length} karakter olmalıdır!"
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Şifre en az 1 tane büyük harf içermelidir!"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Şifre en az 1 tane küçük harf içermelidir!"
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Şifre en az 1 tane rakam içermelidir!"
			};
		}
		public override IdentityError PasswordMismatch()
		{
			return new IdentityError()
			{
				Code = "PasswordMismatch",
				Description = "Girilen şifreler eşleşmiyor!"
			};

		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Şifre en az 1 tane sembol içermelidir!"
			};
		}
	}
}
