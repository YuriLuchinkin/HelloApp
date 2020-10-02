using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace RazorPagesApp.Filters
{
    public class UserAgentPageFilter : Attribute, IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {

        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            // получаем информацию о браузере пользователя
            string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
            if (Regex.IsMatch(userAgent, "MSIE|Trident"))
            {
                context.Result = new BadRequestObjectResult("Ваш браузер устарел");
            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {

        }
    }
}