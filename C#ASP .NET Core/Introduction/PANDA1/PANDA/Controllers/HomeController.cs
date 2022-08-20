using Microsoft.AspNetCore.Mvc;

namespace PANDA.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        
        public IActionResult Index()
        {
            return View("guest-home");
        }
    }
}
