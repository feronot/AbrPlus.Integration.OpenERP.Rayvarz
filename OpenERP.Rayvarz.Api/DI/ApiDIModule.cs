using Autofac;
using SeptaKit.Autofac;
using SeptaKit.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.DI
{
    internal class ApiDIModule : BaseDIModule<ApiDIModule>
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var apiTypes = GetType().Assembly.GetExportedTypes().Where(x => typeof(IApi).IsAssignableFrom(x)).ToArray();

            builder.RegisterTypes(apiTypes).AsSelf().InstancePerDependency();
        }
    }
}
