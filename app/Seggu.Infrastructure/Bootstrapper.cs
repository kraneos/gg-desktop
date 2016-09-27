using Microsoft.Practices.Unity;
using Seggu.Daos;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Service.Services;
using Seggu.Service.Services.Interfaces;
using Seggu.Services;
using Seggu.Services.Interfaces;
using Seggu.VersionManager.Interfaces;
using System;
using System.Configuration;
using System.Data.Common;

namespace Seggu.Infrastructure
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);
            RegisterDbContext(container);

            return container;
        }


        internal static IUnityContainer InitialisePerThread()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);
            RegisterDbContextPerThread(container);

            return container;
        }

        private static void RegisterDbContextPerThread(UnityContainer container)
        {
            var connectionString = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "seggu.sqlite";

            // Entity Framework Context
            container.RegisterType<SegguDataModelContext>(new PerThreadLifetimeManager(), new InjectionConstructor(connectionString));
        }

        private static void RegisterDbContext(IUnityContainer container)
        {
            var connectionString = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "seggu.sqlite";

            // Entity Framework Context
            container.RegisterType<SegguDataModelContext>(new PerResolveLifetimeManager(), new InjectionConstructor(connectionString));
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // Services
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<ICoverageService, CoverageService>();
            container.RegisterType<IBankService, BankService>();
            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<IPolicyService, PolicyService>();
            container.RegisterType<IProducerService, ProducerService>();
            container.RegisterType<IMasterDataService, MasterDataService>();
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<ILocalityService, LocalityService>();
            container.RegisterType<IVehicleTypeService, VehicleTypeService>();
            container.RegisterType<IContactService, ContactService>();
            container.RegisterType<IRiskService, RiskService>();
            container.RegisterType<IAssetService, AssetService>();
            container.RegisterType<ILedgerAccountService, LedgerAccountService>();
            container.RegisterType<ICashAccountService, CashAccountService>();
            container.RegisterType<IFeeService, FeeService>();
            container.RegisterType<IVehicleService, VehicleService>();
            container.RegisterType<IBodyworkService, BodyworkService>();
            container.RegisterType<IUseService, UseService>();
            container.RegisterType<IVehicleModelService, VehicleModelService>();
            container.RegisterType<ILiquidationService, LiquidationService>();
            container.RegisterType<IFeeSelectionService, FeeSelectionService>();
            container.RegisterType<IEndorseService, EndorseService>();
            container.RegisterType<ICasualtyService, CasualtyService>();
            container.RegisterType<ICasualtyTypeService, CasualtyTypeService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<ICollectionService, CollectionService>();
            container.RegisterType<IAccessoryTypeService, AccessoryTypeService>();
            container.RegisterType<IAccessoryService, AccessoryService>();
            container.RegisterType<IPrintService, PrintService>();
            container.RegisterType<IAttachedFileService, AttachedFileService>();
            container.RegisterType<ICoveragesPackService, CoveragesPackService>();
            container.RegisterType<IVersionService, VersionService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IEmailService, EmailService>();
            // Daos
            container.RegisterType<IAddressDao, AddressDao>();
            container.RegisterType<IClientDao, ClientDao>();
            container.RegisterType<ICompanyDao, CompanyDao>();
            container.RegisterType<ICoverageDao, CoverageDao>();
            container.RegisterType<IBankDao, BankDao>();
            container.RegisterType<IBrandDao, BrandDao>();
            container.RegisterType<IPolicyDao, PolicyDao>();
            container.RegisterType<IProducerDao, ProducerDao>();
            container.RegisterType<IDistrictDao, DistrictDao>();
            container.RegisterType<IProvinceDao, ProvinceDao>();
            container.RegisterType<ILocalityDao, LocalityDao>();
            container.RegisterType<IVehicleTypeDao, VehicleTypeDao>();
            container.RegisterType<IContactDao, ContactDao>();
            container.RegisterType<IRiskDao, RiskDao>();
            container.RegisterType<IAssetDao, AssetDao>();
            container.RegisterType<ILedgerAccountDao, LedgerAccountDao>();
            container.RegisterType<ICashAccountDao, CashAccountDao>();
            container.RegisterType<IFeeDao, FeeDao>();
            container.RegisterType<IVehicleDao, VehicleDao>();
            container.RegisterType<IBodyworkDao, BodyworkDao>();
            container.RegisterType<IUseDao, UseDao>();
            container.RegisterType<IVehicleModelDao, VehicleModelDao>();
            container.RegisterType<ILiquidationDao, LiquidationDao>();
            container.RegisterType<IFeeSelectionDao, FeeSelectionDao>();
            container.RegisterType<IEndorseDao, EndorseDao>();
            container.RegisterType<ICasualtyDao, CasualtyDao>();
            container.RegisterType<ICasualtyTypeDao, CasualtyTypeDao>();
            container.RegisterType<IEmployeeDao, EmployeeDao>();
            container.RegisterType<IAccessoryTypeDao, AccessoryTypeDao>();
            container.RegisterType<IAccessoryDao, AccessoryDao>();
            container.RegisterType<IProducerCodeDao, ProducerCodeDao>();
            container.RegisterType<IAttachedFileDao, AttachedFileDao>();
            container.RegisterType<ICoveragesPackDao, CoveragesPackDao>();
            container.RegisterType<IIntegralDao, IntegralDao>();
            container.RegisterType<IImplementedVersionDao, ImplementedVersionDao>();
            container.RegisterType<ISettingsDao, SettingsDao>();

            // Service Services
            container.RegisterType<ISynchronizationService, SynchronizationService>();

            // Version Manager
            container.RegisterType<IVersionManager, VersionManager.VersionManager>();

        }
    }
}