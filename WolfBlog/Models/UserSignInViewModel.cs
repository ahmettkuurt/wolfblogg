using System.ComponentModel.DataAnnotations;

namespace sstoktakip.Models
{
    public class UserSignInViewModel
    {
        [Required (ErrorMessage ="Lütfen Kullanıcı Adı Giriniz.")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string password { get; set; }
    }
}
