using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace sstoktakip.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EFMessage2Repository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            
            //var username = User.Identity.Name;
            //var usermail=c.Users.Where(x=>x.UserName== username).Select(y=>y.Id).FirstOrDefault();
            //var values = mm.GetInboxListByWriter(usermail);
            //ViewData["cv"]=c.Message2s.Where(x=>x.ReceiverUser.Id == usermail).Count();
            return View();
        }
    }
}
