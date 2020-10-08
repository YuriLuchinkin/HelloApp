using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace ServiceHostingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // �������� ���� � ����� 
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            // ���� � �������� �������
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            // ������� ����
            var host = WebHost.CreateDefaultBuilder(args)
                    .UseContentRoot(pathToContentRoot)
                    .UseStartup<Startup>()
                    .Build();
            // ��������� � ���� ������
            host.RunAsService();
        }
        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
