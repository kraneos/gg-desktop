using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Seggu.Data;
using Seggu.Domain;
using Seggu.Service.Services.Interfaces;
using Seggu.Service.ViewModels;
using System;
using System.Linq;

namespace Seggu.Service.Services
{
    public class SynchronizationService : ISynchronizationService
    {
        private ParseClient client;
        private SegguDataModelContext context;

        public SynchronizationService(SegguDataModelContext context)
        {
            this.context = context;

            // ApiClient configuration.
            this.client = new ParseClient();

            // JsonConvert Configuration
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public static void Initialize()
        {
            Mapper.CreateMap<Domain.AccessoryType, AccessoryTypeVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<AccessoryTypeVM, Domain.AccessoryType>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Asset, AssetVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<AssetVM, Domain.Asset>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Bank, BankVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<BankVM, Domain.Bank>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Bodywork, BodyworkVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<BodyworkVM, Domain.Bodywork>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Brand, BrandVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<BrandVM, Domain.Brand>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.CasualtyType, CasualtyTypeVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<CasualtyTypeVM, Domain.CasualtyType>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Client, ClientVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<ClientVM, Domain.Client>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Company, CompanyVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<CompanyVM, Domain.Company>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.CreditCard, CreditCardVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<CreditCardVM, Domain.CreditCard>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.LedgerAccount, LedgerAccountVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<LedgerAccountVM, Domain.LedgerAccount>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Producer, ProducerVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<ProducerVM, Domain.Producer>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Province, ProvinceVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<ProvinceVM, Domain.Province>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Use, UseVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<UseVM, Domain.Use>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.VehicleType, VehicleTypeVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<VehicleTypeVM, Domain.VehicleType>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

            Mapper.CreateMap<Domain.Cheque, ChequeVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.BankId, y => y.MapFrom(x => x.Bank.ObjectId));
            Mapper.CreateMap<ChequeVM, Domain.Cheque>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.BankId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Banks.Find(res.Value)));

            Mapper.CreateMap<Domain.Contact, ContactVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId));
            Mapper.CreateMap<ContactVM, Domain.Contact>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            Mapper.CreateMap<Domain.Liquidation, LiquidationVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId));
            Mapper.CreateMap<LiquidationVM, Domain.Liquidation>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            Mapper.CreateMap<Domain.ProducerCode, ProducerCodeVM>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId))
                .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer.ObjectId));
            Mapper.CreateMap<ProducerCodeVM, Domain.ProducerCode>()
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)))
                .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)));

            Mapper.CreateMap<Domain.District, DistrictVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.ProvinceId, y => y.MapFrom(x => x.Province.ObjectId));
            Mapper.CreateMap<DistrictVM, Domain.District>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ProvinceId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Provinces.Find(res.Value)));

            Mapper.CreateMap<Domain.Locality, LocalityVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.DistrictId, y => y.MapFrom(x => x.District.ObjectId));
            Mapper.CreateMap<LocalityVM, Domain.Locality>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.DistrictId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Districts.Find(res.Value)));

            Mapper.CreateMap<Domain.Risk, RiskVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.ObjectId));
            Mapper.CreateMap<RiskVM, Domain.Risk>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.CompanyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Companies.Find(res.Value)));

            Mapper.CreateMap<Domain.VehicleModel, VehicleModelVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.BrandId, y => y.MapFrom(x => x.Brand.ObjectId))
                .ForMember(x => x.VehicleTypeId, y => y.MapFrom(x => x.VehicleType.ObjectId));
            Mapper.CreateMap<VehicleModelVM, Domain.VehicleModel>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.BrandId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Brands.Find(res.Value)))
                .ForMember(x => x.VehicleTypeId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).VehicleTypes.Find(res.Value)));

            Mapper.CreateMap<Domain.Policy, PolicyVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client.ObjectId))
                .ForMember(x => x.CollectorId, y => y.MapFrom(x => x.Collector.ObjectId))
                .ForMember(x => x.ProducerId, y => y.MapFrom(x => x.Producer.ObjectId))
                .ForMember(x => x.RiskId, y => y.MapFrom(x => x.Risk.ObjectId));
            Mapper.CreateMap<PolicyVM, Domain.Policy>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ClientId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
                .ForMember(x => x.CollectorId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)))
                .ForMember(x => x.ProducerId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Producers.Find(res.Value)))
                .ForMember(x => x.RiskId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Risks.Find(res.Value)));

            Mapper.CreateMap<Domain.Endorse, EndorseVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client.ObjectId))
                .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy.ObjectId));
            Mapper.CreateMap<EndorseVM, Domain.Endorse>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ClientId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            Mapper.CreateMap<Domain.Employee, EmployeeVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
                .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId));
            Mapper.CreateMap<EmployeeVM, Domain.Employee>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Clients.Find(res.Value)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            Mapper.CreateMap<Domain.FeeSelection, FeeSelectionVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.LiquidationId, y => y.MapFrom(x => x.Liquidation == null ? null : x.Liquidation.ObjectId));
            Mapper.CreateMap<FeeSelectionVM, Domain.FeeSelection>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.LiquidationId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Liquidations.Find(res.Value)));

            Mapper.CreateMap<Domain.Fee, FeeVM>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId))
                .ForMember(x => x.EndorseId, y => y.MapFrom(x => x.Endorse == null ? null : x.Endorse.ObjectId))
                .ForMember(x => x.FeeSelectionId, y => y.MapFrom(x => x.FeeSelection == null ? null : x.FeeSelection.ObjectId))
                .ForMember(x => x.PolicyId, y => y.MapFrom(x => x.Policy == null ? null : x.Policy.ObjectId));
            Mapper.CreateMap<FeeVM, Domain.Fee>()
                .ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.EndorseId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Endorses.Find(res.Value)))
                .ForMember(x => x.FeeSelectionId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).FeeSelections.Find(res.Value)))
                .ForMember(x => x.PolicyId, y => y.ResolveUsing(res => res.Value == null ? null : ((SegguDataModelContext)res.Context.Options.Items["dbContext"]).Policies.Find(res.Value)));

            Mapper.CreateMap<Domain.Address, AddressVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<AddressVM, Domain.Address>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));

        }

        public void SynchronizeParseEntities()
            {
            SendEntitiesToParse<Bank, BankVM>("Banks");
            SendEntitiesToParse<Client, ClientVM>("Clients");
            //SendEntitiesToParse<Address, AddressVM>("Addresses");
            //SendEntitiesToParse<Policy, PolicyVM>("Policies", MapPolicy);
            //SendEntitiesToParse<Fee, FeeVM>("Fees", MapFee);
            //SendEntitiesToParse<Vehicle, VehicleVM>("Vehicles", MapVehicle);
        }

        public void SendEntitiesToParse<TParseEntity, TViewModel>(
            string parseEntityName)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            var newEntities = context.Set<TParseEntity>().Where(e => e.ObjectId == null).ToList();
            var updatedEntities = context.Set<TParseEntity>().Where(e => e.ObjectId != null && e.UpdatedAt < e.LocallyUpdatedAt).ToList();

            var parseCreatedEntities = this.client.CreateEntities<TParseEntity, TViewModel>(newEntities, parseEntityName);
            var parseUpdatedEntities = this.client.UpdateEntities<TParseEntity, TViewModel>(updatedEntities, parseEntityName);

            context.SaveChanges();
        }

        public TViewModel Map<TEntity, TViewModel>(TEntity e)
        {
            return Mapper.Map<TEntity, TViewModel>(e);
        }
    }
}
