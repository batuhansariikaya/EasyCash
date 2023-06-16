using EasyCash.Application.Abstractions.Services;
using EasyCash.Application.DTOs;
using EasyCash.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Web.Controllers
{
    public class ProfileController : Controller
    {
        readonly IGetUserInfo _userInfo;
        readonly UserManager<AppUser> _userManager;

        public ProfileController(IGetUserInfo userInfo, UserManager<AppUser> userManager)
        {
            _userInfo = userInfo;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {
            var user=await _userInfo.LoggedUserInfo(User.Identity.Name);
            UserEditDTO userEdit = new();
            userEdit.Name = user.Name;
            userEdit.Email=user.Email;
            userEdit.Surname = user.Surname;
            userEdit.City = user.City;
            userEdit.District = user.District;
            userEdit.ImageUrl= user.ImageUrl;
            userEdit.Username = user.UserName;

            return View(userEdit);
        }
        [HttpPost]
        public async Task<IActionResult> MyAccount(UserEditDTO userEdit)
        {
            var user=await _userInfo.LoggedUserInfo(User.Identity.Name); 
            user.Name = userEdit.Name;
            user.Surname=userEdit.Surname;
            user.UserName = userEdit.Username;
            user.City=userEdit.City;
            user.District=userEdit.District;
            user.ImageUrl="asd";
            user.Email=userEdit.Email;
        //    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEdit.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
    }
}
