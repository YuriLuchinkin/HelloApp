using CustomIdentityApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentityApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUserValidator<User>, CustomUserValidator>();

            // ��������� ������ ���������� ������
            services.AddTransient<IPasswordValidator<User>,
                    CustomPasswordValidator>(serv => new CustomPasswordValidator(6));
          
            services.AddIdentity<User, IdentityRole>()
           .AddEntityFrameworkStores<ApplicationContext>();
            
            //������� � ���������� ����������� ���������� �������
            //services.AddIdentity<User, IdentityRole>(opts => {
            //    opts.Password.RequiredLength = 5;   // ����������� �����
            //    opts.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
            //    opts.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
            //    opts.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
            //    opts.Password.RequireDigit = false; // ��������� �� �����
            //})
            //.AddEntityFrameworkStores<ApplicationContext>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // ����������� ��������������
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}