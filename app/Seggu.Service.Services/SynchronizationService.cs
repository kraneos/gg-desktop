using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Seggu.Data;
using Seggu.Domain;
using Seggu.Service.Services.Interfaces;
using Seggu.Service.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;

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
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public static void Initialize()
        {
            Mapper.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? Guid.Empty : new Guid((string)x.SourceValue));
            Mapper.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? null : (Guid?)new Guid((string)x.SourceValue));

            Mapper.CreateMap<Guid, string>().ConvertUsing(x => (Guid)x.SourceValue == Guid.Empty ? null : x.SourceValue.ToString());
            Mapper.CreateMap<Guid?, string>().ConvertUsing(x => (Guid?)x.SourceValue == null ? null : ((Guid?)x.SourceValue).Value.ToString());

            Mapper.CreateMap<Domain.AccessoryType, AccessoryTypeVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<AccessoryTypeVM, Domain.AccessoryType>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Asset, AssetVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<AssetVM, Domain.Asset>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Bank, BankVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<BankVM, Domain.Bank>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Bodywork, BodyworkVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<BodyworkVM, Domain.Bodywork>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Brand, BrandVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<BrandVM, Domain.Brand>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.CasualtyType, CasualtyTypeVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<CasualtyTypeVM, Domain.CasualtyType>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Client, ClientVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<ClientVM, Domain.Client>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Company, CompanyVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<CompanyVM, Domain.Company>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.CreditCard, CreditCardVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<CreditCardVM, Domain.CreditCard>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.LedgerAccount, LedgerAccountVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<LedgerAccountVM, Domain.LedgerAccount>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Producer, ProducerVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<ProducerVM, Domain.Producer>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Province, ProvinceVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<ProvinceVM, Domain.Province>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Use, UseVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<UseVM, Domain.Use>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.VehicleType, VehicleTypeVM>().ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId))).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<VehicleTypeVM, Domain.VehicleType>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()));

            Mapper.CreateMap<Domain.Cheque, ChequeVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.BankId, y => y.MapFrom(x => x.Bank.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<ChequeVM, Domain.Cheque>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.BankId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Banks.Find(res.Value)));

            Mapper.CreateMap<Domain.Contact, ContactVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<ContactVM, Domain.Contact>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            Mapper.CreateMap<Domain.Liquidation, LiquidationVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<LiquidationVM, Domain.Liquidation>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            Mapper.CreateMap<Domain.ProducerCode, ProducerCodeVM>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId))
                .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<ProducerCodeVM, Domain.ProducerCode>()
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)))
                .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)));

            Mapper.CreateMap<Domain.District, DistrictVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.ProvinceId, y => y.MapFrom(x => x.Province.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<DistrictVM, Domain.District>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.ProvinceId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Provinces.Find(res.Value)));

            Mapper.CreateMap<Domain.Locality, LocalityVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.DistrictId, y => y.MapFrom(x => x.District.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<LocalityVM, Domain.Locality>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.DistrictId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Districts.Find(res.Value)));

            Mapper.CreateMap<Domain.Risk, RiskVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<RiskVM, Domain.Risk>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            Mapper.CreateMap<Domain.VehicleModel, VehicleModelVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.BrandId, y => y.MapFrom(x => x.Brand.ObjectId))
                .ForMember(x => x.VehicleTypeId, y => y.MapFrom(x => x.VehicleType.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<VehicleModelVM, Domain.VehicleModel>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.BrandId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Brands.Find(res.Value)))
                .ForMember(x => x.VehicleTypeId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).VehicleTypes.Find(res.Value)));

            Mapper.CreateMap<Domain.Policy, PolicyVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client.ObjectId))
                .ForMember(x => x.CollectorId, y => y.MapFrom(x => x.Collector.ObjectId))
                .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer.ObjectId))
                .ForMember(x => x.RiskId, y => y.MapFrom(x => x.Risk.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<PolicyVM, Domain.Policy>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.ClientId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
                .ForMember(x => x.CollectorId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)))
                .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)))
                .ForMember(x => x.RiskId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Risks.Find(res.Value)));

            Mapper.CreateMap<Domain.Endorse, EndorseVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client.ObjectId))
                .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<EndorseVM, Domain.Endorse>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.ClientId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            Mapper.CreateMap<Domain.Employee, EmployeeVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
                .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<EmployeeVM, Domain.Employee>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            Mapper.CreateMap<Domain.FeeSelection, FeeSelectionVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.LiquidationId, y => y.MapFrom(x => x.Liquidation == null ? null : x.Liquidation.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<FeeSelectionVM, Domain.FeeSelection>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.LiquidationId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Liquidations.Find(res.Value)));

            Mapper.CreateMap<Domain.Fee, FeeVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
                .ForMember(x => x.FeeSelectionId, y => y.MapFrom(x => x.FeeSelection == null ? null : x.FeeSelection.ObjectId))
                .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<FeeVM, Domain.Fee>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Endorses.Find(res.Value)))
                .ForMember(x => x.FeeSelectionId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).FeeSelections.Find(res.Value)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            Mapper.CreateMap<Domain.Vehicle, VehicleVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
                .ForMember(x => x.BodyworkId, y => y.MapFrom(x => x.Bodywork == null ? null : x.Bodywork.ObjectId))
                .ForMember(x => x.UseId, y => y.MapFrom(x => x.Use == null ? null : x.Use.ObjectId))
                .ForMember(x => x.VehicleModelId, y => y.MapFrom(x => x.VehicleModel == null ? null : x.VehicleModel.ObjectId))
                .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<VehicleVM, Domain.Vehicle>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Endorses.Find(res.Value)))
                .ForMember(x => x.BodyworkId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Bodyworks.Find(res.Value)))
                .ForMember(x => x.UseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Uses.Find(res.Value)))
                .ForMember(x => x.VehicleModelId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).VehicleModels.Find(res.Value)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            Mapper.CreateMap<Domain.Accessory, AccessoryVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.AccessoryTypeId, y => y.MapFrom(x => x.AccessoryType == null ? null : x.AccessoryType.ObjectId))
                .ForMember(x => x.VehicleId, y => y.MapFrom(x => x.Vehicle == null ? null : x.Vehicle.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<AccessoryVM, Domain.Accessory>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.AccessoryTypeId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).AccessoryTypes.Find(res.Value)))
                .ForMember(x => x.VehicleId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Vehicles.Find(res.Value)));

            Mapper.CreateMap<Domain.Integral, IntegralVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
                .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<IntegralVM, Domain.Integral>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Endorses.Find(res.Value)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            Mapper.CreateMap<Domain.Address, AddressVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client == null ? null : x.Client.ObjectId))
                .ForMember(x => x.LocalityId, y => y.MapFrom(x => x.Locality == null ? null : x.Locality.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<AddressVM, Domain.Address>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.ClientId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
                .ForMember(x => x.LocalityId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Localities.Find(res.Value)));

            Mapper.CreateMap<Domain.CashAccount, CashAccountVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => string.IsNullOrWhiteSpace(x.ObjectId) ? Guid.Empty : new Guid(x.ObjectId)))
                .ForMember(x => x.AssetId, y => y.MapFrom(x => x.Asset == null ? null : x.Asset.ObjectId))
                .ForMember(x => x.FeeId, y => y.MapFrom(x => x.Fee == null ? null : x.Fee.ObjectId))
                .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer == null ? null : x.Producer.ObjectId))
                .ForMember(x => x.LedgerAccountId, y => y.MapFrom(x => x.LedgerAccount == null ? null : x.LedgerAccount.ObjectId)).ForMember(x => x.CreatedAt, y => y.MapFrom(x => x.CreatedAt.HasValue ? x.CreatedAt.Value : DateTime.MinValue)).ForMember(x => x.UpdatedAt, y => y.MapFrom(x => x.UpdatedAt.HasValue ? x.UpdatedAt.Value : DateTime.MinValue));
            Mapper.CreateMap<CashAccountVM, Domain.CashAccount>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.AssetId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Assets.Find(res.Value)))
                .ForMember(x => x.FeeId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Fees.Find(res.Value)))
                .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)))
                .ForMember(x => x.LedgerAccountId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).LedgerAccounts.Find(res.Value)));
        }

        public void SynchronizeParseEntities()
        {
            SendEntitiesToParse<Domain.AccessoryType, AccessoryTypeVM>("AccessoryTypes");
            SendEntitiesToParse<Asset, AssetVM>("Assets");
            SendEntitiesToParse<Bank, BankVM>("Banks");
            SendEntitiesToParse<Bodywork, BodyworkVM>("Bodyworks");
            SendEntitiesToParse<Brand, BrandVM>("Brands");
            SendEntitiesToParse<CasualtyType, CasualtyTypeVM>("CasualtyTypes");
            SendEntitiesToParse<Client, ClientVM>("Clients");
            SendEntitiesToParse<Company, CompanyVM>("Companies");
            SendEntitiesToParse<CreditCard, CreditCardVM>("CreditCards");
            SendEntitiesToParse<LedgerAccount, LedgerAccountVM>("LedgerAccounts");
            SendEntitiesToParse<Producer, ProducerVM>("Producers");
            SendEntitiesToParse<Province, ProvinceVM>("Provinces");
            SendEntitiesToParse<Use, UseVM>("Uses");
            SendEntitiesToParse<VehicleType, VehicleTypeVM>("VehicleTypes");
            SendEntitiesToParse<Cheque, ChequeVM>("Cheques");
            SendEntitiesToParse<Contact, ContactVM>("Contacts");
            SendEntitiesToParse<Liquidation, LiquidationVM>("Liquidations");
            //// TODO: SendEntitiesToParse<ProducerCode, ProducerCodeVM>("ProducerCodes");
            SendEntitiesToParse<District, DistrictVM>("Districts");
            SendEntitiesToParse<Locality, LocalityVM>("Localities");
            SendEntitiesToParse<Risk, RiskVM>("Risks");
            SendEntitiesToParse<VehicleModel, VehicleModelVM>("VehicleModels");
            SendEntitiesToParse<Policy, PolicyVM>("Policies");
            SendEntitiesToParse<Endorse, EndorseVM>("Endorses");
            SendEntitiesToParse<Employee, EmployeeVM>("Employees");
            SendEntitiesToParse<FeeSelection, FeeSelectionVM>("FeeSelections");
            SendEntitiesToParse<Fee, FeeVM>("Fees");
            SendEntitiesToParse<Vehicle, VehicleVM>("Vehicles");
            SendEntitiesToParse<Accessory, AccessoryVM>("Accessories");
            //SendEntitiesToParse<Integral, IntegralVM>("Integrals");
            SendEntitiesToParse<Address, AddressVM>("Addresses");
            SendEntitiesToParse<CashAccount, CashAccountVM>("CashAccounts");
            // TODO: The rest...
        }

        public void SendEntitiesToParse<TParseEntity, TViewModel>(
            string parseEntityName)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            try
            {
                var newEntities = context.Set<TParseEntity>().Where(e => e.ObjectId == null).ToList();
                var updatedEntities = context.Set<TParseEntity>().Where(e => e.ObjectId != null && e.UpdatedAt < e.LocallyUpdatedAt).ToList();

                var parseCreatedEntities = this.client.CreateEntities<TParseEntity, TViewModel>(newEntities, parseEntityName);
                var parseUpdatedEntities = this.client.UpdateEntities<TParseEntity, TViewModel>(updatedEntities, parseEntityName);
            }
            catch (Exception ex)
            {
                this.eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
                WriteEntryInnerEx(ex);
            }
        }

        private void WriteEntryInnerEx(Exception ex)
        {
            if (ex.InnerException != null)
            {
                this.eventLog.WriteEntry(ex.InnerException.Message, EventLogEntryType.Error);
                WriteEntryInnerEx(ex.InnerException);
            }
        }

        public TViewModel Map<TEntity, TViewModel>(TEntity e)
        {
            return Mapper.Map<TEntity, TViewModel>(e);
        }
    }
}
