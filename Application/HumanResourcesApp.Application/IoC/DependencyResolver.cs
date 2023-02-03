using Autofac;
using AutoMapper;
using HumanResourcesApp.Application.AutoMapper;
using HumanResourcesApp.Application.Services;
using HumanResourcesApp.Domain.Repositories;
using HumanResourcesApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Application.IoC
{
    public class DependencyResolver:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ManagerRepo>().As<IManagerRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CompanyRepo>().As<ICompanyRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ManagerService>().As<IManagerService>().InstancePerLifetimeScope();

            //Service eklenecek


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            }
         )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();



            base.Load(builder);
        }
    }
}
