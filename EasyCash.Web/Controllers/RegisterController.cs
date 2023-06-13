using AutoMapper;
using EasyCash.Application.Abstractions.Services;
using EasyCash.Application.Abstractions.Services.Mail;
using EasyCash.Application.DTOs;
using EasyCash.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Web.Controllers
{
	public class RegisterController : Controller
	{
		readonly UserManager<AppUser> _userManager;
		readonly IRandomNumber _randomNumber;
		readonly ISendMail _sendMail;
		//readonly IMapper _mapper;
		public RegisterController(UserManager<AppUser> userManager, IRandomNumber randomNumber, ISendMail sendMail)
		{
			_userManager = userManager;
			_randomNumber = randomNumber;
			_sendMail = sendMail;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserRegisterDTO userRegister)
		{

			//AppUser map = _mapper.Map<AppUser>(userRegister);
			//map.ImageUrl = "asd";
			//map.City = "dzd";
			//map.District = "asds";
			int code = _randomNumber.GenerateNumber();
			AppUser user = new()
			{
				UserName = userRegister.Username,
				Name = userRegister.Name,
				Surname = userRegister.Surname,
				Email = userRegister.Email,
				ImageUrl = "asd",
				City = "dzd",
				District = "asds",
				ConfirmCode=code

			};
			var result = await _userManager.CreateAsync(user, userRegister.Password);
			if (result.Succeeded)
			{
				_sendMail.SendConfirmMail(user.Email, code);
				TempData["Mail"]=userRegister.Email;
				return RedirectToAction("ConfirmMail", "Auth");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
			return View();


		}
	}
}
