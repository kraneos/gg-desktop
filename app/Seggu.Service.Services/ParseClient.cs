using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Seggu.Domain;
using System.Linq;
using Seggu.Service.ViewModels;
using Seggu.Service.Services.Properties;
using System;

namespace Seggu.Service.Services
{
    public class ParseClient
    {
        private RestSharp.RestClient restClient;

        public ParseClient()
        {
            this.restClient = new RestClient(Settings.Default.ParseBaseUrl);
            SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializationStrategy();
        }

        public IEnumerable<FeeVM> GetFees()
        {
            var req = GetRequest("/1/classes/Fee", Method.GET);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                return this.SerializeCollectionResponse<FeeVM>(res.Content);
            }
            else
            {
                return null;
            }
        }

        private IEnumerable<T> SerializeCollectionResponse<T>(string content) where T : new()
        {
            return JsonConvert.DeserializeObject<ParseQueryResult<T>>(content).Results;
        }

        private RestRequest GetRequest(string resource, Method method)
        {
            var req = new RestRequest(resource, method);
            req.AddHeader("Content-Type", "application/json");
            req.AddHeader("X-Parse-Application-Id", Properties.Settings.Default.ParseAppId);
            req.AddHeader("X-Parse-REST-API-Key", Properties.Settings.Default.ParseSecretKey);
            req.RequestFormat = DataFormat.Json;
            return req;
        }

        public IEnumerable<Policy> CreatePolicies(IEnumerable<Policy> newPolicies)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<PolicyVM>();
            batch.Requests = newPolicies.Select(x => new BatchElement<PolicyVM>
            {
                Method = "POST",
                Path = "/1/classes/Policy",
                Body = new PolicyVM
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
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<PolicyVM>>>(res.Content);
                for (int i = 0; i < newPolicies.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        newPolicies.ElementAt(i).ObjectId = data.ElementAt(i).Success.ObjectId;
                        newPolicies.ElementAt(i).CreatedAt = data.ElementAt(i).Success.CreatedAt;
                        newPolicies.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.CreatedAt;
                        newPolicies.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.CreatedAt;
                    }
                }
                return newPolicies;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Fee> CreateFees(List<Fee> newFees)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<FeeVM>();
            batch.Requests = newFees.Select(x => new BatchElement<FeeVM>
            {
                Method = "POST",
                Path = "/1/classes/Fee",
                Body = new FeeVM
                {
                    Id = x.Id,
                    Value = x.Value,
                    Number = x.Number,
                    State = (int)x.State,
                    StateName = x.State.ToString(),
                    PolicyId = x.Policy != null ? x.Policy.ObjectId : null,
                    ExpirationDate = x.ExpirationDate,
                    Policy = x.Policy != null ? new PointerVM("Policy", x.Policy.ObjectId) : null
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<FeeVM>>>(res.Content);
                for (int i = 0; i < newFees.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        newFees.ElementAt(i).ObjectId = data.ElementAt(i).Success.ObjectId;
                        newFees.ElementAt(i).CreatedAt = data.ElementAt(i).Success.CreatedAt;
                        newFees.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.CreatedAt;
                        newFees.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.CreatedAt;
                    }
                }
                return newFees;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<TParseEntity> CreateEntities<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> newEntities,
            string parseEntityName,
            Func<TParseEntity, TViewModel> mapper)
            where TParseEntity : IdParseEntity
            where TViewModel : ParseViewModel
        {
            return ExecuteManyRequests<TParseEntity, TViewModel>(
                 newEntities,
                 parseEntityName,
                 "POST",
                 mapper,
                 CreateMapper);
        }

        public IEnumerable<TParseEntity> UpdateEntities<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> updatedEntities,
            string parseEntityName,
            Func<TParseEntity, TViewModel> mapper)
            where TParseEntity : IdParseEntity
            where TViewModel : ParseViewModel
        {
            return ExecuteManyRequests<TParseEntity, TViewModel>(
                updatedEntities,
                parseEntityName,
                "PUT",
                mapper,
                UpdateMapper,
                (x, y) => x + y.ObjectId);
        }

        public IEnumerable<TParseEntity> ExecuteManyRequests<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> entities,
            string parseEntityName,
            string statusCode,
            Func<TParseEntity, TViewModel> mapper,
            Action<TParseEntity, TViewModel> callback,
            Func<string, TParseEntity, string> resourceNameResolver = null)
            where TParseEntity : IdParseEntity
            where TViewModel : ParseViewModel
        {
            var totalRecords = entities.Count();
            var recordsPerPage = 50M;
            var recordsPerPageInt = 50;
            var pageCount = Math.Ceiling(totalRecords / recordsPerPage);

            for (int i = 0; i < pageCount; i++)
            {
                IEnumerable<TParseEntity> entitiesToExecute;

                if ((i + 1) * recordsPerPageInt <= totalRecords)
                {
                    entitiesToExecute = entities.Skip(i * recordsPerPageInt).Take(recordsPerPageInt);
                }
                else
                {
                    entitiesToExecute = entities.Skip(i * recordsPerPageInt).Take(totalRecords - (i * recordsPerPageInt));
                }

                ExecuteRequests<TParseEntity, TViewModel>(
                    entitiesToExecute,
                    parseEntityName,
                    statusCode,
                    mapper,
                    CreateMapper);
            }

            return entities;
        }

