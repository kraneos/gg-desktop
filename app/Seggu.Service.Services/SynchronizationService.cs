using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

        public static void Initialize()
        {
            //InitializeParseClasses();
            //Mapper.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? Guid.Empty : new Guid((string)x.SourceValue));
            //Mapper.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? null : (Guid?)new Guid((string)x.SourceValue));

            //Mapper.CreateMap<Guid, string>().ConvertUsing(x => (Guid)x.SourceValue == Guid.Empty ? null : x.SourceValue.ToString());
            //Mapper.CreateMap<Guid?, string>().ConvertUsing(x => (Guid?)x.SourceValue == null ? null : ((Guid?)x.SourceValue).Value.ToString());
            Mapper.CreateMap<decimal, double>().ConvertUsing(x => Convert.ToDouble(x.SourceValue));
            Mapper.CreateMap<double, decimal>().ConvertUsing(x => Convert.ToDecimal(x.SourceValue));
            Mapper.CreateMap<decimal?, double?>().ConvertUsing(x => x.SourceValue == null ? null : (double?)Convert.ToDouble(x.SourceValue));
            Mapper.CreateMap<double?, decimal?>().ConvertUsing(x => x.SourceValue == null ? null : (decimal?)Convert.ToDecimal(x.SourceValue));

            Mapper.CreateMap<Domain.AccessoryType, AccessoryTypeVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<AccessoryTypeVM, AccessoryType>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Asset, AssetVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<AssetVM, Domain.Asset>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Bank, BankVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<BankVM, Domain.Bank>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Bodywork, BodyworkVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<BodyworkVM, Domain.Bodywork>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Brand, BrandVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<BrandVM, Domain.Brand>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.CasualtyType, CasualtyTypeVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<CasualtyTypeVM, Domain.CasualtyType>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Client, ClientVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<ClientVM, Domain.Client>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Company, CompanyVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<CompanyVM, Domain.Company>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.CreditCard, CreditCardVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<CreditCardVM, Domain.CreditCard>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.LedgerAccount, LedgerAccountVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<LedgerAccountVM, Domain.LedgerAccount>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Producer, ProducerVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<ProducerVM, Domain.Producer>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Province, ProvinceVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<ProvinceVM, Domain.Province>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Use, UseVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<UseVM, Domain.Use>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.VehicleType, VehicleTypeVM>().GetCommonMappingExpressionToVM();
            Mapper.CreateMap<VehicleTypeVM, Domain.VehicleType>().GetCommonMappingExpressionToEntity();

            Mapper.CreateMap<Domain.Cheque, ChequeVM>().GetCommonMappingExpressionToVM()
                .ForMember(x => x.Bank, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<BankVM>(x.Bank.ObjectId)));
            Mapper.CreateMap<ChequeVM, Domain.Cheque>().GetCommonMappingExpressionToEntity()
                .ForMember(x=>x.Bank, y=>y.Ignore())
                .ForMember(x => x.BankId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Banks.First(x => x.ObjectId == ((ChequeVM)res.Value).Bank.ObjectId).Id)));

            Mapper.CreateMap<Domain.Contact, ContactVM>().GetCommonMappingExpressionToVM()
                .ForMember(x => x.Company,
                    y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<CompanyVM>(x.Company.ObjectId)));
            Mapper.CreateMap<ContactVM, Domain.Contact>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Company, y => y.Ignore())
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Companies.First(x => x.ObjectId == ((ContactVM)res.Value).Company.ObjectId).Id)));

            Mapper.CreateMap<Domain.Liquidation, LiquidationVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Company, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<CompanyVM>(x.Company.ObjectId)));
            Mapper.CreateMap<LiquidationVM, Domain.Liquidation>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Company, y => y.Ignore())
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Companies.First(x => x.ObjectId == ((LiquidationVM)res.Value).Company.ObjectId).Id)));

            //Mapper.CreateMap<Domain.ProducerCode, ProducerCodeVM>().GetCommonMappingExpressionToVM()
            //    .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId))
            //    .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer.ObjectId));
            //Mapper.CreateMap<ProducerCodeVM, Domain.ProducerCode>()
            //    .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)))
            //    .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)));

            Mapper.CreateMap<Domain.District, DistrictVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Province, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<ProvinceVM>(x.Province.ObjectId)));
            Mapper.CreateMap<DistrictVM, Domain.District>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Province, y => y.Ignore())
                .ForMember(x => x.ProvinceId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Provinces.First(x => x.ObjectId == ((DistrictVM)res.Value).Province.ObjectId).Id)));

            Mapper.CreateMap<Domain.Locality, LocalityVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.District, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<DistrictVM>(x.District.ObjectId)));
            Mapper.CreateMap<LocalityVM, Domain.Locality>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.District, y => y.Ignore())
                .ForMember(x => x.DistrictId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Districts.First(x => x.ObjectId == ((LocalityVM)res.Value).District.ObjectId).Id)));

            Mapper.CreateMap<Domain.Risk, RiskVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Company, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<CompanyVM>(x.Company.ObjectId)));
            Mapper.CreateMap<RiskVM, Domain.Risk>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Company, y => y.Ignore())
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Companies.First(x => x.ObjectId == ((RiskVM)res.Value).Company.ObjectId).Id)));

            Mapper.CreateMap<Domain.VehicleModel, VehicleModelVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Brand, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<BrandVM>(x.Brand.ObjectId)))
                .ForMember(x => x.VehicleType, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<VehicleTypeVM>(x.VehicleType.ObjectId)));
            Mapper.CreateMap<VehicleModelVM, Domain.VehicleModel>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Brand, y => y.Ignore())
                .ForMember(x => x.VehicleType, y => y.Ignore())
                .ForMember(x => x.BrandId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Brands.First(x => x.ObjectId == ((VehicleModelVM)res.Value).Brand.ObjectId).Id)))
                .ForMember(x => x.VehicleTypeId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.VehicleTypes.First(x => x.ObjectId == ((VehicleModelVM)res.Value).VehicleType.ObjectId).Id)));

            Mapper.CreateMap<Domain.Policy, PolicyVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Client, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<ClientVM>(x.Client.ObjectId)))
                .ForMember(x => x.Collector, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<ProducerVM>(x.Collector.ObjectId)))
                .ForMember(x => x.Producer, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<ProducerVM>(x.Producer.ObjectId)))
                .ForMember(x => x.Risk, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<RiskVM>(x.Risk.ObjectId)));
            Mapper.CreateMap<PolicyVM, Domain.Policy>().GetCommonMappingExpressionToEntity()
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

            Mapper.CreateMap<Domain.Endorse, EndorseVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Client, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<ClientVM>(x.Client.ObjectId)))
                .ForMember(x => x.Policy, y => y.MapFrom(x => AutoMapperExtensions.GetParseObject<PolicyVM>(x.Policy.ObjectId)));
            Mapper.CreateMap<EndorseVM, Domain.Endorse>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Client, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.ClientId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Clients.First(x => x.ObjectId == ((EndorseVM)res.Value).Client.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((EndorseVM)res.Value).Policy.ObjectId).Id)));

            Mapper.CreateMap<Domain.Employee, EmployeeVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Endorse, y => y.MapFrom(x => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(x.Endorse.ObjectId)))
                .ForMember(x => x.Policy, y => y.MapFrom(x => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(x.Policy.ObjectId)));
            Mapper.CreateMap<EmployeeVM, Domain.Employee>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((EmployeeVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((EmployeeVM)res.Value).Policy.ObjectId).Id)));

            Mapper.CreateMap<Domain.FeeSelection, FeeSelectionVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Liquidation, y => y.MapFrom(x => x.Liquidation == null ? null : AutoMapperExtensions.GetParseObject<LiquidationVM>(x.Liquidation.ObjectId)));
            Mapper.CreateMap<FeeSelectionVM, Domain.FeeSelection>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Liquidation, y => y.Ignore())
                .ForMember(x => x.LiquidationId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Liquidations.First(x => x.ObjectId == ((FeeSelectionVM)res.Value).Liquidation.ObjectId).Id)));

            Mapper.CreateMap<Domain.Fee, FeeVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Endorse, y => y.MapFrom(x => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(x.Endorse.ObjectId)))
                .ForMember(x => x.FeeSelection, y => y.MapFrom(x => x.FeeSelection == null ? null : AutoMapperExtensions.GetParseObject<FeeSelectionVM>(x.FeeSelection.ObjectId)))
                .ForMember(x => x.Policy, y => y.MapFrom(x => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(x.Policy.ObjectId)));
            Mapper.CreateMap<FeeVM, Domain.Fee>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.FeeSelection, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((FeeVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.FeeSelectionId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.FeeSelections.First(x => x.ObjectId == ((FeeVM)res.Value).FeeSelection.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((FeeVM)res.Value).Policy.ObjectId).Id)));

            Mapper.CreateMap<Domain.Vehicle, VehicleVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Endorse, y => y.MapFrom(x => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(x.Endorse.ObjectId)))
                .ForMember(x => x.Bodywork, y => y.MapFrom(x => x.Bodywork == null ? null : AutoMapperExtensions.GetParseObject<BodyworkVM>(x.Bodywork.ObjectId)))
                .ForMember(x => x.Use, y => y.MapFrom(x => x.Use == null ? null : AutoMapperExtensions.GetParseObject<UseVM>(x.Use.ObjectId)))
                .ForMember(x => x.VehicleModel, y => y.MapFrom(x => x.VehicleModel == null ? null : AutoMapperExtensions.GetParseObject<VehicleModelVM>(x.VehicleModel.ObjectId)))
                .ForMember(x => x.Policy, y => y.MapFrom(x => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(x.Policy.ObjectId)));
            Mapper.CreateMap<VehicleVM, Domain.Vehicle>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.Bodywork, y => y.Ignore())
                .ForMember(x => x.Use, y => y.Ignore())
                .ForMember(x => x.VehicleModel, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((VehicleVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.BodyworkId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Bodyworks.First(x => x.ObjectId == ((VehicleVM)res.Value).Bodywork.ObjectId).Id)))
                .ForMember(x => x.UseId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Uses.First(x => x.ObjectId == ((VehicleVM)res.Value).Use.ObjectId).Id)))
                .ForMember(x => x.VehicleModelId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.VehicleModels.First(x => x.ObjectId == ((VehicleVM)res.Value).VehicleModel.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((VehicleVM)res.Value).Policy.ObjectId).Id)));

            Mapper.CreateMap<Domain.Accessory, AccessoryVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.AccessoryType, y => y.MapFrom(x => x.AccessoryType == null ? null : AutoMapperExtensions.GetParseObject<AccessoryTypeVM>(x.AccessoryType.ObjectId)))
                .ForMember(x => x.Vehicle, y => y.MapFrom(x => x.Vehicle == null ? null : AutoMapperExtensions.GetParseObject<VehicleVM>(x.Vehicle.ObjectId)));
            Mapper.CreateMap<AccessoryVM, Domain.Accessory>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.AccessoryType, y => y.Ignore())
                .ForMember(x => x.Vehicle, y => y.Ignore())
                .ForMember(x => x.AccessoryTypeId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.AccessoryTypes.First(x => x.ObjectId == ((AccessoryVM)res.Value).AccessoryType.ObjectId).Id)))
                .ForMember(x => x.VehicleId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Vehicles.First(x => x.ObjectId == ((AccessoryVM)res.Value).Vehicle.ObjectId).Id)));

            Mapper.CreateMap<Domain.Integral, IntegralVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Endorse, y => y.MapFrom(x => x.Endorse == null ? null : AutoMapperExtensions.GetParseObject<EndorseVM>(x.Endorse.ObjectId)))
                .ForMember(x => x.Policy, y => y.MapFrom(x => x.Policy == null ? null : AutoMapperExtensions.GetParseObject<PolicyVM>(x.Policy.ObjectId)));
            Mapper.CreateMap<IntegralVM, Domain.Integral>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Endorse, y => y.Ignore())
                .ForMember(x => x.Policy, y => y.Ignore())
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Endorses.First(x => x.ObjectId == ((IntegralVM)res.Value).Endorse.ObjectId).Id)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Policies.First(x => x.ObjectId == ((IntegralVM)res.Value).Policy.ObjectId).Id)));

            Mapper.CreateMap<Domain.Address, AddressVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Client, y => y.MapFrom(x => x.Client == null ? null : AutoMapperExtensions.GetParseObject<ClientVM>(x.Client.ObjectId)))
                .ForMember(x => x.Locality, y => y.MapFrom(x => x.Locality == null ? null : AutoMapperExtensions.GetParseObject<LocalityVM>(x.Locality.ObjectId)));
            Mapper.CreateMap<AddressVM, Domain.Address>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Client, y => y.Ignore())
                .ForMember(x => x.Locality, y => y.Ignore())
                .ForMember(x => x.ClientId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Clients.First(x => x.ObjectId == ((AddressVM)res.Value).Client.ObjectId).Id)))
                .ForMember(x => x.LocalityId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Localities.First(x => x.ObjectId == ((AddressVM)res.Value).Locality.ObjectId).Id)));

            Mapper.CreateMap<Domain.CashAccount, CashAccountVM>()
                .GetCommonMappingExpressionToVM()
                .ForMember(x => x.Asset, y => y.MapFrom(x => x.Asset == null ? null : AutoMapperExtensions.GetParseObject<AssetVM>(x.Asset.ObjectId)))
                .ForMember(x => x.Fee, y => y.MapFrom(x => x.Fee == null ? null : AutoMapperExtensions.GetParseObject<FeeVM>(x.Fee.ObjectId)))
                .ForMember(x => x.Producer, y => y.MapFrom(x => x.Producer == null ? null : AutoMapperExtensions.GetParseObject<ProducerVM>(x.Producer.ObjectId)))
                .ForMember(x => x.LedgerAccount, y => y.MapFrom(x => x.LedgerAccount == null ? null : AutoMapperExtensions.GetParseObject<LedgerAccountVM>(x.LedgerAccount.ObjectId)));
            Mapper.CreateMap<CashAccountVM, Domain.CashAccount>().GetCommonMappingExpressionToEntity()
                .ForMember(x => x.Asset, y => y.Ignore())
                .ForMember(x => x.Fee, y => y.Ignore())
                .ForMember(x => x.Producer, y => y.Ignore())
                .ForMember(x => x.LedgerAccount, y => y.Ignore())
                .ForMember(x => x.AssetId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Assets.First(x => x.ObjectId == ((CashAccountVM)res.Value).Asset.ObjectId).Id)))
                .ForMember(x => x.FeeId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Fees.First(x => x.ObjectId == ((CashAccountVM)res.Value).Fee.ObjectId).Id)))
                .ForMember(x => x.ProducerId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.Producers.First(x => x.ObjectId == ((CashAccountVM)res.Value).Producer.ObjectId).Id)))
                .ForMember(x => x.LedgerAccountId, y => y.ResolveUsing(
                    resolution => resolution.Value == null ? null : AutoMapperExtensions.ResolveWithOptions(resolution, (ctx, sett, meth, res) => ctx.LedgerAccounts.First(x => x.ObjectId == ((CashAccountVM)res.Value).LedgerAccount.ObjectId).Id)));
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
            ////// TODO: SendEntitiesToParse<ProducerCode, ProducerCodeVM>("ProducerCodes");
            // TODO: The rest...

        }

        public void SynchronizeParseEntities()
        {
            if (ParseUser.CurrentUser != null)
            {
                SendEntitiesToParse<Domain.AccessoryType, AccessoryTypeVM>();// "AccessoryType");
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
