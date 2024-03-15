using Microsoft.AspNetCore.Mvc;
using sstoktakip.Areas.Admin.Models;

namespace sstoktakip.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass 
            { 
                categoryname="Teknoloji",
                categorycount=10 
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 5
            });
            list.Add(new CategoryClass
            {
                categoryname = "Sinema",
                categorycount = 2
            });
            list.Add(new CategoryClass
            {
                categoryname = "Araba",
                categorycount = 50
            });
            list.Add(new CategoryClass
            {
                categoryname = "Sanat",
                categorycount = 1
            });
            return Json(new {jsonlist=list});
        }
    }
}