        public IEnumerable<TParseEntity> ExecuteRequests<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> entities,
            string parseEntityName,
            string statusCode,
            Func<TParseEntity, TViewModel> mapper,
            Action<TParseEntity, TViewModel> callback,
            Func<string, TParseEntity, string> resourceNameResolver = null)
            where TParseEntity : IdParseEntity
            where TViewModel : ParseViewModel
        {
            var reqPath = "/1/classes/" + parseEntityName;
            var req = GetRequest("/1/batch", Method.POST);

            var batch = new BatchRequest<TViewModel>();
            batch.Requests = entities.Select(e => new BatchElement<TViewModel>
            {
                Method = statusCode,
                Path = resourceNameResolver == null ? reqPath : resourceNameResolver.Invoke(reqPath, e),
                Body = mapper.Invoke(e)
            });

            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<TViewModel>>>(res.Content);
                var count = entities.Count();
                for (int i = 0; i < count; i++)
                {
                    var vm = data.ElementAt(i);
                    var e = entities.ElementAt(i);
                    if (vm.Success != null)
                    {
                        callback.Invoke(e, vm.Success);
                    }
                }

                return entities;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Client> CreateClients(List<Client> newClients)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<ClientVM>();
            batch.Requests = newClients.Select(x => new BatchElement<ClientVM>
            {
                Method = "POST",
                Path = "/1/classes/Client",
                Body = new ClientVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Document = x.Document,
                    CellPhone = x.CellPhone
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<ClientVM>>>(res.Content);
                for (int i = 0; i < newClients.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        newClients.ElementAt(i).ObjectId = data.ElementAt(i).Success.ObjectId;
                        newClients.ElementAt(i).CreatedAt = data.ElementAt(i).Success.CreatedAt;
                        newClients.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.CreatedAt;
                        newClients.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.CreatedAt;

                    }
                }
                return newClients;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Address> CreateAddresses(List<Address> newAddresses)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<AddressVM>();
            batch.Requests = newAddresses.Select(x => new BatchElement<AddressVM>
            {
                Method = "POST",
                Path = "/1/classes/Address",
                Body = new AddressVM
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
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<AddressVM>>>(res.Content);
                for (int i = 0; i < newAddresses.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        newAddresses.ElementAt(i).ObjectId = data.ElementAt(i).Success.ObjectId;
                        newAddresses.ElementAt(i).CreatedAt = data.ElementAt(i).Success.CreatedAt;
                        newAddresses.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.CreatedAt;
                        newAddresses.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.CreatedAt;

                    }
                }
                return newAddresses;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Vehicle> CreateVehicles(List<Vehicle> newVehicles)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<VehicleVM>();
            batch.Requests = newVehicles.Select(x => new BatchElement<VehicleVM>
            {
                Method = "POST",
                Path = "/1/classes/Vehicle",
                Body = new VehicleVM
                {
                    Id = x.Id,
                    Plate = x.Plate,
                    BrandName = x.VehicleModel.Brand.Name,
                    PolicyId = x.PolicyId,
                    Policy = new PointerVM("Policy", x.Policy.ObjectId),
                    VehicleModelId = x.VehicleModelId,
                    VehicleModelName = x.VehicleModel.Name
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<VehicleVM>>>(res.Content);
                for (int i = 0; i < newVehicles.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        newVehicles.ElementAt(i).ObjectId = data.ElementAt(i).Success.ObjectId;
                        newVehicles.ElementAt(i).CreatedAt = data.ElementAt(i).Success.CreatedAt;
                        newVehicles.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.CreatedAt;
                        newVehicles.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.CreatedAt;

                    }
                }
                return newVehicles;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Policy> UpdatePolicies(IEnumerable<Policy> updatedPolicies)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<PolicyVM>();
            batch.Requests = updatedPolicies.Select(x => new BatchElement<PolicyVM>
            {
                Method = "PUT",
                Path = "/1/classes/Policy/" + x.ObjectId,
                Body = new PolicyVM
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
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<PolicyVM>>>(res.Content);
                for (int i = 0; i < updatedPolicies.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        updatedPolicies.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                        updatedPolicies.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                    }
                }
                return updatedPolicies;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Fee> UpdateFees(List<Fee> updatedFees)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<FeeVM>();
            batch.Requests = updatedFees.Select(x => new BatchElement<FeeVM>
            {
                Method = "PUT",
                Path = "/1/classes/Fee/" + x.ObjectId,
                Body = new FeeVM
                {
                    Id = x.Id,
                    Value = x.Value,
                    Number = x.Number,
                    StateName = x.State.ToString(),
                    State = (int)x.State,
                    PolicyId = x.Policy != null ? x.Policy.ObjectId : null,
                    ExpirationDate = x.ExpirationDate,
                    Policy = x.Policy != null ? new PointerVM("Policy", x.Policy.ObjectId) : null
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<FeeVM>>>(res.Content);
                for (int i = 0; i < updatedFees.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        updatedFees.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                        updatedFees.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                    }
                }
                return updatedFees;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Client> UpdateClients(List<Client> updatedClients)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<ClientVM>();
            batch.Requests = updatedClients.Select(x => new BatchElement<ClientVM>
            {
                Method = "PUT",
                Path = "/1/classes/Client/" + x.ObjectId,
                Body = new ClientVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Document = x.Document,
                    CellPhone = x.CellPhone
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<ClientVM>>>(res.Content);
                for (int i = 0; i < updatedClients.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        updatedClients.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                        updatedClients.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                    }
                }
                return updatedClients;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Address> UpdateAddresses(List<Address> updatedAddresses)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<AddressVM>();
            batch.Requests = updatedAddresses.Select(x => new BatchElement<AddressVM>
            {
                Method = "PUT",
                Path = "/1/classes/Address/" + x.ObjectId,
                Body = new AddressVM
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
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<AddressVM>>>(res.Content);
                for (int i = 0; i < updatedAddresses.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        updatedAddresses.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                        updatedAddresses.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                    }
                }
                return updatedAddresses;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Vehicle> UpdateVehicles(List<Vehicle> updatedVehicles)
        {
            var req = GetRequest("/1/batch", Method.POST);
            var batch = new BatchRequest<VehicleVM>();
            batch.Requests = updatedVehicles.Select(x => new BatchElement<VehicleVM>
            {
                Method = "PUT",
                Path = "/1/classes/Vehicle/" + x.ObjectId,
                Body = new VehicleVM
                {
                    Id = x.Id,
                    Plate = x.Plate,
                    BrandName = x.VehicleModel.Brand.Name,
                    PolicyId = x.PolicyId,
                    Policy = new PointerVM("Policy", x.Policy.ObjectId),
                    VehicleModelId = x.VehicleModelId,
                    VehicleModelName = x.VehicleModel.Name
                }
            });
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<VehicleVM>>>(res.Content);
                for (int i = 0; i < updatedVehicles.Count(); i++)
                {
                    if (data.ElementAt(i).Success != null)
                    {
                        updatedVehicles.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                        updatedVehicles.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                    }
                }
                return updatedVehicles;
            }
            else
            {
                return null;
            }
        }

        #region MethodMappers
        private void CreateMapper<TParseEntity, TParseViewModel>(TParseEntity e, TParseViewModel vm)
            where TParseEntity : IdParseEntity
            where TParseViewModel : ParseViewModel
        {
            e.ObjectId = vm.ObjectId;
            e.CreatedAt = vm.CreatedAt;
            e.UpdatedAt = vm.CreatedAt;
            e.LocallyUpdatedAt = vm.CreatedAt;
        }

        private void UpdateMapper<TParseEntity, TParseViewModel>(TParseEntity e, TParseViewModel vm)
            where TParseEntity : IdParseEntity
            where TParseViewModel : ParseViewModel
        {
            e.UpdatedAt = vm.UpdatedAt;
            e.LocallyUpdatedAt = vm.UpdatedAt;
        }

        #endregion
    }

    public static class RestRequestExtensions
    {
        public static IRestRequest SetBody(this RestRequest req, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            req.AddParameter("application/json", json, ParameterType.RequestBody);

            return req;
        }
    }
}