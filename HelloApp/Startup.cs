using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();   // добавляем поддержку статических файлов

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.UseMiddleware<ErrorHandlingMiddleware>();
        //    app.UseMiddleware<AuthenticationMiddleware>();
        //    app.UseMiddleware<RoutingMiddleware>();
        //}
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.UseToken("555555");

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello World");
        //    });
        //}

        //public void Configure(IApplicationBuilder app)
        //{
        //    int x = 5;
        //    int y = 8;
        //    int z = 0;
        //    app.Use(async (context, next) =>
        //    {
        //        z = x * y;
        //        await next.Invoke();
        //    });

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync($"x * y = {z}");
        //    });
        //}
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello World!");
        //    });
        //}
        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapGet("/", async context =>
        //        {
        //            await context.Response.WriteAsync("Hello World!");
        //        });
        //    });
        //}
    }
}
