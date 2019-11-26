using Autofac;
using MobileFinanceErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Dependency
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .As<ApplicationDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}