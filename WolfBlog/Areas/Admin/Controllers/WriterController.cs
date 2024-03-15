using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sstoktakip.Areas.Admin.Models;

namespace sstoktakip.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index3(WriterClass w)
        {
            
            writers.Add(w);
            var JsonWriters = JsonConvert.SerializeObject(w);
            return Json(JsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {

            var writer = writers.FirstOrDefault(x=>x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x=>x.Id==w.Id);
            writer.Name=w.Name;
            var jsonWriter=JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }
        public JsonResult Index2()
        {
            var JsonWriters = JsonConvert.SerializeObject(writers);
            return Json(JsonWriters);
        }
        public JsonResult GetWriterByID(int writerid)
        {
            var findwriter = writers.FirstOrDefault(x => x.Id == writerid);
            var JsonWriters = JsonConvert.SerializeObject(findwriter);
            return Json(JsonWriters);
        }
        

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name="Ayşe"
            },
            new WriterClass
            {
                Id = 2,
                Name="Ahmet"
            },
            new WriterClass
            {
                Id = 3,
                Name="Buse"
            }
        };
    }
}
