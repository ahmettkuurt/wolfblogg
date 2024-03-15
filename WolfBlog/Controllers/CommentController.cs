using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sstoktakip.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {

        CommentManager cm = new CommentManager(new EFCommentRepository());
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment p, int id)
        {
            var values = Convert.ToInt32(bm.GetBlogById(id));
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogID = values;
            cm.AddComment(p);
            return Redirect("~/Blog/BlogReadAll/" + p.BlogID);
            
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
