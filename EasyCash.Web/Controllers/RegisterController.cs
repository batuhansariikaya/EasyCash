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
        readonly IMapper _mapper;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterDTO userRegister)
        {
            if (ModelState.IsValid)
            {
                AppUser map = _mapper.Map<AppUser>(userRegister);
                IdentityResult result=await _userManager.CreateAsync(map, userRegister.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
               
            }
          
            
            return View();


        }
    }
}
