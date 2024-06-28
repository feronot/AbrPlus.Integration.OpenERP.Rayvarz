using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeptaKit.DI;
using System.Linq;
using AbrPlus.Integration.OpenERP.Rayvarz.Options;
using AbrPlus.Integration.OpenERP.Rayvarz.Repository.DI;
using AbrPlus.Integration.OpenERP.Rayvarz.Service.DI;
using AbrPlus.Integration.OpenERP.Rayvarz.Api.DI;
using AbrPlus.Integration.OpenERP.Hosting.DI;
using AbrPlus.Integration.OpenERP.Hosting.Hosting;
using AbrPlus.Integration.OpenERP.DI;
using System.Net.Http;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api
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
            services.GeneralConfigure(Configuration);

            services.Configure<RayvarzOption>(x => Configuration.GetSection("App").Bind(x));
            services.AddHttpClient();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructureDIModule>();
            builder.RegisterModule<ExtendedDIModule>();
            builder.RegisterModule<RepositoryDIModule>();
            builder.RegisterModule<ServiceDIModule>();
            builder.RegisterModule<ApiDIModule>();
            //builder.RegisterInstance(new HttpClient()).As<HttpClient>().SingleInstance();
            builder.Register(c =>
            {
                var factory = c.Resolve<IHttpClientFactory>();
                return factory.CreateClient();
            }).As<HttpClient>().InstancePerLifetimeScope();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

            app.UseEndpoints(endpoints =>
            {
                var asembely = typeof(Startup).Assembly;
                var apiTypes = asembely.GetTypes().Where(x => typeof(IApi).IsAssignableFrom(x) && !x.IsInterface).ToList();
                foreach (var apiType in apiTypes)
                {
                    endpoints.UseSoapEndPoint(apiType);
                    endpoints.UseGrpcEndPoint(apiType);
                }
            });
        }


    }

}
