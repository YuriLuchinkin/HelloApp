using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using Microsoft.AspNetCore.Routing;

namespace RoutingApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.Routes.Add(new AdminRoute());

            routeBuilder.MapRoute("{controller}/{action}",
                async context => {
                    context.Response.ContentType = "text/html;charset=utf-8";
                    await context.Response.WriteAsync("двухсегментный запрос");
                });

            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
    //public class Startup
    //{
    //    public void Configure(IApplicationBuilder app)
    //    {
    //        // определ€ем обработчик маршрута
    //        var myRouteHandler = new RouteHandler(Handle);
    //        // создаем маршрут, использу€ обработчик
    //        var routeBuilder = new RouteBuilder(app, myRouteHandler);
    //        // само определение маршрута - он должен соответствовать запросу {controller}/{action}
    //        routeBuilder.MapRoute("default", "{controller}/{action}");
    //        // строим маршрут
    //        app.UseRouter(routeBuilder.Build());

    //        app.Run(async (context) =>
    //        {
    //            await context.Response.WriteAsync("Hello World!");
    //        });
    //    }

    //    // собственно обработчик маршрута
    //    private async Task Handle(HttpContext context)
    //    {
    //        RouteData routeData = context.GetRouteData();
    //        await context.Response.WriteAsync("Hello ASP.NET Core!");
    //    }
    //}
    //public class Startup
    //{
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }

    //        app.UseRouting();
    //        app.Use(async (context, next) =>
    //        {
    //            // получаем конечную точку
    //            Endpoint endpoint = context.GetEndpoint();

    //            if (endpoint != null)
    //            {
    //                // получаем шаблон маршрута, который ассоциирован с конечной точкой
    //                var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;

    //                Debug.WriteLine($"Endpoint Name: {endpoint.DisplayName}");
    //                Debug.WriteLine($"Route Pattern: {routePattern}");

    //                // если конечна€ точка определена, передаем обработку дальше
    //                await next();
    //            }
    //            else
    //            {
    //                Debug.WriteLine("Endpoint: null");
    //                // если конечна€ точка не определена, завершаем обработку
    //                await context.Response.WriteAsync("Endpoint is not defined");
    //            }
    //        });
    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapGet("/index", async context =>
    //            {
    //                await context.Response.WriteAsync("Hello Index!");
    //            });
    //            endpoints.MapGet("/", async context =>
    //            {
    //                await context.Response.WriteAsync("Hello World!");
    //            });
    //        });
    //    }
    //}
    //public class Startup
    //{
    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }

    //        app.UseRouting();

    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapGet("/", async context =>
    //            {
    //                await context.Response.WriteAsync("Hello World!");
    //            });
    //        });
    //    }
    //}
}
