using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Seggu.Domain;
using System.Linq;
using Seggu.Service.ViewModels;
using Seggu.Service.Services.Properties;
using System;
using AutoMapper;
using System.Diagnostics;
using Seggu.Data;

namespace Seggu.Service.Services
{
    public class ParseClient
    {
        private RestSharp.RestClient restClient;
        private EventLog eventLog;
        private SegguDataModelContext context;

        public ParseClient(SegguDataModelContext context, EventLog eventLog)
        {
            this.eventLog = eventLog;
            this.context = context;
            this.restClient = new RestClient(Settings.Default.ParseBaseUrl);
            SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializationStrategy();
        }

        private IEnumerable<T> SerializeCollectionResponse<T>(string content) where T : new()
        {
            return JsonConvert.DeserializeObject<ParseQueryResult<T>>(content).Results;
        }

        private RestRequest GetRequest(string resource, Method method)
        {
            var req = new RestRequest(resource, method);
            req.AddHeader("Content-Type", "application/json");
            //req.AddHeader("X-Parse-Application-Id", Properties.Settings.Default.ParseAppId);
            //req.AddHeader("X-Parse-REST-API-Key", Properties.Settings.Default.ParseSecretKey);
            req.RequestFormat = DataFormat.Json;
            return req;
        }

        public IEnumerable<TParseEntity> CreateEntities<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> newEntities,
            string parseEntityName)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            return ExecuteManyRequests<TParseEntity, TViewModel>(
                 newEntities,
                 parseEntityName,
                 "POST",
                 CreateMapper);
        }

        public IEnumerable<TParseEntity> UpdateEntities<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> updatedEntities,
            string parseEntityName)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            return ExecuteManyRequests<TParseEntity, TViewModel>(
                updatedEntities,
                parseEntityName,
                "PUT",
                UpdateMapper,
                (x, y) => x + y.ObjectId);
        }

        public IEnumerable<TParseEntity> ExecuteManyRequests<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> entities,
            string parseEntityName,
            string statusCode,
            Action<TParseEntity, TViewModel> callback,
            Func<string, TParseEntity, string> resourceNameResolver = null)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
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
                    CreateMapper);

                context.SaveChanges();
            }

            return entities;
        }

        public IEnumerable<TParseEntity> ExecuteRequests<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> entities,
            string parseEntityName,
            string statusCode,
            Action<TParseEntity, TViewModel> callback,
            Func<string, TParseEntity, string> resourceNameResolver = null)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            var reqPath = "api/" + parseEntityName;
            var req = GetRequest("/batch/" + parseEntityName, Method.POST);

            var batch = new BatchRequest<TViewModel>();
            batch.Requests = entities.Select(e => new BatchElement<TViewModel>
            {
                Method = statusCode,
                Id = e.ObjectId,
                Body = Mapper.Map<TParseEntity, TViewModel>(e)
            });

            this.eventLog.WriteEntry("About to execute batch for " + parseEntityName);
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                this.eventLog.WriteEntry(parseEntityName + " everything ok.");
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
                this.eventLog.WriteEntry("HTTPCODE: " + res.StatusDescription + "\n" + res.Content, EventLogEntryType.Error);
                return null;
            }
        }

        #region MethodMappers
        private void CreateMapper<TParseEntity, TParseViewModel>(TParseEntity e, TParseViewModel vm)
            where TParseEntity : IdParseEntity
            where TParseViewModel : ViewModel
        {
            e.ObjectId = vm.Id.ToString();
            e.CreatedAt = vm.CreatedAt;
            e.UpdatedAt = vm.CreatedAt;
            e.LocallyUpdatedAt = vm.CreatedAt;
        }

        private void UpdateMapper<TParseEntity, TParseViewModel>(TParseEntity e, TParseViewModel vm)
            where TParseEntity : IdParseEntity
            where TParseViewModel : ViewModel
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