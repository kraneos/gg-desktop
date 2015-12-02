using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Seggu.Service
{
    public class ParseClient
    {
        private RestSharp.RestClient restClient;
        public ParseClient()
        {
            this.restClient = new RestClient(Properties.Settings.Default.ParseBaseUrl);
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
            return req;
        }
    }
}