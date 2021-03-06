﻿using Autofac;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Infrastructure.Configuration;
using BookKeeper.Data.Infrastructure.Reports;
using BookKeeper.Data.Models.ExcelImport;
using BookKeeper.Data.Models.HtmlImport;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.Data.Services.EntityService.Rate;
using BookKeeper.Data.Services.Export;
using BookKeeper.Data.Services.Import;
using BookKeeper.Data.Services.Load;
using System.Collections.Generic;
using System.Configuration;

namespace BookKeeper.Data.Infrastructure
{
    public static class AutofacConfiguration
    {
        public static IContainer ConfigureContainer(bool isTest = false)
        {
            var container = new ContainerBuilder();

            string connectionString;
            if (isTest == false)
            {
                connectionString = string.Format(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["ConnectionName"]].ConnectionString);
                connectionString = ConnectionBuilderService.BuildConnectionString(connectionString);
            }
            else
                connectionString = string.Format(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["TestConnectionName"]].ConnectionString);

            container.RegisterType(typeof(ApplicationDbContext))
            .WithParameter("connectionString", connectionString)
            .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExcelConfiguration))
                .As<IConfiguration<ExcelConfiguration>>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(HtmlConfiguration))
                .As<IConfiguration<HtmlConfiguration>>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(BrokenRecordsReport))
                .As<IBrokenRecordsReport>()
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

            container.RegisterType(typeof(RateService))
                .As<IRateService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DefaultRateService))
                .As<IDefaultRateService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExcelImportService))
                .As<IImportService<List<ImportDataRow>>>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DiscountService))
                .As<IDiscountDocumentService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DiscountPercentService))
                .As<IDiscountPercentService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(DiscountDescriptionService))
                .As<IDiscountDescriptionService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(OccupantService))
                .As<IOccupantService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(HtmlImportService))
                .As<IImportService<List<PaymentDocumentImport>>>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExportService))
                .As<IExportService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(SearchService))
                .As<ISearchService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(CalculationService))
                .As<ICalculationService>()
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(ExcelDataLoader))
                .Named<IDataLoader>(LoaderType.Excel.ToString())
                .InstancePerLifetimeScope();

            container.RegisterType(typeof(HtmlLoadService))
                .Named<IDataLoader>(LoaderType.Html.ToString())
                .InstancePerLifetimeScope();

            var backupSettings = new BackupSettings()
            {
                BackupFolder = ConfigurationManager.AppSettings["BackupFolder"],
                ConnectionString = connectionString,
                DatabaseName = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["ConnectionName"]].Name,
            };

            container.RegisterInstance(backupSettings).SingleInstance();
            container.RegisterType<BackupService>().As<IBackupService>().SingleInstance();

            return container.Build();
        }
    }
}