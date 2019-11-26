
using Autofac;
using MobileFinanceErp.Repository;
using System.Linq;

namespace MobileFinanceErp.Dependency
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            var types = typeof(ITenantRepository).Assembly.GetTypes()
                .Where(w => w.Name.EndsWith("Repository") && !w.IsGenericType && !w.IsInterface)
                .ToArray();

            builder.RegisterTypes(types)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}