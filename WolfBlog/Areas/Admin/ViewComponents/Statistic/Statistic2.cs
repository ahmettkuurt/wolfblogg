using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace sstoktakip.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            TempData["b1"]=bm.GetList().Count().ToString();
            TempData["b2"]=c.Contacts.Count();
            TempData["b3"]=c.Comments.Count();

            string api = "149a0dccc71b4f17aa380110230808 ";
            string connection = "http://api.weatherapi.com/v1/current.xml?key="+api+"%20&q=Istanbul&aqi=no";
            XDocument document= XDocument.Load(connection);
            TempData["b4"] = document.Descendants("temp_c").ElementAt(0).Value;
            return View();
        
        }
    }
}
