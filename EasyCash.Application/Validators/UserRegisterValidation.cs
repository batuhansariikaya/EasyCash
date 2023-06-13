using EasyCash.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Application.Validators
{
    public class UserRegisterValidation:AbstractValidator<UserRegisterDTO>
    {
        public UserRegisterValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad alanı boş bırakılamaz!")
                .MaximumLength(30).WithMessage("Maksimum 30 karakter girişi yapın!")
                .MinimumLength(2).WithMessage("Minimum 2 karakter girişi yapın!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz!");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail alanı boş bırakılamaz!")
                .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz!");
            RuleFor(x => x.ConfirmPassword).Equal(x=>x.Password).WithMessage("Şifreler eşleşmiyor!");

        }
    }
}
