using AutoMapper;
using Microsoft.AspNet.Identity;
using Seggu.Api.Data;
using Seggu.Api.Domain;
using Seggu.Api.Models;
using Seggu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Seggu.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/{controller}")]
    public abstract class BaseApiController<T, TVM> : ApiController
        where T : IdEntity
        where TVM : ViewModel
    {
        protected SegguContext context;
        protected string userId;
        protected Guid segguClientId;

        public BaseApiController()
        {
            this.context = SegguContext.Create();
            this.userId = User.Identity.GetUserId();
            this.segguClientId = this.context.Users
                .Where(x => x.Id == this.userId)
                .Select(x => x.SegguClientId)
                .First();
        }

        [Route("")]
        public IEnumerable<TVM> Get([FromUri]ApiFilter filter)
        {
            var query = this.context.Set<T>()
                .Where(x=>x.SegguClientId == segguClientId)
                .Where(x => (filter.From != null && x.UpdatedAt > filter.From) || filter.From == null);
            var resQuery = filter.Page != null && filter.Count != null ?
                query.Skip(filter.Count.Value * filter.Page.Value).Take(filter.Count.Value) :
                query;
            return resQuery.Select(Mapper.Map<T, TVM>);
        }

        // GET: api/Default/5
        [Route("{id}")]
        public TVM Get(Guid id)
        {
            var query = this.context.Set<T>().Find(id);
            if (query.SegguClientId != this.segguClientId)
            {
                return null;
            }
            return Mapper.Map<T, TVM>(query);
        }

        // POST: api/Default
        [Route("")]
        [HttpPost]
        public TVM Post([FromBody]T value)
        {
            var query = this.context.Set<T>().Add(value);
            this.context.SaveChanges();
            return Mapper.Map<T, TVM>(query);
        }

        // PUT: api/Default/5
        [Route("{id}")]
        public TVM Put(Guid id, [FromBody]T value)
        {
            var query = this.context.Set<T>().Find(id);
            if (query.SegguClientId != this.segguClientId)
            {
                return null;
            }
            var entry = this.context.Entry<T>(query);
            entry.CurrentValues.SetValues(value);
            this.context.SaveChanges();
            return Mapper.Map<T, TVM>(query);
        }

        // DELETE: api/Default/5
        [Route("{id}")]
        public void Delete(Guid id)
        {
        }

        public List<BatchResponse<TVM>> Batch([FromBody]BatchRequest<T> req)
        {
            var res = new List<BatchResponse<TVM>>();
            using (var trax = this.context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var reqElement in req.Requests)
                    {
                        if (reqElement.Method == "POST")
                        {
                            var obj = this.context.Set<T>().Add(reqElement.Body);
                            res.Add(new BatchResponse<TVM> { Success = Mapper.Map<T, TVM>(obj), Error = null });
                        }
                        else if (reqElement.Method == "PUT")
                        {
                            var obj = this.context.Set<T>().Find(reqElement.Id);
                            if (obj.SegguClientId != this.segguClientId)
                            {
                                res.Add(new BatchResponse<TVM> { Success = null, Error = null });
                            }
                            res.Add(new BatchResponse<TVM> { Success = Mapper.Map<T, TVM>(obj), Error = null });
                            var entry = this.context.Entry<T>(obj);
                            entry.CurrentValues.SetValues(reqElement.Body);
                        }

                        this.context.SaveChanges();
                    }

                    trax.Commit();
                }
                catch
                {
                    trax.Rollback();
                    throw;
                }
            }

            return res;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
