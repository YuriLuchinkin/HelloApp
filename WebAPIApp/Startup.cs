using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebAPIApp.Models;

namespace WebAPIApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlDataContractSerializerFormatters();
            string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;";
            // ������������� �������� ������
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(con));

            services.AddControllers(); // ���������� ����������� ��� �������������
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // ���������� ������������� �� �����������
            });
        }
    }
}