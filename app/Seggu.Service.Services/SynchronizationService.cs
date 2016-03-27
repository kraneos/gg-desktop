using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Seggu.Data;
using Seggu.Domain;
using Seggu.Service.Services.Interfaces;
using Seggu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void SynchronizeParseEntities()
        {
            SendEntitiesToParse<Client, ClientVM>("Client", MapClient);
            SendEntitiesToParse<Address, AddressVM>("Address", MapAddress);
            SendEntitiesToParse<Policy, PolicyVM>("Policy", MapPolicy);
            SendEntitiesToParse<Fee, FeeVM>("Fee", MapFee);
            SendEntitiesToParse<Vehicle, VehicleVM>("Vehicle", MapVehicle);
        }

        private void SendVehiclesToParse(SegguDataModelContext context)
        {
            var newVehicles = context.Vehicles
                .Where(p => p.ObjectId == null).ToList();
            var updatedVehicles = context.Vehicles
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedVehicles = this.client.CreateVehicles(newVehicles);
            var parseUpdatedVehicles = this.client.UpdateVehicles(updatedVehicles);

            context.SaveChanges();
        }

        private void SendAddressesToParse(SegguDataModelContext context)
        {
            var newAddresses = context.Addresses
                .Where(p => p.ObjectId == null).ToList();
            var updatedAddresses = context.Addresses
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedAddresses = this.client.CreateAddresses(newAddresses);
            var parseUpdatedAddresses = this.client.UpdateAddresses(updatedAddresses);

            context.SaveChanges();
        }

        private void SendClientsToParse(SegguDataModelContext context)
        {
            var newClients = context.Clients
                .Where(p => p.ObjectId == null).ToList();
            var updatedClients = context.Clients
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedClients = this.client.CreateClients(newClients);
            var parseUpdatedClients = this.client.UpdateClients(updatedClients);

            context.SaveChanges();
        }

        private void SendFeesToParse(SegguDataModelContext context)
        {
            var newFees = context.Fees
                .Where(p => p.ObjectId == null).ToList();
            var updatedFees = context.Fees
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedFees = this.client.CreateFees(newFees);
            var parseUpdatedFees = this.client.UpdateFees(updatedFees);

            context.SaveChanges();
        }

        private void SendPoliciesToParse(SegguDataModelContext context)
        {
            var newPolicies = context.Policies
                .Where(p => p.ObjectId == null).ToList();
            var updatedPolicies = context.Policies
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedPolicies = this.client.CreatePolicies(newPolicies);
            var parseUpdatedPolicies = this.client.UpdatePolicies(updatedPolicies);

            context.SaveChanges();
        }

        public void SendEntitiesToParse<TParseEntity, TViewModel>(
            string parseEntityName,
            Func<TParseEntity, TViewModel> mapper)
            where TParseEntity : IdParseEntity
            where TViewModel : ParseViewModel
        {
            var newEntities = context.Set<TParseEntity>().Where(e => e.ObjectId == null).ToList();
            var updatedEntities = context.Set<TParseEntity>().Where(e => e.ObjectId != null && e.UpdatedAt < e.LocallyUpdatedAt).ToList();

            var parseCreatedEntities = this.client.CreateEntities(newEntities, parseEntityName, mapper);
            var parseUpdatedEntities = this.client.UpdateEntities(updatedEntities, parseEntityName, mapper);

            context.SaveChanges();
        }

        #region Mappers
        private ClientVM MapClient(Client x)
        {
            return new ClientVM
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Document = x.Document,
                CellPhone = x.CellPhone
            };
        }

        private AddressVM MapAddress(Address x)
        {
            return new AddressVM
            {
                Id = x.Id,
                Street = x.Street,
                Number = x.Number,
                Floor = x.Floor,
                Appartment = x.Appartment,
                PostalCode = x.PostalCode,
                LocalityId = x.LocalityId,
                LocalityName = x.Locality.Name,
                ProvinceName = x.Locality.District.Province.Name
            };
        }

        private PolicyVM MapPolicy(Policy x)
        {
            return new PolicyVM
            {
                Id = x.Id,
                Value = x.Value,
                Number = x.Number,
                ClientId = x.ClientId,
                ClientName = x.Client.FirstName + " " + x.Client.LastName,
                CompanyName = x.Risk.Company.Name,
                FeeAmount = x.Fees.Count,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            };
        }

        private FeeVM MapFee(Fee x)
        {
            return new FeeVM
            {
                Id = x.Id,
                Value = x.Value,
                Number = x.Number,
                State = (int)x.State,
                StateName = x.State.ToString(),
                PolicyId = x.Policy != null ? x.Policy.ObjectId : null,
                ExpirationDate = x.ExpirationDate,
                Policy = x.Policy != null ? new PointerVM("Policy", x.Policy.ObjectId) : null
            };
        }

        private VehicleVM MapVehicle(Vehicle x)
        {
            return new VehicleVM
            {
                Id = x.Id,
                Plate = x.Plate,
                BrandName = x.VehicleModel.Brand.Name,
                PolicyId = x.PolicyId,
                Policy = new PointerVM("Policy", x.Policy.ObjectId),
                VehicleModelId = x.VehicleModelId,
                VehicleModelName = x.VehicleModel.Name
            };
        }


        #endregion
    }
}
