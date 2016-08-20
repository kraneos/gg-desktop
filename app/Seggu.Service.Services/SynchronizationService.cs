using AutoMapper;
using AutoMapper.Mappers;
using Parse;
using Seggu.Data;
using Seggu.Domain;
using Seggu.Service.Services.Interfaces;
using Seggu.Service.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Seggu.Service.Services
{
    public class SynchronizationService : ISynchronizationService
    {
        private ParseClient client;
        private SegguDataModelContext context;
        private EventLog eventLog;
        private static MappingEngine innerMappingEngine = InitializeInternalMappingEngine();

        public SynchronizationService(SegguDataModelContext context, EventLog eventLog)
        {
            this.context = context;
            this.eventLog = eventLog;

            // ApiClient configuration.
            this.client = new ParseClient(context, eventLog);

            // JsonConvert Configuration
            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            //};
        }

        public static MappingEngine InitializeInternalMappingEngine()
        {
            var innerConfigurationStore = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            //InitializeParseClasses();
            //Mapper.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? Guid.Empty : new Guid((string)x.SourceValue));
            //Mapper.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? null : (Guid?)new Guid((string)x.SourceValue));

            //Mapper.CreateMap<Guid, string>().ConvertUsing(x => (Guid)x.SourceValue == Guid.Empty ? null : x.SourceValue.ToString());
            //Mapper.CreateMap<Guid?, string>().ConvertUsing(x => (Guid?)x.SourceValue == null ? null : ((Guid?)x.SourceValue).Value.ToString());
            innerConfigurationStore.CreateMap<decimal, double>().ConvertUsing(x => Convert.ToDouble(x.SourceValue));
            innerConfigurationStore.CreateMap<double, decimal>().ConvertUsing(x => Convert.ToDecimal(x.SourceValue));
            innerConfigurationStore.CreateMap<decimal?, double?>().ConvertUsing(x => x.SourceValue == null ? null : (double?)Convert.ToDouble(x.SourceValue));
            innerConfigurationStore.CreateMap<double?, decimal?>().ConvertUsing(x => x.SourceValue == null ? null : (decimal?)Convert.ToDecimal(x.SourceValue));

            innerConfigurationStore.CreateMap<Cheque, ChequeVM>().GetCommonMappingExpressionToVM()
                .ForMember(x => x.Bank, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<BankVM>(rr, ctx => (x.Bank?.ObjectId != null) ? x.Bank.ObjectId : AutoMapperExtensions.GetObjectId<Bank>(ctx, x.BankId))));

            innerConfigurationStore.CreateMap<Contact, ContactVM>().GetCommonMappingExpressionToVM()
                .ForMember(x => x.Company,
                    y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<CompanyVM>(rr, ctx => (x.Company?.ObjectId != null) ? x.Company.ObjectId : AutoMapperExtensions.GetObjectId<Company>(ctx, x.CompanyId.Value))));

            innerConfigurationStore.CreateMap<Liquidation, LiquidationVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Company, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<CompanyVM>(rr, ctx => (x.Company?.ObjectId != null) ? x.Company.ObjectId : AutoMapperExtensions.GetObjectId<Company>(ctx, x.CompanyId))));

            //innerConfigurationStore.CreateMap<ProducerCode, ProducerCodeVM>().GetCommonMappingExpressionToVM()
            //    .ForMember(x => x.CompanyId, y => y.ResolveUsing((rr, x) => x.Company.ObjectId))
            //    .ForMember(x => x.ProducerId, y => y.ResolveUsing((rr, x) => x.Producer.ObjectId));
            //innerConfigurationStore.CreateMap<ProducerCodeVM, ProducerCode>()
            //    .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)))
            //    .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)));

            innerConfigurationStore.CreateMap<District, DistrictVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Province, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<ProvinceVM>(rr, ctx => (x.Province?.ObjectId != null) ? x.Province.ObjectId : AutoMapperExtensions.GetObjectId<Province>(ctx, x.ProvinceId))));

            innerConfigurationStore.CreateMap<Locality, LocalityVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.District, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<DistrictVM>(rr, ctx => (x.District?.ObjectId != null) ? x.District.ObjectId : AutoMapperExtensions.GetObjectId<District>(ctx, x.DistrictId))));

            innerConfigurationStore.CreateMap<Risk, RiskVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Company, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<CompanyVM>(rr, ctx => (x.Company?.ObjectId != null) ? x.Company.ObjectId : AutoMapperExtensions.GetObjectId<Company>(ctx, x.CompanyId))));

            innerConfigurationStore.CreateMap<Coverage, CoverageVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Risk, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<RiskVM>(rr, ctx => (x.Risk?.ObjectId != null) ? x.Risk.ObjectId : AutoMapperExtensions.GetObjectId<Risk>(ctx, x.RiskId))));

            innerConfigurationStore.CreateMap<CoveragesPack, CoveragesPackVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Risk, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<RiskVM>(rr, ctx => (x.Risk?.ObjectId != null) ? x.Risk.ObjectId : AutoMapperExtensions.GetObjectId<Risk>(ctx, x.RiskId))));

            innerConfigurationStore.CreateMap<VehicleModel, VehicleModelVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Brand, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<BrandVM>(rr, ctx => (x.Brand?.ObjectId != null) ? x.Brand.ObjectId : AutoMapperExtensions.GetObjectId<Brand>(ctx, x.BrandId))))
                .ForMember(x => x.VehicleType, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<VehicleTypeVM>(rr, ctx => (x.VehicleType?.ObjectId != null) ? x.VehicleType.ObjectId : AutoMapperExtensions.GetObjectId<VehicleType>(ctx, x.VehicleTypeId))));

            innerConfigurationStore.CreateMap<Policy, PolicyVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Client, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<ClientVM>(rr, ctx => (x.Client?.ObjectId != null) ? x.Client.ObjectId : AutoMapperExtensions.GetObjectId<Client>(ctx, x.ClientId))))
                .ForMember(x => x.Collector, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<ProducerVM>(rr, ctx => (x.Collector?.ObjectId != null) ? x.Collector.ObjectId : AutoMapperExtensions.GetObjectId<Producer>(ctx, x.CollectorId.Value))))
                .ForMember(x => x.Producer, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<ProducerVM>(rr, ctx => (x.Producer?.ObjectId != null) ? x.Producer.ObjectId : AutoMapperExtensions.GetObjectId<Producer>(ctx, x.ProducerId))))
                .ForMember(x => x.Risk, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<RiskVM>(rr, ctx => (x.Risk?.ObjectId != null) ? x.Risk.ObjectId : AutoMapperExtensions.GetObjectId<Risk>(ctx, x.RiskId))));

            innerConfigurationStore.CreateMap<Endorse, EndorseVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Client, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<ClientVM>(rr, ctx => (x.Client?.ObjectId != null) ? x.Client.ObjectId : AutoMapperExtensions.GetObjectId<Client>(ctx, x.ClientId.Value))))
                .ForMember(x => x.Policy, y => y.ResolveUsing((rr, x) => AutoMapperExtensions.GetParseObject<PolicyVM>(rr, ctx => (x.Policy?.ObjectId != null) ? x.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, x.PolicyId))));

            innerConfigurationStore.CreateMap<Employee, EmployeeVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Endorse, y => y.ResolveUsing((rr, x) => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(rr, ctx => (x.Endorse?.ObjectId != null) ? x.Endorse.ObjectId : AutoMapperExtensions.GetObjectId<Endorse>(ctx, x.EndorseId.Value))))
                .ForMember(x => x.Policy, y => y.ResolveUsing((rr, x) => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(rr, ctx => (x.Policy?.ObjectId != null) ? x.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, x.PolicyId))));

            innerConfigurationStore.CreateMap<FeeSelection, FeeSelectionVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Liquidation, y => y.ResolveUsing((rr, x) => x.Liquidation == null ? null : AutoMapperExtensions.GetParseObject<LiquidationVM>(rr, ctx => (x.Liquidation?.ObjectId != null) ? x.Liquidation.ObjectId : AutoMapperExtensions.GetObjectId<Liquidation>(ctx, x.LiquidationId))));

            innerConfigurationStore.CreateMap<Fee, FeeVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Endorse, y => y.ResolveUsing((rr, x) => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(rr, ctx => (x.Endorse?.ObjectId != null) ? x.Endorse.ObjectId : AutoMapperExtensions.GetObjectId<Endorse>(ctx, x.EndorseId.Value))))
                .ForMember(x => x.FeeSelection, y => y.ResolveUsing((rr, x) => x.FeeSelection == null ? null : AutoMapperExtensions.GetParseObject<FeeSelectionVM>(rr, ctx => (x.FeeSelection?.ObjectId != null) ? x.FeeSelection.ObjectId : AutoMapperExtensions.GetObjectId<FeeSelection>(ctx, x.FeeSelectionId.Value))))
                .ForMember(x => x.Policy, y => y.ResolveUsing((rr, x) => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(rr, ctx => (x.Policy?.ObjectId != null) ? x.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, x.PolicyId))));

            innerConfigurationStore.CreateMap<Vehicle, VehicleVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Endorse, y => y.ResolveUsing((rr, x) => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(rr, ctx => (x.Endorse?.ObjectId != null) ? x.Endorse.ObjectId : AutoMapperExtensions.GetObjectId<Endorse>(ctx, x.EndorseId.Value))))
                .ForMember(x => x.Bodywork, y => y.ResolveUsing((rr, x) => x.Bodywork == null ? null : AutoMapperExtensions.GetParseObject<BodyworkVM>(rr, ctx => (x.Bodywork?.ObjectId != null) ? x.Bodywork.ObjectId : AutoMapperExtensions.GetObjectId<Bodywork>(ctx, x.BodyworkId))))
                .ForMember(x => x.Use, y => y.ResolveUsing((rr, x) => x.Use == null ? null : AutoMapperExtensions.GetParseObject<UseVM>(rr, ctx => (x.Use?.ObjectId != null) ? x.Use.ObjectId : AutoMapperExtensions.GetObjectId<Use>(ctx, x.UseId))))
                .ForMember(x => x.VehicleModel, y => y.ResolveUsing((rr, x) => x.VehicleModel == null ? null : AutoMapperExtensions.GetParseObject<VehicleModelVM>(rr, ctx => (x.VehicleModel?.ObjectId != null) ? x.VehicleModel.ObjectId : AutoMapperExtensions.GetObjectId<VehicleModel>(ctx, x.VehicleModelId))))
                .ForMember(x => x.Policy, y => y.ResolveUsing((rr, x) => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(rr, ctx => (x.Policy?.ObjectId != null) ? x.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, x.PolicyId))));

            innerConfigurationStore.CreateMap<Casualty, CasualtyVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Policy,
                    y =>
                        y.ResolveUsing(
                            (rr, x) =>
                                x.Policy == null
                                    ? null
                                    : AutoMapperExtensions.GetParseObject<PolicyVM>(rr,
                                        ctx =>
                                            x.Policy?.ObjectId ?? AutoMapperExtensions.GetObjectId<Policy>(ctx, x.PolicyId))))
                .ForMember(x => x.CasualtyType,
                    y =>
                        y.ResolveUsing(
                            (rr, x) =>
                                x.CasualtyType == null
                                    ? null
                                    : AutoMapperExtensions.GetParseObject<CasualtyTypeVM>(rr,
                                        ctx =>
                                            x.CasualtyType?.ObjectId ?? AutoMapperExtensions.GetObjectId<CasualtyType>(ctx, x.CasualtyTypeId))));

            innerConfigurationStore.CreateMap<AttachedFile, AttachedFileVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Policy, y => y.ResolveUsing((rr, x) => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(rr, ctx => (x.Policy?.ObjectId != null) ? x.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, x.PolicyId.Value))))
                .ForMember(x => x.Endorse, y => y.ResolveUsing((rr, x) => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(rr, ctx => (x.Endorse?.ObjectId != null) ? x.Endorse.ObjectId : AutoMapperExtensions.GetObjectId<Endorse>(ctx, x.EndorseId.Value))))
                .ForMember(x => x.Client, y => y.ResolveUsing((rr, x) => x.Client == null ? null : AutoMapperExtensions.GetParseObject<ClientVM>(rr, ctx => (x.Client?.ObjectId != null) ? x.Client.ObjectId : AutoMapperExtensions.GetObjectId<Client>(ctx, x.ClientId.Value))))
                .ForMember(x => x.Casualty, y => y.ResolveUsing((rr, x) => x.Casualty == null ? null : AutoMapperExtensions.GetParseObject<CasualtyVM>(rr, ctx => (x.Casualty?.ObjectId != null) ? x.Casualty.ObjectId : AutoMapperExtensions.GetObjectId<Casualty>(ctx, x.CasualtyId.Value))))
                .ForMember(x => x.CashAccount, y => y.ResolveUsing((rr, x) => x.CashAccount == null ? null : AutoMapperExtensions.GetParseObject<CashAccountVM>(rr, ctx => (x.CashAccount?.ObjectId != null) ? x.CashAccount.ObjectId : AutoMapperExtensions.GetObjectId<CashAccount>(ctx, x.CashAccountId.Value))));

            innerConfigurationStore.CreateMap<Accessory, AccessoryVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.AccessoryType, y => y.ResolveUsing((rr, x) => x.AccessoryType == null ? null : AutoMapperExtensions.GetParseObject<AccessoryTypeVM>(rr, ctx => (x.AccessoryType?.ObjectId != null) ? x.AccessoryType.ObjectId : AutoMapperExtensions.GetObjectId<AccessoryType>(ctx, x.AccessoryTypeId))))
                .ForMember(x => x.Vehicle, y => y.ResolveUsing((rr, x) => x.Vehicle == null ? null : AutoMapperExtensions.GetParseObject<VehicleVM>(rr, ctx => (x.Vehicle?.ObjectId != null) ? x.Vehicle.ObjectId : AutoMapperExtensions.GetObjectId<Vehicle>(ctx, x.VehicleId))));

            innerConfigurationStore.CreateMap<Integral, IntegralVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Endorse, y => y.ResolveUsing((rr, x) => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(rr, ctx => (x.Endorse?.ObjectId != null) ? x.Endorse.ObjectId : AutoMapperExtensions.GetObjectId<Endorse>(ctx, x.EndorseId.Value))))
                .ForMember(x => x.Policy, y => y.ResolveUsing((rr, x) => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(rr, ctx => (x.Policy?.ObjectId != null) ? x.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, x.PolicyId.Value))));

            innerConfigurationStore.CreateMap<Address, AddressVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Client, y => y.ResolveUsing((rr, x) => x.Client == null ? null : AutoMapperExtensions.GetParseObject<ClientVM>(rr, ctx => (x.Client?.ObjectId != null) ? x.Client.ObjectId : AutoMapperExtensions.GetObjectId<Client>(ctx, x.ClientId.Value))))
                .ForMember(x => x.Locality, y => y.ResolveUsing((rr, x) => x.Locality == null ? null : AutoMapperExtensions.GetParseObject<LocalityVM>(rr, ctx => (x.Locality?.ObjectId != null) ? x.Locality.ObjectId : AutoMapperExtensions.GetObjectId<Locality>(ctx, x.LocalityId.Value))));

            innerConfigurationStore.CreateMap<CashAccount, CashAccountVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Asset, y => y.ResolveUsing((rr, x) => x.Asset == null ? null : AutoMapperExtensions.GetParseObject<AssetVM>(rr, ctx => (x.Asset?.ObjectId != null) ? x.Asset.ObjectId : AutoMapperExtensions.GetObjectId<Asset>(ctx, x.AssetId))))
                .ForMember(x => x.Fee, y => y.ResolveUsing((rr, x) => x.Fee == null ? null : AutoMapperExtensions.GetParseObject<FeeVM>(rr, ctx => (x.Fee?.ObjectId != null) ? x.Fee.ObjectId : AutoMapperExtensions.GetObjectId<Fee>(ctx, x.FeeId.Value))))
                .ForMember(x => x.Producer, y => y.ResolveUsing((rr, x) => x.Producer == null ? null : AutoMapperExtensions.GetParseObject<ProducerVM>(rr, ctx => (x.Producer?.ObjectId != null) ? x.Producer.ObjectId : AutoMapperExtensions.GetObjectId<Producer>(ctx, x.ProducerId))))
                .ForMember(x => x.LedgerAccount, y => y.ResolveUsing((rr, x) => x.LedgerAccount == null ? null : AutoMapperExtensions.GetParseObject<LedgerAccountVM>(rr, ctx => (x.LedgerAccount?.ObjectId != null) ? x.LedgerAccount.ObjectId : AutoMapperExtensions.GetObjectId<LedgerAccount>(ctx, x.LedgerAccountId))));

            var internalMappingEngine = new MappingEngine(innerConfigurationStore);
            return internalMappingEngine;
        }

        public static void Initialize()
        {
            Mapper.CreateMap<decimal, double>().ConvertUsing(x => Convert.ToDouble(x.SourceValue));
            Mapper.CreateMap<double, decimal>().ConvertUsing(x => Convert.ToDecimal(x.SourceValue));
            Mapper.CreateMap<decimal?, double?>().ConvertUsing(x => x.SourceValue == null ? null : (double?)Convert.ToDouble(x.SourceValue));
            Mapper.CreateMap<double?, decimal?>().ConvertUsing(x => x.SourceValue == null ? null : (decimal?)Convert.ToDecimal(x.SourceValue));

            Mapper.CreateMap<AccessoryType, AccessoryTypeVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<AccessoryTypeVM, AccessoryType>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<AccessoryType, AccessoryType>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Asset, AssetVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<AssetVM, Asset>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Asset, Asset>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Bank, BankVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<BankVM, Bank>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Bank, Bank>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Bodywork, BodyworkVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<BodyworkVM, Bodywork>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Bodywork, Bodywork>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Brand, BrandVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<BrandVM, Brand>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Brand, Brand>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<CasualtyType, CasualtyTypeVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<CasualtyTypeVM, CasualtyType>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<CasualtyType, CasualtyType>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Client, ClientVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<ClientVM, Client>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Client, Client>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Company, CompanyVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<CompanyVM, Company>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Company, Company>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<CreditCard, CreditCardVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<CreditCardVM, CreditCard>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<CreditCard, CreditCard>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<LedgerAccount, LedgerAccountVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<LedgerAccountVM, LedgerAccount>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<LedgerAccount, LedgerAccount>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Producer, ProducerVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<ProducerVM, Producer>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Producer, Producer>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Province, ProvinceVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<ProvinceVM, Province>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Province, Province>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Use, UseVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<UseVM, Use>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<Use, Use>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<VehicleType, VehicleTypeVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<VehicleTypeVM, VehicleType>().GetCommonMappingExpressionToEntity();
            Mapper.CreateMap<VehicleType, VehicleType>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Cheque, ChequeVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Cheque, ChequeVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Bank?.ObjectId != null) ? entity.Bank.ObjectId : AutoMapperExtensions.GetObjectId<Bank>(ctx, entity.BankId)));
            Mapper.CreateMap<ChequeVM, Cheque>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Bank, y => y.Ignore())
                .ForMember(x => x.BankId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Banks.First(x => x.ObjectId == ((ChequeVM)res.Value).Bank.ObjectId).Id)));
            Mapper.CreateMap<Cheque, Cheque>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Contact, ContactVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Contact, ContactVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Company?.ObjectId != null) ? entity.Company.ObjectId : AutoMapperExtensions.GetObjectId<Company>(ctx, entity.CompanyId.Value)));
            Mapper.CreateMap<ContactVM, Contact>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Company, y => y.Ignore())
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Companies.First(x => x.ObjectId == ((ContactVM)res.Value).Company.ObjectId).Id)));
            Mapper.CreateMap<Contact, Contact>().GetCommonMappingExpressionEntityToEntity();


            Mapper.CreateMap<Liquidation, LiquidationVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Liquidation, LiquidationVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Company?.ObjectId != null) ? entity.Company.ObjectId : AutoMapperExtensions.GetObjectId<Company>(ctx, entity.CompanyId)));
            Mapper.CreateMap<LiquidationVM, Liquidation>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Company, y => y.Ignore())
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Companies.First(x => x.ObjectId == ((LiquidationVM)res.Value).Company.ObjectId).Id)));
            Mapper.CreateMap<Liquidation, Liquidation>().GetCommonMappingExpressionEntityToEntity();

            //Mapper.CreateMap<ProducerCode, ProducerCodeVM>()
            //    .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId))
            //    .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer.ObjectId));
            //Mapper.CreateMap<ProducerCodeVM, ProducerCode>()
            //    .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)))
            //    .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)));

            Mapper.CreateMap<District, DistrictVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<District, DistrictVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Province?.ObjectId != null) ? entity.Province.ObjectId : AutoMapperExtensions.GetObjectId<Province>(ctx, entity.ProvinceId)));
            Mapper.CreateMap<DistrictVM, District>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Province, y => y.Ignore())
                .ForMember(x => x.ProvinceId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Provinces.First(x => x.ObjectId == ((DistrictVM)res.Value).Province.ObjectId).Id)));
            Mapper.CreateMap<District, District>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Locality, LocalityVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Locality, LocalityVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.District?.ObjectId != null) ? entity.District.ObjectId : AutoMapperExtensions.GetObjectId<District>(ctx, entity.DistrictId)));
            Mapper.CreateMap<LocalityVM, Locality>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.District, y => y.Ignore())
                .ForMember(x => x.DistrictId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Districts.First(x => x.ObjectId == ((LocalityVM)res.Value).District.ObjectId).Id)));
            Mapper.CreateMap<Locality, Locality>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Risk, RiskVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Risk, RiskVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Company?.ObjectId != null) ? entity.Company.ObjectId : AutoMapperExtensions.GetObjectId<Company>(ctx, entity.CompanyId)));
            Mapper.CreateMap<RiskVM, Risk>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Company, y => y.Ignore())
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Companies.First(x => x.ObjectId == ((RiskVM)res.Value).Company.ObjectId).Id)));
            Mapper.CreateMap<Risk, Risk>().GetCommonMappingExpressionEntityToEntity();


            Mapper.CreateMap<Coverage, CoverageVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Coverage, CoverageVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Risk?.ObjectId != null) ? entity.Risk.ObjectId : AutoMapperExtensions.GetObjectId<Risk>(ctx, entity.RiskId)));
            Mapper.CreateMap<CoverageVM, Coverage>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Risk, y => y.Ignore())
                .ForMember(x => x.RiskId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Risks.First(x => x.ObjectId == ((CoverageVM)res.Value).Risk.ObjectId).Id)));
            Mapper.CreateMap<Coverage, Coverage>().GetCommonMappingExpressionEntityToEntity();


            Mapper.CreateMap<CoveragesPack, CoveragesPackVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<CoveragesPack, CoveragesPackVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Risk?.ObjectId != null) ? entity.Risk.ObjectId : AutoMapperExtensions.GetObjectId<Risk>(ctx, entity.RiskId)));
            Mapper.CreateMap<CoveragesPackVM, CoveragesPack>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Risk, y => y.Ignore())
                .ForMember(x => x.RiskId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Risks.First(x => x.ObjectId == ((CoveragesPackVM)res.Value).Risk.ObjectId).Id)));
            Mapper.CreateMap<CoveragesPack, CoveragesPack>().GetCommonMappingExpressionEntityToEntity();


            Mapper.CreateMap<VehicleModel, VehicleModelVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<VehicleModel, VehicleModelVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Brand?.ObjectId != null) ? entity.Brand.ObjectId : AutoMapperExtensions.GetObjectId<Brand>(ctx, entity.BrandId),
                            (ctx, entity) => (entity.VehicleType?.ObjectId != null) ? entity.VehicleType.ObjectId : AutoMapperExtensions.GetObjectId<VehicleType>(ctx, entity.VehicleTypeId)));
            Mapper.CreateMap<VehicleModelVM, VehicleModel>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Brand, y => y.Ignore())
                .ForMember(x => x.VehicleType, y => y.Ignore())
                .ForMember(x => x.BrandId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Brands.First(x => x.ObjectId == ((VehicleModelVM)res.Value).Brand.ObjectId).Id)))
                .ForMember(x => x.VehicleTypeId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.VehicleTypes.First(x => x.ObjectId == ((VehicleModelVM)res.Value).VehicleType.ObjectId).Id)));
            Mapper.CreateMap<VehicleModel, VehicleModel>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Policy, PolicyVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Policy, PolicyVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Client?.ObjectId != null) ? entity.Client.ObjectId : AutoMapperExtensions.GetObjectId<Client>(ctx, entity.ClientId),
                            (ctx, entity) => (entity.Collector?.ObjectId != null) ? entity.Collector.ObjectId : AutoMapperExtensions.GetObjectId<Producer>(ctx, entity.CollectorId.Value),
                            (ctx, entity) => (entity.Producer?.ObjectId != null) ? entity.Producer.ObjectId : AutoMapperExtensions.GetObjectId<Producer>(ctx, entity.ProducerId)));
            Mapper.CreateMap<PolicyVM, Policy>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Client, y => y.Ignore())
                .ForMember(x => x.Collector, y => y.Ignore())
                .ForMember(x => x.Producer, y => y.Ignore())
                .ForMember(x => x.Risk, y => y.Ignore())
                .ForMember(x => x.ClientId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Clients.First(x => x.ObjectId == ((PolicyVM)res.Value).Client.ObjectId).Id)))
                .ForMember(x => x.CollectorId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Producers.First(x => x.ObjectId == ((PolicyVM)res.Value).Collector.ObjectId).Id)))
                .ForMember(x => x.ProducerId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Producers.First(x => x.ObjectId == ((PolicyVM)res.Value).Producer.ObjectId).Id)))
                .ForMember(x => x.RiskId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Risks.First(x => x.ObjectId == ((PolicyVM)res.Value).Risk.ObjectId).Id)));
            Mapper.CreateMap<Policy, Policy>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Endorse, EndorseVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Endorse, EndorseVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Policy?.ObjectId != null) ? entity.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, entity.PolicyId)));
            Mapper.CreateMap<EndorseVM, Endorse>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Client, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.ClientId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Clients.First(x => x.ObjectId == ((EndorseVM)res.Value).Client.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((EndorseVM)res.Value).Policy.ObjectId).Id)));
            Mapper.CreateMap<Endorse, Endorse>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Employee, EmployeeVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Employee, EmployeeVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Policy?.ObjectId != null) ? entity.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, entity.PolicyId)));
            Mapper.CreateMap<EmployeeVM, Employee>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => ((EmployeeVM)resolution.Value).Endorse == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((EmployeeVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => ((EmployeeVM)resolution.Value).Policy == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((EmployeeVM)res.Value).Policy.ObjectId).Id)));
            Mapper.CreateMap<Employee, Employee>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<FeeSelection, FeeSelectionVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<FeeSelection, FeeSelectionVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Liquidation?.ObjectId != null) ? entity.Liquidation.ObjectId : AutoMapperExtensions.GetObjectId<Liquidation>(ctx, entity.LiquidationId)));
            Mapper.CreateMap<FeeSelectionVM, FeeSelection>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Liquidation, y => y.Ignore())
                .ForMember(x => x.LiquidationId, y => y.ResolveUsing(
                    resolution => ((FeeSelectionVM)resolution.Value).Liquidation == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Liquidations.First(x => x.ObjectId == ((FeeSelectionVM)res.Value).Liquidation.ObjectId).Id)));
            Mapper.CreateMap<FeeSelection, FeeSelection>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Fee, FeeVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Fee, FeeVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Policy?.ObjectId != null) ? entity.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, entity.PolicyId)));
            Mapper.CreateMap<FeeVM, Fee>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.FeeSelection, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => ((FeeVM)resolution.Value).Endorse == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((FeeVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.FeeSelectionId, y => y.ResolveUsing(
                    resolution => ((FeeVM)resolution.Value).FeeSelection == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.FeeSelections.First(x => x.ObjectId == ((FeeVM)res.Value).FeeSelection.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => ((FeeVM)resolution.Value).Policy == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((FeeVM)res.Value).Policy.ObjectId).Id)));
            Mapper.CreateMap<Fee, Fee>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Vehicle, VehicleVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Vehicle, VehicleVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Policy?.ObjectId != null) ? entity.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, entity.PolicyId),
                            (ctx, entity) => (entity.Bodywork?.ObjectId != null) ? entity.Bodywork.ObjectId : AutoMapperExtensions.GetObjectId<Bodywork>(ctx, entity.BodyworkId),
                            (ctx, entity) => (entity.Use?.ObjectId != null) ? entity.Use.ObjectId : AutoMapperExtensions.GetObjectId<Use>(ctx, entity.UseId),
                            (ctx, entity) => (entity.VehicleModel?.ObjectId != null) ? entity.VehicleModel.ObjectId : AutoMapperExtensions.GetObjectId<VehicleModel>(ctx, entity.VehicleModelId)));
            Mapper.CreateMap<VehicleVM, Vehicle>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.Bodywork, y => y.Ignore())
                .ForMember(x => x.Use, y => y.Ignore())
                .ForMember(x => x.VehicleModel, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => ((VehicleVM)resolution.Value).Endorse == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((VehicleVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.BodyworkId, y => y.ResolveUsing(
                    resolution => ((VehicleVM)resolution.Value).Bodywork == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Bodyworks.First(x => x.ObjectId == ((VehicleVM)res.Value).Bodywork.ObjectId).Id)))
                .ForMember(x => x.UseId, y => y.ResolveUsing(
                    resolution => ((VehicleVM)resolution.Value).Use == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Uses.First(x => x.ObjectId == ((VehicleVM)res.Value).Use.ObjectId).Id)))
                .ForMember(x => x.VehicleModelId, y => y.ResolveUsing(
                    resolution => ((VehicleVM)resolution.Value).VehicleModel == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.VehicleModels.First(x => x.ObjectId == ((VehicleVM)res.Value).VehicleModel.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => ((VehicleVM)resolution.Value).Policy == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((VehicleVM)res.Value).Policy.ObjectId).Id)));
            Mapper.CreateMap<Vehicle, Vehicle>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Accessory, AccessoryVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Accessory, AccessoryVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Vehicle?.ObjectId != null) ? entity.Vehicle.ObjectId : AutoMapperExtensions.GetObjectId<Vehicle>(ctx, entity.VehicleId),
                            (ctx, entity) => (entity.AccessoryType?.ObjectId != null) ? entity.AccessoryType.ObjectId : AutoMapperExtensions.GetObjectId<AccessoryType>(ctx, entity.AccessoryTypeId)));
            Mapper.CreateMap<AccessoryVM, Accessory>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.AccessoryType, y => y.Ignore())
                .ForMember(x => x.Vehicle, y => y.Ignore())
                .ForMember(x => x.AccessoryTypeId, y => y.ResolveUsing(
                    resolution => ((AccessoryVM)resolution.Value).AccessoryType == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.AccessoryTypes.First(x => x.ObjectId == ((AccessoryVM)res.Value).AccessoryType.ObjectId).Id)))
                .ForMember(x => x.VehicleId, y => y.ResolveUsing(
                    resolution => ((AccessoryVM)resolution.Value).Vehicle == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Vehicles.First(x => x.ObjectId == ((AccessoryVM)res.Value).Vehicle.ObjectId).Id)));
            Mapper.CreateMap<Accessory, Accessory>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Integral, IntegralVM>()
                    .ConvertUsing((rc, e) => innerMappingEngine.Map<Integral, IntegralVM>(e, opts => AutoMapperExtensions.AssignOptions(rc, opts)));
            Mapper.CreateMap<IntegralVM, Integral>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => ((IntegralVM)resolution.Value).Endorse == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((IntegralVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => ((IntegralVM)resolution.Value).Policy == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((IntegralVM)res.Value).Policy.ObjectId).Id)));
            Mapper.CreateMap<Integral, Integral>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Address, AddressVM>()
                    .ConvertUsing((rc, e) => innerMappingEngine.Map<Address, AddressVM>(e, opts => AutoMapperExtensions.AssignOptions(rc, opts)));
            Mapper.CreateMap<AddressVM, Address>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Client, y => y.Ignore())
                .ForMember(x => x.Locality, y => y.Ignore())
                .ForMember(x => x.ClientId, y => y.ResolveUsing(
                    resolution => ((AddressVM)resolution.Value).Client == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Clients.First(x => x.ObjectId == ((AddressVM)res.Value).Client.ObjectId).Id)))
                .ForMember(x => x.LocalityId, y => y.ResolveUsing(
                    resolution => ((AddressVM)resolution.Value).Locality == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Localities.First(x => x.ObjectId == ((AddressVM)res.Value).Locality.ObjectId).Id)));
            Mapper.CreateMap<Address, Address>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<CashAccount, CashAccountVM>()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<CashAccount, CashAccountVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Asset?.ObjectId != null) ? entity.Asset.ObjectId : AutoMapperExtensions.GetObjectId<Asset>(ctx, entity.AssetId),
                            (ctx, entity) => (entity.Producer?.ObjectId != null) ? entity.Producer.ObjectId : AutoMapperExtensions.GetObjectId<Producer>(ctx, entity.ProducerId),
                            (ctx, entity) => (entity.LedgerAccount?.ObjectId != null) ? entity.LedgerAccount.ObjectId : AutoMapperExtensions.GetObjectId<LedgerAccount>(ctx, entity.LedgerAccountId)));
            Mapper.CreateMap<CashAccountVM, CashAccount>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Asset, y => y.Ignore())
                .ForMember(x => x.Fee, y => y.Ignore())
                .ForMember(x => x.Producer, y => y.Ignore())
                .ForMember(x => x.LedgerAccount, y => y.Ignore())
                .ForMember(x => x.AssetId, y => y.ResolveUsing(
                    resolution => ((CashAccountVM)resolution.Value).Asset == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Assets.First(x => x.ObjectId == ((CashAccountVM)res.Value).Asset.ObjectId).Id)))
                .ForMember(x => x.FeeId, y => y.ResolveUsing(
                    resolution => ((CashAccountVM)resolution.Value).Fee == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Fees.First(x => x.ObjectId == ((CashAccountVM)res.Value).Fee.ObjectId).Id)))
                .ForMember(x => x.ProducerId, y => y.ResolveUsing(
                    resolution => ((CashAccountVM)resolution.Value).Producer == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Producers.First(x => x.ObjectId == ((CashAccountVM)res.Value).Producer.ObjectId).Id)))
                .ForMember(x => x.LedgerAccountId, y => y.ResolveUsing(
                    resolution => ((CashAccountVM)resolution.Value).LedgerAccount == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.LedgerAccounts.First(x => x.ObjectId == ((CashAccountVM)res.Value).LedgerAccount.ObjectId).Id)));
            Mapper.CreateMap<CashAccount, CashAccount>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<Casualty, CasualtyVM>().GetCommonMappingExpressionToVM()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<Casualty, CasualtyVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) =>
                                (entity.Policy?.ObjectId != null)
                                    ? entity.Policy.ObjectId
                                    : AutoMapperExtensions.GetObjectId<Policy>(ctx, entity.PolicyId),
                            (ctx, entity) =>
                                (entity.CasualtyType?.ObjectId != null)
                                    ? entity.CasualtyType.ObjectId
                                    : AutoMapperExtensions.GetObjectId<CasualtyType>(ctx, entity.CasualtyTypeId)));

            Mapper.CreateMap<CasualtyVM, Casualty>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.CasualtyType, y => y.Ignore())
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution =>
                        ((CasualtyVM) resolution.Value).Policy == null
                            ? null
                            : AutoMapperExtensions.ResolveWithOptions(resolution,
                                (ctx, sett, meth, res) =>
                                    ctx.Policies.First(x => x.ObjectId == ((CasualtyVM) res.Value).Policy.ObjectId)
                                        .Id)))
                .ForMember(x => x.CasualtyTypeId, y => y.ResolveUsing(
                    resolution =>
                        ((CasualtyVM) resolution.Value).CasualtyType == null
                            ? null
                            : AutoMapperExtensions.ResolveWithOptions(resolution,
                                (ctx, sett, meth, res) =>
                                    ctx.CasualtyTypes.First(
                                        x => x.ObjectId == ((CasualtyVM) res.Value).CasualtyType.ObjectId).Id)));

            Mapper.CreateMap<Casualty, Casualty>().GetCommonMappingExpressionEntityToEntity();

            Mapper.CreateMap<AttachedFile, AttachedFileVM>().GetCommonMappingExpressionToVM()
                .ConvertUsing(
                    (rc, e) =>
                        AutoMapperExtensions.ValidateAndMap<AttachedFile, AttachedFileVM>(
                            rc,
                            e,
                            innerMappingEngine,
                            (ctx, entity) => (entity.Policy?.ObjectId != null) ? entity.Policy.ObjectId : AutoMapperExtensions.GetObjectId<Policy>(ctx, entity.PolicyId.Value),
                            (ctx, entity) => (entity.Endorse?.ObjectId != null) ? entity.Endorse.ObjectId : AutoMapperExtensions.GetObjectId<Endorse>(ctx, entity.EndorseId.Value),
                            (ctx, entity) => (entity.CashAccount?.ObjectId != null) ? entity.CashAccount.ObjectId : AutoMapperExtensions.GetObjectId<CashAccount>(ctx, entity.CashAccountId.Value), 
                            (ctx, entity) => (entity.Client?.ObjectId != null) ? entity.Client.ObjectId : AutoMapperExtensions.GetObjectId<Client>(ctx, entity.ClientId.Value),
                            (ctx, entity) => (entity.Casualty?.ObjectId != null) ? entity.Casualty.ObjectId : AutoMapperExtensions.GetObjectId<Casualty>(ctx, entity.CasualtyId.Value)));

            Mapper.CreateMap<AttachedFileVM, AttachedFile>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.CashAccount, y => y.Ignore())
                .ForMember(x => x.Client, y => y.Ignore())
                .ForMember(x => x.Casualty, y => y.Ignore())
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => ((AttachedFileVM)resolution.Value).Policy == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((AttachedFileVM)res.Value).Policy.ObjectId).Id)))
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => ((AttachedFileVM)resolution.Value).Endorse == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((AttachedFileVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.CasualtyId, y => y.ResolveUsing(
                    resolution => ((AttachedFileVM)resolution.Value).Casualty == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Casualties.First(x => x.ObjectId == ((AttachedFileVM)res.Value).Casualty.ObjectId).Id)))
                .ForMember(x => x.ClientId, y => y.ResolveUsing(
                    resolution => ((AttachedFileVM)resolution.Value).Client == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Clients.First(x => x.ObjectId == ((AttachedFileVM)res.Value).Client.ObjectId).Id)))
                .ForMember(x => x.CashAccountId, y => y.ResolveUsing(
                    resolution => ((AttachedFileVM)resolution.Value).CashAccount == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.CashAccounts.First(x => x.ObjectId == ((AttachedFileVM)res.Value).CashAccount.ObjectId).Id)));
            Mapper.CreateMap<AttachedFile, AttachedFile>().GetCommonMappingExpressionEntityToEntity();

        }

        public static void InitializeParseClasses()
        {
            ParseObject.RegisterSubclass<AccessoryTypeVM>();
            ParseObject.RegisterSubclass<AssetVM>();
            ParseObject.RegisterSubclass<BankVM>();
            ParseObject.RegisterSubclass<BodyworkVM>();
            ParseObject.RegisterSubclass<BrandVM>();
            ParseObject.RegisterSubclass<CasualtyTypeVM>();
            ParseObject.RegisterSubclass<ClientVM>();
            ParseObject.RegisterSubclass<CompanyVM>();
            ParseObject.RegisterSubclass<CreditCardVM>();
            ParseObject.RegisterSubclass<LedgerAccountVM>();
            ParseObject.RegisterSubclass<ProducerVM>();
            ParseObject.RegisterSubclass<ProvinceVM>();
            ParseObject.RegisterSubclass<UseVM>();
            ParseObject.RegisterSubclass<VehicleTypeVM>();
            ParseObject.RegisterSubclass<ChequeVM>();
            ParseObject.RegisterSubclass<ContactVM>();
            ParseObject.RegisterSubclass<LiquidationVM>();
            ParseObject.RegisterSubclass<DistrictVM>();
            ParseObject.RegisterSubclass<LocalityVM>();
            ParseObject.RegisterSubclass<RiskVM>();
            ParseObject.RegisterSubclass<CoverageVM>();
            ParseObject.RegisterSubclass<CoveragesPackVM>();
            ParseObject.RegisterSubclass<VehicleModelVM>();
            ParseObject.RegisterSubclass<PolicyVM>();
            ParseObject.RegisterSubclass<EndorseVM>();
            ParseObject.RegisterSubclass<EmployeeVM>();
            ParseObject.RegisterSubclass<FeeSelectionVM>();
            ParseObject.RegisterSubclass<FeeVM>();
            ParseObject.RegisterSubclass<VehicleVM>();
            ParseObject.RegisterSubclass<AccessoryVM>();
            ParseObject.RegisterSubclass<IntegralVM>();
            ParseObject.RegisterSubclass<AddressVM>();
            ParseObject.RegisterSubclass<CashAccountVM>();
            ParseObject.RegisterSubclass<CasualtyVM>();
            ParseObject.RegisterSubclass<AttachedFileVM>();
            ////// TODO: SendEntitiesToParse<ProducerCode, ProducerCodeVM>("ProducerCodes");
            // TODO: The rest...

        }

        public void SynchronizeParseEntities()
        {
            if (ParseUser.CurrentUser != null && client.HasSetting())
            {
                SendEntitiesToParse<AccessoryType, AccessoryTypeVM>();// "AccessoryType");
                SendEntitiesToParse<Asset, AssetVM>();//"Asset");
                SendEntitiesToParse<Bank, BankVM>();//"Bank");
                SendEntitiesToParse<Bodywork, BodyworkVM>();
                SendEntitiesToParse<Brand, BrandVM>();
                SendEntitiesToParse<CasualtyType, CasualtyTypeVM>();
                SendEntitiesToParse<Client, ClientVM>();
                SendEntitiesToParse<Company, CompanyVM>();
                SendEntitiesToParse<CreditCard, CreditCardVM>();
                SendEntitiesToParse<LedgerAccount, LedgerAccountVM>();
                SendEntitiesToParse<Producer, ProducerVM>();
                SendEntitiesToParse<Province, ProvinceVM>();
                SendEntitiesToParse<Use, UseVM>();
                SendEntitiesToParse<VehicleType, VehicleTypeVM>();
                SendEntitiesToParse<Cheque, ChequeVM>();
                SendEntitiesToParse<Contact, ContactVM>();
                SendEntitiesToParse<Liquidation, LiquidationVM>();
                // TODO: SendEntitiesToParse<ProducerCode, ProducerCodeVM>("ProducerCodes");
                SendEntitiesToParse<District, DistrictVM>();
                SendEntitiesToParse<Locality, LocalityVM>();
                SendEntitiesToParse<Risk, RiskVM>();
                SendEntitiesToParse<Coverage, CoverageVM>();
                SendEntitiesToParse<CoveragesPack, CoveragesPackVM>();
                SendEntitiesToParse<VehicleModel, VehicleModelVM>();
                SendEntitiesToParse<Policy, PolicyVM>();
                SendEntitiesToParse<Endorse, EndorseVM>();
                SendEntitiesToParse<Employee, EmployeeVM>();
                SendEntitiesToParse<FeeSelection, FeeSelectionVM>();
                SendEntitiesToParse<Fee, FeeVM>();
                SendEntitiesToParse<Vehicle, VehicleVM>();
                SendEntitiesToParse<Accessory, AccessoryVM>();
                SendEntitiesToParse<Integral, IntegralVM>();
                SendEntitiesToParse<Address, AddressVM>();
                SendEntitiesToParse<CashAccount, CashAccountVM>();
                SendEntitiesToParse<Casualty, CasualtyVM>();
                SendEntitiesToParse<AttachedFile, AttachedFileVM>();//"Asset");
                                                                    
                // TODO: The rest...

            }
        }

        public void SendEntitiesToParse<TParseEntity, TViewModel>()
            //string parseEntityName)
            where TParseEntity : IdParseEntity, new()
            where TViewModel : ViewModel
        {
            try
            {
                ApiToEntities<TParseEntity, TViewModel>().Wait(); //parseEntityName).Wait();
                EntitiesToApi<TParseEntity, TViewModel>().Wait(); //parseEntityName).Wait();
            }
            catch (ParseException ex)
            {
                if (ex.Code == ParseException.ErrorCode.ObjectNotFound)
                {
                    //TODO: Something.
                }

                this.eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
                WriteEntryInnerEx(ex);
            }
            catch (Exception ex)
            {
                this.eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
                WriteEntryInnerEx(ex);
            }
        }

        private async Task ApiToEntities<TParseEntity, TViewModel>()//string parseEntityName)
            where TParseEntity : IdParseEntity, new()
            where TViewModel : ViewModel
        {
            var className = typeof(TParseEntity).FullName;
            var lastSync = this.context.Synchronizations.FirstOrDefault(x => x.ClassName == className);
            var isNew = lastSync == null;
            if (isNew)
            {
                lastSync = new Synchronization { ClassName = className };
            }
            await this.client.GetManyEntities<TParseEntity, TViewModel>(lastSync);// parseEntityName, lastSync);
            if (isNew)
            {
                context.Synchronizations.Add(lastSync);
            }
            context.SaveChanges();
        }

        private async Task EntitiesToApi<TParseEntity, TViewModel>()//string parseEntityName)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            var newEntities = context.Set<TParseEntity>().Where(e => e.ObjectId == null).ToList();
            var updatedEntities = context.Set<TParseEntity>().Where(e => e.ObjectId != null && e.UpdatedAt < e.LocallyUpdatedAt).ToList();

            var parseCreatedEntities = await this.client.CreateEntities<TParseEntity, TViewModel>(newEntities);//, parseEntityName);
            var parseUpdatedEntities = await this.client.UpdateEntities<TParseEntity, TViewModel>(updatedEntities);//, parseEntityName);
        }

        private void WriteEntryInnerEx(Exception ex)
        {
            if (ex.InnerException != null)
            {
                this.eventLog.WriteEntry(ex.InnerException.Message, EventLogEntryType.Error);
                WriteEntryInnerEx(ex.InnerException);
            }
        }

        //public TViewModel Map<TEntity, TViewModel>(TEntity e)
        //{
        //    return Mapper.Map<TEntity, TViewModel>(e);
        //}
    }
}
