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
        private string token;

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
            //var token = this.GetToken();

            var req = new RestRequest(resource, method);
            req.AddHeader("Content-Type", "application/json");
            //req.AddHeader("Authorization", "Bearer " + token);
            req.AddHeader("X-Parse-Application-Id", Properties.Settings.Default.ParseAppId);
            req.AddHeader("X-Parse-REST-API-Key", Properties.Settings.Default.ParseSecretKey);
            req.RequestFormat = DataFormat.Json;
            return req;
        }

        private string GetToken()
        {
            if (string.IsNullOrWhiteSpace(this.token))
            {
                var req = new RestRequest("/token", Method.POST);
                req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                req.AddHeader("Accept", "application/json");

                var body = "grant_type=password&username=" + Properties.Settings.Default.Username + "&password=" + Properties.Settings.Default.Password;

                req.AddBody(body);

                var res = this.restClient.Execute(req);

                this.token = JsonConvert.DeserializeObject<TokenResponseVM>(res.Content).AccessToken;
            }

            return this.token;
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

        internal void GetManyEntities<TParseEntity, TViewModel>(string parseEntityName, Synchronization lastSync)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            var page = 0;
            var thisSync = DateTime.Now;

            IEnumerable<TParseEntity> entities = null;

            while (GetEntities<TParseEntity, TViewModel>(parseEntityName, page * 100, 100, lastSync.LastSync, entities))
            {
                MergeEntities<TParseEntity>(entities);
                page++;
            }

            lastSync.LastSync = thisSync;

            this.context.SaveChanges();
        }

        private void MergeEntities<TParseEntity>(IEnumerable<TParseEntity> entities) where TParseEntity : IdParseEntity
        {
            var objectIds = entities.Select(x => x.ObjectId);
            var existingEntities = this.context.Set<TParseEntity>()
                .Where(x => objectIds.Any(y => y == x.ObjectId));
            var newEntities = entities
                .Where(x => existingEntities.Any(y => y.ObjectId != x.ObjectId));

            this.context.Set<TParseEntity>().AddRange(newEntities);

            foreach (var entity in existingEntities)
            {
                var apiEntity = entities.First(x => x.ObjectId == entity.ObjectId);
                var entry = this.context.Entry<TParseEntity>(entity);
                entry.CurrentValues.SetValues(apiEntity);
            }



            this.context.SaveChanges();
        }

        private bool GetEntities<TParseEntity, TViewModel>(string parseEntityName, int page, int count, DateTime? from, IEnumerable<TParseEntity> entities)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            var path = "/classes/" + parseEntityName;

            var req = GetRequest(path, Method.GET);

            req.AddParameter("skip", page.ToString());
            req.AddParameter("limit", count.ToString());
            if (from != null)
            {
                req.AddParameter("where", "{\"updatedAt\":{\"$gt\":" + JsonConvert.SerializeObject(new DateVM(from.Value)) + "}}");
            }

            this.eventLog.WriteEntry("About to execute query for " + parseEntityName);

            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                this.eventLog.WriteEntry(parseEntityName + " everything ok.");
                entities = JsonConvert.DeserializeObject<ParseQueryResponseVM<TViewModel>>(res.Content)
                    .Results
                    .Select(Mapper.Map<TViewModel, TParseEntity>)
                    .ToList();
                return entities.Any();
            }
            else
            {
                this.eventLog.WriteEntry("HTTPCODE: " + res.StatusDescription + "\n" + res.Content, EventLogEntryType.Error);
                return false;
            }
        }

        public IEnumerable<TParseEntity> ExecuteManyRequests<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> entities,
            string parseEntityName,
            string statusCode,
            Action<TParseEntity, BatchElementResponseVM> callback,
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
            Action<TParseEntity, BatchElementResponseVM> callback,
            Func<string, TParseEntity, string> resourceNameResolver = null)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            var req = GetRequest("/batch", Method.POST);

            var batch = new BatchRequest<TViewModel>();
            batch.Requests = entities.Select(e => new BatchElement<TViewModel>
            {
                Method = statusCode,
                Path = $"/classes/{parseEntityName}" + statusCode == "PUT" ? ($"/{e.ObjectId}") : string.Empty,
                Body = Mapper.Map<TParseEntity, TViewModel>(e)
            });

            this.eventLog.WriteEntry("About to execute batch for " + parseEntityName);
            req.SetBody(batch);
            var res = this.restClient.Execute(req);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                this.eventLog.WriteEntry(parseEntityName + " everything ok.");
                var data = JsonConvert.DeserializeObject<List<BatchResponse>>(res.Content);
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
        private void CreateMapper<TParseEntity>(TParseEntity e, BatchElementResponseVM vm)
            where TParseEntity : IdParseEntity
            //where TParseViewModel : ViewModel
        {
            e.ObjectId = vm.ObjectId;//.ToString();
            e.CreatedAt = vm.CreatedAt;
            e.UpdatedAt = vm.CreatedAt;
            e.LocallyUpdatedAt = vm.CreatedAt;
        }

        private void UpdateMapper<TParseEntity>(TParseEntity e, BatchElementResponseVM vm)
            where TParseEntity : IdParseEntity
            //where TParseViewModel : ViewModel
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