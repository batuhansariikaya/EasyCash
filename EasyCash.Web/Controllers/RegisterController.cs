using AutoMapper;
using EasyCash.Application.DTOs;
using EasyCash.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Web.Controllers
{
	public class RegisterController : Controller
	{
		readonly UserManager<AppUser> _userManager;
		//readonly IMapper _mapper;
		public RegisterController(UserManager<AppUser> userManager )
		{
			_userManager = userManager;
			
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
			AppUser user = new()
			{
				UserName = userRegister.Username,
				Name = userRegister.Name,
				Surname = userRegister.Surname,
				Email = userRegister.Email,
				ImageUrl = "asd",
				City = "dzd",
				District = "asds"

			};
			var result = await _userManager.CreateAsync(user, userRegister.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "ConfirmMail");
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
