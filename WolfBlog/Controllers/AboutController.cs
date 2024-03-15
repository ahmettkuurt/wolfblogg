using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sstoktakip.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
	{
		AboutManager ab = new AboutManager(new EFAboutRepository());
		public IActionResult Index()
		{
			var values = ab.GetList ();
			return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
