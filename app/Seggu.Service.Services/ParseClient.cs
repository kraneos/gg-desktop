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
using Parse;
using System.Threading.Tasks;

namespace Seggu.Service.Services
{
    public class ParseClient
    {
        //private RestSharp.RestClient restClient;
        private EventLog eventLog;
        private SegguDataModelContext context;
        //private string token;
        private readonly string[] parseProps = new string[] { "ObjectId", "CreatedAt", "UpdatedAt", "LocallyUpdatedAt" };
        private readonly Type[] parseKnownTypes = new Type[] { typeof(string), typeof(bool), typeof(decimal), typeof(decimal?), typeof(DateTime), typeof(DateTime?), typeof(int), typeof(int?) };
        private Setting setting;

        public ParseClient(SegguDataModelContext context, EventLog eventLog)
        {
            this.eventLog = eventLog;
            this.context = context;
            //this.restClient = new RestClient(Settings.Default.ParseBaseUrl);
            //SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializationStrategy();
            this.setting = context.Settings.OrderByDescending(x => x.Id).FirstOrDefault();
            Parse.ParseClient.Initialize(new Parse.ParseClient.Configuration
            {
                ApplicationId = Settings.Default.ParseAppId,
                Server = Settings.Default.ParseBaseUrl,
            });
            //if (Parse.ParseUser.CurrentUser != null)
            //{
            //    Parse.ParseUser.LogOut();
            //}
            if (setting != null && ParseUser.CurrentUser == null)
            {
                ParseUser.LogInAsync(setting.Username, setting.Password).Wait();
            }
        }

        //private IEnumerable<T> SerializeCollectionResponse<T>(string content) where T : new()
        //{
        //    return JsonConvert.DeserializeObject<ParseQueryResult<T>>(content).Results;
        //}

        //private RestRequest GetRequest(string resource, Method method)
        //{
        //    //var token = this.GetToken();

        //    var req = new RestRequest(resource, method);
        //    req.AddHeader("Content-Type", "application/json");
        //    //req.AddHeader("Authorization", "Bearer " + token);
        //    req.AddHeader("X-Parse-Application-Id", Properties.Settings.Default.ParseAppId);
        //    req.AddHeader("X-Parse-REST-API-Key", Properties.Settings.Default.ParseSecretKey);
        //    req.RequestFormat = DataFormat.Json;
        //    return req;
        //}

        //private string GetToken()
        //{
        //    if (string.IsNullOrWhiteSpace(this.token))
        //    {
        //        var req = new RestRequest("/token", Method.POST);
        //        req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //        req.AddHeader("Accept", "application/json");

        //        var body = "grant_type=password&username=" + Properties.Settings.Default.Username + "&password=" + Properties.Settings.Default.Password;

        //        req.AddBody(body);

        //        var res = this.restClient.Execute(req);

        //        this.token = JsonConvert.DeserializeObject<TokenResponseVM>(res.Content).AccessToken;
        //    }

        //    return this.token;
        //}

