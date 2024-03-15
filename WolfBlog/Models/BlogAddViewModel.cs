using Microsoft.AspNetCore.Mvc.Rendering;

namespace sstoktakip.Models
{
    public class BlogAddViewModel
    {
        public EntityLayer.Concrete.Blog Blog { get; set; }

        public List<SelectListItem> categoryvalues { get; set; }
        public List<SelectListItem> catvalues { get; set; }
    }
}
