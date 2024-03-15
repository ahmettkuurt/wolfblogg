using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace sstoktakip.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic3:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            //TempData["b1"]=bm.GetList().Count().ToString();
            TempData["b1"]=c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            TempData["b3"]=c.Comments.Count();
            return View();
        
        }
    }
}
