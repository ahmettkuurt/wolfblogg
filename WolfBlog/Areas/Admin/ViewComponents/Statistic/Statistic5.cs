using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace sstoktakip.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic5:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            TempData["v1"] = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            TempData["v2"]=c.Admins.Where(x=>x.AdminID==1).Select(y => y.ImageURL).FirstOrDefault();
            TempData["v3"]=c.Admins.Where(x=>x.AdminID==1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
