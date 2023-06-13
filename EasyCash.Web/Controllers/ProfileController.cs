using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Web.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
