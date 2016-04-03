using Seggu.Api.Data;
using Seggu.Api.Domain;
using Seggu.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seggu.Api.Controllers
{
    public abstract class BaseApiController<T> : ApiController where T : IdEntity
    {
        private SegguContext context;

        public BaseApiController()
        {
            this.context = SegguContext.Create();
        }

        public IEnumerable<T> Get([FromUri]ApiFilter filter)
        {
            var query = this.context.Set<T>()
                .Where(x => filter.From != null && x.UpdatedAt > filter.From);
            var resQuery = filter.Page != null && filter.Count != null ?
                query.Skip(filter.Count.Value * filter.Page.Value).Take(filter.Count.Value) :
                query;
            return resQuery;
        }

        // GET: api/Default/5
        public T Get(Guid id)
        {
            var query = this.context.Set<T>().Find(id);
            return query;
        }

        // POST: api/Default
        [Route("api/{controller}")]
        [HttpPost]
        public T Post([FromBody]T value)
        {
            var query = this.context.Set<T>().Add(value);
            this.context.SaveChanges();
            return query;
        }

        // PUT: api/Default/5
        public T Put(Guid id, [FromBody]T value)
        {
            var query = this.context.Set<T>().Find(id);
            var entry = this.context.Entry<T>(query);
            entry.CurrentValues.SetValues(value);
            this.context.SaveChanges();
            return query;
        }

        // DELETE: api/Default/5
        public void Delete(Guid id)
        {
        }

        public List<BatchResponse<T>> Batch([FromBody]BatchRequest<T> req)
        {
            var res = new List<BatchResponse<T>>();
            using (var trax = this.context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var reqElement in req.Requests)
                    {
                        if (reqElement.Method == "POST")
                        {
                            var obj = this.context.Set<T>().Add(reqElement.Body);
                            res.Add(new BatchResponse<T> { Success = obj, Error = null });
                        }
                        else if (reqElement.Method == "PUT")
                        {
                            var obj = this.context.Set<T>().Find(reqElement.Id);
                            res.Add(new BatchResponse<T> { Success = obj, Error = null });
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
