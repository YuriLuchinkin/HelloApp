﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HtmlHelpersApp.Models;

namespace HtmlHelpersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(string name, int age)
        //{
        //    return Content($"{name} - {age}");
        //}
        [HttpPost]
        public IActionResult Create(User user)
        {
            return Content($"{user.Name} - {user.Age}");
        }

        public IActionResult Details()
        {
            User tom = new User { Id = 1, Name = "Tom", Age = 35 };
            return View(tom);
        }
    }
}
