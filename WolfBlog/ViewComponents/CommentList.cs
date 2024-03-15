using Microsoft.AspNetCore.Mvc;
using sstoktakip.Models;

namespace sstoktakip.ViewComponents
{
    public class CommentList :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username="Ahmet"
                },
                new UserComment
                {
                    ID = 2,
                    Username="Ali"
                },
                new UserComment
                {
                    ID = 3,
                    Username="Merve"
                }

            };
            return View(commentValues);
        }
    }
}
