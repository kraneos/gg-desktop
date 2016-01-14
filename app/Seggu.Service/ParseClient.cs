using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using Seggu.Domain;
using System.Linq;
using Seggu.Service;

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
                    ClientName = x.Client.FirstName + " " + x.Client.LastName,
                    FeeAmount = x.Fees.Count
                }
            });
            req.AddBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<PolicyVM>>>(res.Content);
                for (int i = 0; i < newPolicies.Count(); i++)
                {
                    newPolicies.ElementAt(i).ObjectId = data.ElementAt(i).Success.ObjectId;
                    newPolicies.ElementAt(i).CreatedAt= data.ElementAt(i).Success.CreatedAt;
                    newPolicies.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                    newPolicies.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                }
                return newPolicies;
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
                    ClientName = x.Client.FirstName + ' ' + x.Client.LastName,
                    FeeAmount = x.Fees.Count
                }
            });
            req.AddBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<BatchResponse<PolicyVM>>>(res.Content);
                for (int i = 0; i < updatedPolicies.Count(); i++)
                {
                    updatedPolicies.ElementAt(i).UpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                    updatedPolicies.ElementAt(i).LocallyUpdatedAt = data.ElementAt(i).Success.UpdatedAt;
                }
                return updatedPolicies;
            }
            else
            {
                return null;
            }
        }
    }
}