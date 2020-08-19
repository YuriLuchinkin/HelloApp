using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using DIApp.Services;

namespace DIApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TimeService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<TimerMiddleware>();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
    public class Startup_2
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICounter, RandomCounter>();
            services.AddScoped<CounterService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CounterMiddleware>();
        }
    }

    public class Startup_1
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, SmsMessageSender>();
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Hosting.IHostingEnvironment env, IMessageSender messageSender)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageSender.Send());
            });
        }

        //private IServiceCollection _services;
        //// This method gets called by the runtime. Use this method to add services to the container.
        //// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    _services = services;
        //}
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        var sb = new StringBuilder();
        //        sb.Append("<h1>Все сервисы</h1>");
        //        sb.Append("<table>");
        //        sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
        //        foreach (var svc in _services)
        //        {
        //            sb.Append("<tr>");
        //            sb.Append($"<td>{svc.ServiceType.FullName}</td>");
        //            sb.Append($"<td>{svc.Lifetime}</td>");
        //            sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
        //            sb.Append("</tr>");
        //        }
        //        sb.Append("</table>");
        //        context.Response.ContentType = "text/html;charset=utf-8";
        //        await context.Response.WriteAsync(sb.ToString());
        //    });
        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
