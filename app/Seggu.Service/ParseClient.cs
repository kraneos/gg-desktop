using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using Seggu.Domain;
using System.Linq;
using Seggu.Service;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Seggu.Service
{
    public class ParseClient
    {
        private RestSharp.RestClient restClient;

        public ParseClient()
        {
            this.restClient = new RestClient(Properties.Settings.Default.ParseBaseUrl);
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