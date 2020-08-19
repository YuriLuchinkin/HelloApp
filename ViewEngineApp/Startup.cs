using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ViewEngineApp.Util;

namespace ViewEngineApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MvcViewOptions>(options => {
                options.ViewEngines.Clear();
                options.ViewEngines.Insert(0, new CustomViewEngine());
            });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}