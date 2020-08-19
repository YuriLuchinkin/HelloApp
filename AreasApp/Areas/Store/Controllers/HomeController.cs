﻿using Microsoft.AspNetCore.Mvc;

namespace AreasApp.Areas.Store.Controllers
{
    [Area("Store")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}