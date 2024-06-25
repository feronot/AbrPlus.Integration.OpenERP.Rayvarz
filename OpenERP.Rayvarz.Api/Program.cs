using AbrPlus.Integration.OpenERP.Hosting.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeptaKit.Extensions;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            AppHostBuilder.CreateHostBuilder<Startup>(args, GetHttpPort, GetHttpsPort, GetCert);

        public static int GetHttpPort(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            var port = configuration.GetValue<int>("App:HttpPort");
            return port;
        }

        public static int GetHttpsPort(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            var port = configuration.GetValue<int>("App:HttpsPort");
            return port;
        }

        public static X509Certificate2 GetCert(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();

            var subject = configuration.GetValue<string>($"AuthorityCert");
            if (subject.HasValue())
            {
                return CertificateLoader.LoadFromStoreCert(subject, StoreName.Root.ToString(), StoreLocation.CurrentUser, false);
            }
            else
            {
                return new X509Certificate2(Path.Combine(AppHostBuilder.GetAppLocation(), "Certs", "localhost.pfx"), "13");
            }
        }
    }
}