        public async Task<IEnumerable<TParseEntity>> CreateEntities<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> newEntities
            //string parseEntityName
            )
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            return await ExecuteManyRequests<TParseEntity, TViewModel>(
                 newEntities,
                 //parseEntityName,
                 "POST",
                 CreateMapper);
        }

        public async Task<IEnumerable<TParseEntity>> UpdateEntities<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> updatedEntities
            //string parseEntityName
            )
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            return await ExecuteManyRequests<TParseEntity, TViewModel>(
                updatedEntities,
                //parseEntityName,
                "PUT",
                UpdateMapper,
                (x, y) => x + y.ObjectId);
        }

        public async Task GetManyEntities<TParseEntity, TViewModel>(Synchronization lastSync)//string parseEntityName, Synchronization lastSync)
            where TParseEntity : IdParseEntity, new()
            where TViewModel : ViewModel
        {
            var page = 0;
            var thisSync = DateTime.Now.ToUniversalTime();

            IEnumerable<TParseEntity> entities = new List<TParseEntity>();

            while (page == 0 || entities.Any())
            {
                entities = await GetEntities<TParseEntity, TViewModel>(
                    //parseEntityName, 
                    page * 100, 100, lastSync == null ? null : (DateTime?)lastSync.LastSync);
                MergeEntities<TParseEntity>(entities);
                page++;
            }

            lastSync.LastSync = thisSync;
        }

        private void MergeEntities<TParseEntity>(IEnumerable<TParseEntity> entities) where TParseEntity : IdParseEntity
        {
            var objectIds = entities.Select(x => x.ObjectId);
            var existingEntities = this.context.Set<TParseEntity>()
                .Where(x => objectIds.Contains(x.ObjectId)).ToList();
            var newEntities = entities
                .Where(x => !existingEntities.Any(y => y.ObjectId == x.ObjectId));

            this.context.Set<TParseEntity>().AddRange(newEntities);

            foreach (var entity in existingEntities)
            {
                var apiEntity = entities.First(x => x.ObjectId == entity.ObjectId);
                if (apiEntity.UpdatedAt > entity.LocallyUpdatedAt)
                {
                    var entry = this.context.Entry<TParseEntity>(entity);
                    apiEntity.Id = entity.Id;
                    entry.CurrentValues.SetValues(apiEntity);
                }
            }

            this.context.SaveChanges();
        }

        private async Task<IEnumerable<TParseEntity>> GetEntities<TParseEntity, TViewModel>(
            //string parseEntityName, 
            int page, int count, DateTime? from)
            where TParseEntity : IdParseEntity, new()
            where TViewModel : ViewModel
        {
            var query = new ParseQuery<TViewModel>()
                .Skip(page)
                .Limit(count);

            //var path = "/classes/" + parseEntityName;

            //var req = GetRequest(path, Method.GET);

            //req.AddParameter("skip", page.ToString());
            //req.AddParameter("limit", count.ToString());
            if (from != null && from > DateTime.MinValue)
            {
                //req.AddParameter("where", "{\"updatedAt\":{\"$gt\":" + JsonConvert.SerializeObject(new DateVM(from.Value)) + "}}");
                query = query.WhereGreaterThan("updatedAt", from.Value.ToUniversalTime());
            }

            //this.eventLog.WriteEntry("About to execute query for " + parseEntityName);

            //var res = this.restClient.Execute(req);
            //if (res.StatusCode == HttpStatusCode.OK)
            var res = await query.FindAsync();
            if (res != null)
            {
                //this.eventLog.WriteEntry(parseEntityName + " everything ok.");
                //return JsonConvert.DeserializeObject<ParseQueryResponseVM<TViewModel>>(res.Content)
                //    .Results
                //    .Select(Mapper.Map<TViewModel, TParseEntity>)
                //    .ToList();
                return res
                    //.Select(MapToEntity<TParseEntity>)
                    .Select(x => Mapper.Map<TViewModel, TParseEntity>(x, opt => AutoMapperExtensions.SetOptions(opt, setting, context, string.Empty)))
                    .ToList();
            }
            else
            {
                //this.eventLog.WriteEntry("HTTPCODE: " + res.StatusDescription + "\n" + res.Content, EventLogEntryType.Error);
                return new List<TParseEntity>();
            }
        }

        public async Task<IEnumerable<TParseEntity>> ExecuteManyRequests<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> entities,
            //string parseEntityName,
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

                await ExecuteRequests<TParseEntity, TViewModel>(
                    entitiesToExecute,
                    //parseEntityName,
                    statusCode,
                    callback);

                context.SaveChanges();
            }

            return entities;
        }

        public async Task<IEnumerable<TParseEntity>> ExecuteRequests<TParseEntity, TViewModel>(
            IEnumerable<TParseEntity> entities,
            //string parseEntityName,
            string statusCode,
            Action<TParseEntity, TViewModel> callback,
            Func<string, TParseEntity, string> resourceNameResolver = null)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            var parseObjects = entities
                .Select(
                    x =>
                        Mapper.Map<TParseEntity, TViewModel>(x,
                            opt => AutoMapperExtensions.SetOptions(opt, setting, context, statusCode)))
                .Select((x, i) => new { x, i })
                .Where(x =>
                    x != null && (
                    x.x.ACL.PublicWriteAccess ||
                    x.x.ACL.GetWriteAccess(ParseUser.CurrentUser) ||
                    x.x.ACL.GetRoleWriteAccess(setting.UserRole)))
                .ToDictionary(x => x.i, x => x.x);
