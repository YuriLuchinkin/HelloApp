using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace ConfigurationApp
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("person.json");
            AppConfiguration = builder.Build();
        }

        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // создание объекта Person по ключам из конфигурации
            services.Configure<Person>(AppConfiguration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<PersonMiddleware>();
        }
    }

    public class Startup_
    {
        public Startup_()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("conf.json");

            AppConfiguration = builder.Build();
        }
        // свойство, которое будет хранить конфигурацию
        public IConfiguration AppConfiguration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            });
        }
        //public Startup(IConfiguration config)
        //{
        //    AppConfiguration = config;
        //}
        //public IConfiguration AppConfiguration { get; set; }

        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello world");
        //    });
        //}
    }
}
