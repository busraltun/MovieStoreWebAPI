using Autofac;
using MovieStore.Business.Mapping;
using MovieStore.Business.Services;
using MovieStore.Core.Abstract;
using MovieStore.Data.ContextConfiguration;
using MovieStore.Data.Repositories;
using MovieStore.Data.UnitOfWork;
using System.Reflection;
using Module = Autofac.Module;
namespace MovieStore.WebAPI.Modules
{
    public class RepoServiceModul : Module
    {
        /// <summary>
        /// InstancePerLifeTimeScope => .NET Core API de ki Scope a karşılık geliyor
        /// InstancePerDependency => Transient e karşılık geliyor
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(Context));

            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                   .Where(x => x.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                   .Where(x => x.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                   .As(typeof(IGenericRepository<>))
                   .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Service<>))
                   .As(typeof(IService<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                   .As<IUnitOfWork>();


            base.Load(builder);
        }
    }
}