//#if DEBUG
//            foreach(var x in parseObjects)
//            {
//                this.eventLog.WriteEntry("entidad " + typeof(TParseEntity).Name + " :: " + JsonConvert.SerializeObject(x), EventLogEntryType.Information);
//            }
//#endif
            await parseObjects.Values.SaveAllAsync<TViewModel>();

            var count = entities.Count();
            for (int i = 0; i < count; i++)
            {
                if (parseObjects.ContainsKey(i))
                {
                    var vm = parseObjects[i];
                    var e = entities.ElementAt(i);
                    callback.Invoke(e, vm);
                }
            }

            return entities;
            //var req = GetRequest("/batch", Method.POST);

            //var batch = new BatchRequest<TViewModel>();
            //batch.Requests = entities.Select(e => new BatchElement<TViewModel>
            //{
            //    Method = statusCode,
            //    Path = $"/parse/classes/{parseEntityName}" + (statusCode == "PUT" ? ($"/{e.ObjectId}") : string.Empty),
            //    Body = Mapper.Map<TParseEntity, TViewModel>(e)
            //});

            //this.eventLog.WriteEntry("About to execute batch for " + parseEntityName);
            //req.SetBody(batch);
            //var res = this.restClient.Execute(req);
            //if (res.StatusCode == HttpStatusCode.OK)
            //{
            //    this.eventLog.WriteEntry(parseEntityName + " everything ok.");
            //    var data = JsonConvert.DeserializeObject<List<BatchResponse>>(res.Content);
            //    var count = entities.Count();
            //    for (int i = 0; i < count; i++)
            //    {
            //        var vm = data.ElementAt(i);
            //        var e = entities.ElementAt(i);
            //        if (vm.Success != null)
            //        {
            //            callback.Invoke(e, vm.Success);
            //        }
            //    }

            //    return entities;
            //}
            //else
            //{
            //    this.eventLog.WriteEntry("HTTPCODE: " + res.StatusDescription + "\n" + res.Content, EventLogEntryType.Error);
            //    return null;
            //}
        }

        private ParseObject MapToParseObject<T>(T entity) where T : IdParseEntity
        {
            var type = typeof(T);
            var parseObject = new ParseObject(type.Name);

            foreach (var prop in type.GetProperties().Where(p => parseProps.Any(x => x != p.Name) && parseKnownTypes.Any(x => x == p.PropertyType)))
            {
                if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
                {
                    var dec = prop.GetValue(entity);
                    if (dec == null)
                    {
                        parseObject.Add(prop.Name, null);
                    }
                    else
                    {
                        parseObject.Add(prop.Name, Convert.ToDouble(dec));
                    }
                }
                else
                {
                    parseObject.Add(prop.Name, prop.GetValue(entity));
                }
            }

            return parseObject;
        }

        private ParseObject MapToNewParseObject<T>(T entity) where T : IdParseEntity
        {
            var parseObject = MapToParseObject(entity);
            ParseACL acl = GetAcl();
            parseObject.ACL = acl;
            return parseObject;
        }

        private ParseACL GetAcl()
        {
            var acl = new ParseACL(ParseUser.CurrentUser);

            if (setting != null)
            {
                acl.SetRoleReadAccess(setting.UserRole, true);
                acl.SetRoleReadAccess(setting.ClientsRole, true);
                acl.SetRoleWriteAccess(setting.UserRole, true);
                acl.SetRoleWriteAccess(setting.ClientsRole, true);
            }
            acl.PublicReadAccess = false;
            acl.PublicWriteAccess = false;

            return acl;
        }

        private T MapToEntity<T>(ParseObject parseObject) where T : IdParseEntity, new()
        {
            var entity = new T();
            var type = typeof(T);

            foreach (var prop in type.GetProperties().Where(p => parseProps.Any(x => x != p.Name)))
            {
                prop.SetValue(entity, parseObject[prop.Name]);
                //parseObject.Add(prop.Name, prop.GetValue(entity));
            }

            entity.ObjectId = parseObject.ObjectId;
            entity.CreatedAt = parseObject.CreatedAt;
            entity.UpdatedAt = parseObject.UpdatedAt;

            return entity;
        }

        #region MethodMappers
        private void CreateMapper<TParseEntity, TParseViewModel>(TParseEntity e, TParseViewModel vm)
            where TParseEntity : IdParseEntity
            where TParseViewModel : ViewModel
        {
            e.ObjectId = vm.ObjectId;//.ToString();
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

        internal bool HasSetting()
        {
            return setting != null;
        }

        #endregion
    }

    //public static class RestRequestExtensions
    //{
    //    public static IRestRequest SetBody(this RestRequest req, object obj)
    //    {
    //        var json = JsonConvert.SerializeObject(obj);
    //        req.AddParameter("application/json", json, ParameterType.RequestBody);

    //        return req;
    //    }
    //}
}