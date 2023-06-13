using EasyCash.Application.DTOs;
using EasyCash.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace EasyCash.Web.Controllers
{
	public class AuthController : Controller
	{
		readonly UserManager<AppUser> _userManager;
		readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
			var result=await _signInManager.PasswordSignInAsync(login.Username, login.Password, true, true);

			if (result.Succeeded)
			{
				AppUser user=await _userManager.FindByNameAsync(login.Username);
				if (user.EmailConfirmed == true)
				{
					return RedirectToAction("Index", "Home");
				}
				
			}
            return View();
        }
















        [HttpGet]
		public IActionResult ConfirmMail()
		{
			var mail = TempData["Mail"];
			ViewBag.mail = mail;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ConfirmMail(ConfirmMailDTO confirmMail)
		{
			var user = await _userManager.FindByEmailAsync(confirmMail.Mail);
			if (user.ConfirmCode == confirmMail.Code)
			{
				user.EmailConfirmed = true;
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Login", "Auth");
			}
			return View();
		}

	}
}
