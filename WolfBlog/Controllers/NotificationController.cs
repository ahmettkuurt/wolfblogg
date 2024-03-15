﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sstoktakip.Controllers
{
    
    public class NotificationController : Controller
    {
        NotificationManager nm =new NotificationManager(new EFNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllNotification() 
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
