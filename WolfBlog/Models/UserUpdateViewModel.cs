﻿namespace sstoktakip.Models
{
    public class UserUpdateViewModel
    {
        public string namesurname { get; set; }
        public string username { get; set; }
        public string mail { get; set; }
        public IFormFile imageurl { get; set; }
        public string password { get; set; }
    }
}
