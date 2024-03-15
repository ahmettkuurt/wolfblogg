using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sstoktakip.Models;

namespace sstoktakip.Controllers
{

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBLogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.v = writerID;
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View();
        }
        [HttpGet]
        public IActionResult BlogAdd(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult BlogAdd(BlogAddİmage model)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = new Blog();
            values.BlogTitle = model.BlogTitle;
            values.BlogContent = model.BlogContent;
            if (model.BlogImage != null)
            {
                var extension = Path.GetExtension(model.BlogImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.BlogImage.CopyTo(stream);
                values.BlogImage = "/blogImage/" + newimagename;
            }
            if (model.BlogThumbnailImage != null)
            {
                var extension = Path.GetExtension(model.BlogThumbnailImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogThumbnailImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.BlogThumbnailImage.CopyTo(stream);
                values.BlogThumbnailImage = "/blogThumbnailImage/" + newimagename;
            }
            model.Id = writerID;
            model.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            model.BlogStatus = true; ;
            values.BlogCreateDate = model.BlogCreateDate;
            values.BlogID = model.Id;
            values.BlogStatus = model.BlogStatus;
            values.CategoryID = model.CategoryID;
            bm.AddT(values);
            return RedirectToAction("BlogListByWriter");
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.DeleteT(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult EditBlog(BlogAddİmage model)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = new Blog();
            values.BlogTitle = model.BlogTitle;
            values.BlogContent = model.BlogContent;
            if (model.BlogImage != null)
            {
                var extension = Path.GetExtension(model.BlogImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.BlogImage.CopyTo(stream);
                values.BlogImage = "/blogImage/" + newimagename;
            }
            if (model.BlogThumbnailImage != null)
            {
                var extension = Path.GetExtension(model.BlogThumbnailImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogThumbnailImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.BlogThumbnailImage.CopyTo(stream);
                values.BlogThumbnailImage = "/blogThumbnailImage/" + newimagename;
            }
            model.Id = writerID;
            model.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            model.BlogStatus = true; ;
            values.BlogCreateDate = model.BlogCreateDate;
            values.BlogID = model.Id;
            values.BlogStatus = model.BlogStatus;
            values.CategoryID = model.CategoryID;
            bm.UpdateT(values);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
