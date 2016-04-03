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
            Mapper.CreateMap<Domain.Bank, BankVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<BankVM, Domain.Bank>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));
            Mapper.CreateMap<Domain.Client, ClientVM>().ForMember(x => x.Id, y => y.MapFrom(x => x.ObjectId));
            Mapper.CreateMap<ClientVM, Domain.Client>().ForMember(x => x.ObjectId, y => y.MapFrom(x => x.Id));
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
