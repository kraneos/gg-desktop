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
            //Mapper.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? Guid.Empty : new Guid((string)x.SourceValue));
            //Mapper.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? null : (Guid?)new Guid((string)x.SourceValue));

            //Mapper.CreateMap<Guid, string>().ConvertUsing(x => (Guid)x.SourceValue == Guid.Empty ? null : x.SourceValue.ToString());
            //Mapper.CreateMap<Guid?, string>().ConvertUsing(x => (Guid?)x.SourceValue == null ? null : ((Guid?)x.SourceValue).Value.ToString());

            //Mapper.CreateMap<Domain.AccessoryType, AccessoryTypeVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<AccessoryTypeVM, Domain.AccessoryType>();

            //Mapper.CreateMap<Domain.Asset, AssetVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<AssetVM, Domain.Asset>();
            //Mapper.CreateMap<Domain.Asset, ParseObject>()
            //    .ForSourceMember(x=>x.CashAccounts, y=>y.Ignore())
            //    .ForMember(x => x.CreatedAt, y => y.Ignore())
            //    .ForMember(x => x.UpdatedAt, y => y.Ignore())
            //    .ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForAllMembers(x=>x.;
            //Mapper.CreateMap<AssetVM, Domain.Asset>();

            //Mapper.CreateMap<Domain.Bank, BankVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<BankVM, Domain.Bank>();

            //Mapper.CreateMap<Domain.Bodywork, BodyworkVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<BodyworkVM, Domain.Bodywork>();

            //Mapper.CreateMap<Domain.Brand, BrandVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<BrandVM, Domain.Brand>();

            //Mapper.CreateMap<Domain.CasualtyType, CasualtyTypeVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<CasualtyTypeVM, Domain.CasualtyType>();

            //Mapper.CreateMap<Domain.Client, ClientVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<ClientVM, Domain.Client>();

            //Mapper.CreateMap<Domain.Company, CompanyVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<CompanyVM, Domain.Company>();

            //Mapper.CreateMap<Domain.CreditCard, CreditCardVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<CreditCardVM, Domain.CreditCard>();

            //Mapper.CreateMap<Domain.LedgerAccount, LedgerAccountVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<LedgerAccountVM, Domain.LedgerAccount>();

            //Mapper.CreateMap<Domain.Producer, ProducerVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<ProducerVM, Domain.Producer>();

            //Mapper.CreateMap<Domain.Province, ProvinceVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<ProvinceVM, Domain.Province>();

            //Mapper.CreateMap<Domain.Use, UseVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<UseVM, Domain.Use>();

            //Mapper.CreateMap<Domain.VehicleType, VehicleTypeVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore());
            //Mapper.CreateMap<VehicleTypeVM, Domain.VehicleType>();

            //Mapper.CreateMap<Domain.Cheque, ChequeVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.BankId, y => y.MapFrom(x => x.Bank.ObjectId));
            //Mapper.CreateMap<ChequeVM, Domain.Cheque>()

            //    .ForMember(x => x.BankId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Banks.Find(res.Value)));

            //Mapper.CreateMap<Domain.Contact, ContactVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId));
            //Mapper.CreateMap<ContactVM, Domain.Contact>()

            //    .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            //Mapper.CreateMap<Domain.Liquidation, LiquidationVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId));
            //Mapper.CreateMap<LiquidationVM, Domain.Liquidation>()

            //    .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            //Mapper.CreateMap<Domain.ProducerCode, ProducerCodeVM>().ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId))
            //    .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer.ObjectId));
            //Mapper.CreateMap<ProducerCodeVM, Domain.ProducerCode>()
            //    .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)))
            //    .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)));

            //Mapper.CreateMap<Domain.District, DistrictVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.ProvinceId, y => y.MapFrom(x => x.Province.ObjectId));
            //Mapper.CreateMap<DistrictVM, Domain.District>()

            //    .ForMember(x => x.ProvinceId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Provinces.Find(res.Value)));

            //Mapper.CreateMap<Domain.Locality, LocalityVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.DistrictId, y => y.MapFrom(x => x.District.ObjectId));
            //Mapper.CreateMap<LocalityVM, Domain.Locality>()

            //    .ForMember(x => x.DistrictId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Districts.Find(res.Value)));

            //Mapper.CreateMap<Domain.Risk, RiskVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId));
            //Mapper.CreateMap<RiskVM, Domain.Risk>()

            //    .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            //Mapper.CreateMap<Domain.VehicleModel, VehicleModelVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.BrandId, y => y.MapFrom(x => x.Brand.ObjectId))
            //    .ForMember(x => x.VehicleTypeId, y => y.MapFrom(x => x.VehicleType.ObjectId));
            //Mapper.CreateMap<VehicleModelVM, Domain.VehicleModel>()

            //    .ForMember(x => x.BrandId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Brands.Find(res.Value)))
            //    .ForMember(x => x.VehicleTypeId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).VehicleTypes.Find(res.Value)));

            //Mapper.CreateMap<Domain.Policy, PolicyVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client.ObjectId))
            //    .ForMember(x => x.CollectorId, y => y.MapFrom(x => x.Collector.ObjectId))
            //    .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer.ObjectId))
            //    .ForMember(x => x.RiskId, y => y.MapFrom(x => x.Risk.ObjectId));
            //Mapper.CreateMap<PolicyVM, Domain.Policy>()

            //    .ForMember(x => x.ClientId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
            //    .ForMember(x => x.CollectorId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)))
            //    .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)))
            //    .ForMember(x => x.RiskId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Risks.Find(res.Value)));

            //Mapper.CreateMap<Domain.Endorse, EndorseVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client.ObjectId))
            //    .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy.ObjectId));
            //Mapper.CreateMap<EndorseVM, Domain.Endorse>()

            //    .ForMember(x => x.ClientId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
            //    .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            //Mapper.CreateMap<Domain.Employee, EmployeeVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
            //    .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId));
            //Mapper.CreateMap<EmployeeVM, Domain.Employee>()

            //    .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
            //    .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            //Mapper.CreateMap<Domain.FeeSelection, FeeSelectionVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.LiquidationId, y => y.MapFrom(x => x.Liquidation == null ? null : x.Liquidation.ObjectId));
            //Mapper.CreateMap<FeeSelectionVM, Domain.FeeSelection>()

            //    .ForMember(x => x.LiquidationId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Liquidations.Find(res.Value)));

            //Mapper.CreateMap<Domain.Fee, FeeVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
            //    .ForMember(x => x.FeeSelectionId, y => y.MapFrom(x => x.FeeSelection == null ? null : x.FeeSelection.ObjectId))
            //    .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId));
            //Mapper.CreateMap<FeeVM, Domain.Fee>()

            //    .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Endorses.Find(res.Value)))
            //    .ForMember(x => x.FeeSelectionId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).FeeSelections.Find(res.Value)))
            //    .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            //Mapper.CreateMap<Domain.Vehicle, VehicleVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
            //    .ForMember(x => x.BodyworkId, y => y.MapFrom(x => x.Bodywork == null ? null : x.Bodywork.ObjectId))
            //    .ForMember(x => x.UseId, y => y.MapFrom(x => x.Use == null ? null : x.Use.ObjectId))
            //    .ForMember(x => x.VehicleModelId, y => y.MapFrom(x => x.VehicleModel == null ? null : x.VehicleModel.ObjectId))
            //    .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId));
            //Mapper.CreateMap<VehicleVM, Domain.Vehicle>()

            //    .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Endorses.Find(res.Value)))
            //    .ForMember(x => x.BodyworkId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Bodyworks.Find(res.Value)))
            //    .ForMember(x => x.UseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Uses.Find(res.Value)))
            //    .ForMember(x => x.VehicleModelId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).VehicleModels.Find(res.Value)))
            //    .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            //Mapper.CreateMap<Domain.Accessory, AccessoryVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.AccessoryTypeId, y => y.MapFrom(x => x.AccessoryType == null ? null : x.AccessoryType.ObjectId))
            //    .ForMember(x => x.VehicleId, y => y.MapFrom(x => x.Vehicle == null ? null : x.Vehicle.ObjectId));
            //Mapper.CreateMap<AccessoryVM, Domain.Accessory>()

            //    .ForMember(x => x.AccessoryTypeId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).AccessoryTypes.Find(res.Value)))
            //    .ForMember(x => x.VehicleId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Vehicles.Find(res.Value)));

            //Mapper.CreateMap<Domain.Integral, IntegralVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
            //    .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId));
            //Mapper.CreateMap<IntegralVM, Domain.Integral>()

            //    .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Endorses.Find(res.Value)))
            //    .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            //Mapper.CreateMap<Domain.Address, AddressVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client == null ? null : x.Client.ObjectId))
            //    .ForMember(x => x.LocalityId, y => y.MapFrom(x => x.Locality == null ? null : x.Locality.ObjectId));
            //Mapper.CreateMap<AddressVM, Domain.Address>()

            //    .ForMember(x => x.ClientId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
            //    .ForMember(x => x.LocalityId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Localities.Find(res.Value)));

            //Mapper.CreateMap<Domain.CashAccount, CashAccountVM>()
            //    .ForMember(x => x.CreatedAt, y => y.Ignore()).ForMember(x => x.UpdatedAt, y => y.Ignore()).ForMember(x => x.ObjectId, y => y.Ignore())
            //    .ForMember(x => x.AssetId, y => y.MapFrom(x => x.Asset == null ? null : x.Asset.ObjectId))
            //    .ForMember(x => x.FeeId, y => y.MapFrom(x => x.Fee == null ? null : x.Fee.ObjectId))
            //    .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer == null ? null : x.Producer.ObjectId))
            //    .ForMember(x => x.LedgerAccountId, y => y.MapFrom(x => x.LedgerAccount == null ? null : x.LedgerAccount.ObjectId));
            //Mapper.CreateMap<CashAccountVM, Domain.CashAccount>()

            //    .ForMember(x => x.AssetId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Assets.Find(res.Value)))
            //    .ForMember(x => x.FeeId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Fees.Find(res.Value)))
            //    .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)))
            //    .ForMember(x => x.LedgerAccountId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).LedgerAccounts.Find(res.Value)));
        }

        public void SynchronizeParseEntities()
        {
            if (ParseUser.CurrentUser != null)
            {
                SendEntitiesToParse<Domain.AccessoryType, AccessoryTypeVM>("AccessoryType");
                SendEntitiesToParse<Asset, AssetVM>("Asset");
                SendEntitiesToParse<Bank, BankVM>("Bank");
                //SendEntitiesToParse<Bodywork, BodyworkVM>("Bodywork");
                //SendEntitiesToParse<Brand, BrandVM>("Brand");
                //SendEntitiesToParse<CasualtyType, CasualtyTypeVM>("CasualtyType");
                //SendEntitiesToParse<Client, ClientVM>("Client");
                //SendEntitiesToParse<Company, CompanyVM>("Company");
                //SendEntitiesToParse<CreditCard, CreditCardVM>("CreditCard");
                //SendEntitiesToParse<LedgerAccount, LedgerAccountVM>("LedgerAccount");
                //SendEntitiesToParse<Producer, ProducerVM>("Producer");
                //SendEntitiesToParse<Province, ProvinceVM>("Province");
                //SendEntitiesToParse<Use, UseVM>("Use");
                //SendEntitiesToParse<VehicleType, VehicleTypeVM>("VehicleType");
                //SendEntitiesToParse<Cheque, ChequeVM>("Cheques");
                //SendEntitiesToParse<Contact, ContactVM>("Contacts");
                //SendEntitiesToParse<Liquidation, LiquidationVM>("Liquidations");
                ////// TODO: SendEntitiesToParse<ProducerCode, ProducerCodeVM>("ProducerCodes");
                //SendEntitiesToParse<District, DistrictVM>("Districts");
                //SendEntitiesToParse<Locality, LocalityVM>("Localities");
                //SendEntitiesToParse<Risk, RiskVM>("Risks");
                //SendEntitiesToParse<VehicleModel, VehicleModelVM>("VehicleModels");
                //SendEntitiesToParse<Policy, PolicyVM>("Policies");
                //SendEntitiesToParse<Endorse, EndorseVM>("Endorses");
                //SendEntitiesToParse<Employee, EmployeeVM>("Employees");
                //SendEntitiesToParse<FeeSelection, FeeSelectionVM>("FeeSelections");
                //SendEntitiesToParse<Fee, FeeVM>("Fees");
                //SendEntitiesToParse<Vehicle, VehicleVM>("Vehicles");
                //SendEntitiesToParse<Accessory, AccessoryVM>("Accessories");
                ////SendEntitiesToParse<Integral, IntegralVM>("Integrals");
                //SendEntitiesToParse<Address, AddressVM>("Addresses");
                //SendEntitiesToParse<CashAccount, CashAccountVM>("CashAccounts");
                // TODO: The rest...

            }
        }

        public void SendEntitiesToParse<TParseEntity, TViewModel>(
            string parseEntityName)
            where TParseEntity : IdParseEntity, new()
            where TViewModel : ViewModel
        {
            try
            {
                ApiToEntities<TParseEntity, TViewModel>(parseEntityName).Wait();
                EntitiesToApi<TParseEntity, TViewModel>(parseEntityName).Wait();
            }
            catch (Exception ex)
            {
                this.eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
                WriteEntryInnerEx(ex);
            }
        }

        private async Task ApiToEntities<TParseEntity, TViewModel>(string parseEntityName)
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
            await this.client.GetManyEntities<TParseEntity, TViewModel>(parseEntityName, lastSync);
            if (isNew)
            {
                context.Synchronizations.Add(lastSync);
            }
            context.SaveChanges();
        }

        private async Task EntitiesToApi<TParseEntity, TViewModel>(string parseEntityName)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            var newEntities = context.Set<TParseEntity>().Where(e => e.ObjectId == null).ToList();
            var updatedEntities = context.Set<TParseEntity>().Where(e => e.ObjectId != null && e.UpdatedAt < e.LocallyUpdatedAt).ToList();

            var parseCreatedEntities = await this.client.CreateEntities<TParseEntity, TViewModel>(newEntities, parseEntityName);
            var parseUpdatedEntities = await this.client.UpdateEntities<TParseEntity, TViewModel>(updatedEntities, parseEntityName);
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
