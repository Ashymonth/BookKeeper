using Autofac;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Infrastructure.Configuration;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.Import;
using BookKeeper.Data.Services.Load;

namespace BookKeeper.Data.Infrastructure
{
    public class AutofacConfiguration
    {
        public static IContainer ConfigureContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterType(typeof(ExcelConfiguration))
                .As<IConfiguration<ExcelConfiguration>>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ApplicationDbContext))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(UnitOfWork))
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            container.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            container.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DistrictService))
                .As(typeof(IDistrictService))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExcelImportService))
                .As<IImport>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExcelDataLoader))
                .As<IDataLoader>()
                .InstancePerLifetimeScope();

            return container.Build();

        }
    }
}