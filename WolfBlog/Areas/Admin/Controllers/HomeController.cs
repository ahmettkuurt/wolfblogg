using Microsoft.AspNetCore.Mvc;

namespace sstoktakip.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
