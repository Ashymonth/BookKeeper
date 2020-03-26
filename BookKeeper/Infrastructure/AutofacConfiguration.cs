using Autofac;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Infrastructure.Configuration;
using BookKeeper.Data.Models.ExcelImport;
using BookKeeper.Data.Models.HtmlImport;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.Import;
using BookKeeper.Data.Services.Load;
using System.Collections.Generic;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.Data.Services.EntityService.Rate;

namespace BookKeeper.Data.Infrastructure
{
    public static class AutofacConfiguration
    {
        public static IContainer ConfigureContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterType(typeof(ApplicationDbContext))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExcelConfiguration))
                .As<IConfiguration<ExcelConfiguration>>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(HtmlConfiguration))
                .As<IConfiguration<HtmlConfiguration>>()
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

            container.RegisterType(typeof(AccountService))
                .As(typeof(IAccountService))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(StreetService))
                .As(typeof(IStreetService))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DistrictService))
                .As(typeof(IDistrictService))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(LocationService))
                .As(typeof(ILocationService))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(PaymentDocumentService))
                .As(typeof(IPaymentDocumentService))
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(RateDocumentService))
                .As<IRateDocumentService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExcelImportService))
               .As<IImportService<List<ImportDataRow>>>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DiscountDocumentService))
                .As<IDiscountDocumentService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DiscountPercentService))
                .As<IDiscountPercentService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DiscountDescriptionService))
                .As<IDiscountDescriptionService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(HtmlImportService))
                .As<IImportService<List<PaymentDocumentImport>>>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(SearchService))
                .As<ISearchService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExcelDataLoader))
                .Named<IDataLoader>("Excel")
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(HtmlLoadService))
                .Named<IDataLoader>("Html")
                .InstancePerLifetimeScope();

            return container.Build();
        }
    }
}