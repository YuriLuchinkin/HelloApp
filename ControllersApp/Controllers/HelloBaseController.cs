﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace ControllersApp.Controllers
{
    public abstract class HelloBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("User-Agent"))
            {
                // получаем заголовок User-Agent
                var useragent = context.HttpContext.Request.Headers["User-Agent"].FirstOrDefault();
                // сравниваем его значение
                if (useragent.Contains("MSIE") || useragent.Contains("Trident"))
                {
                    context.Result = Content("Internet Explorer не поддерживается");
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
