using AutoMapper;
using EasyCash.Application.DTOs;
using EasyCash.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Index(UserRegisterDTO userRegister)
        {
            AppUser map=_mapper.Map<AppUser>(userRegister);
            _userManager.CreateAsync(map);
            return View();
        }
    }
}
