using Autofac;
using MobileFinanceErp.Service;
using System.Linq;

namespace MobileFinanceErp.Dependency
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityHelper>()
                .As<IIdentityHelper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataMapper>()
                .As<IDataMapper>()
                .InstancePerLifetimeScope();

            var services = typeof(BrandService).Assembly.GetTypes()
                .Where(w => w.Name.EndsWith("Service") && !w.IsInterface).ToArray();

            builder.RegisterTypes(services)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

    }
}