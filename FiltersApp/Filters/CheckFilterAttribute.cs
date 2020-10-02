using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace FiltersApp.Filters
{
    public class CheckFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                                        ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid == true)
                context.ActionArguments["id"] = 34;
            await next();
        }
    }
}