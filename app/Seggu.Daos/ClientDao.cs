using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class ClientDao : IdParseEntityDao<Client>, IClientDao
    {
        public ClientDao()
            : base()
        {
        }

        public IEnumerable<Client> GetByDni(string search)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                        from c in context.Clients
                        where c.Document.StartsWith(search)
                        select c;
            }
        }

        public IEnumerable<Client> GetByFullName(string search)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var clients =
                        from c in context.Clients
                        where string.Concat(c.LastName.ToLower(), " ", c.FirstName.ToLower()).Contains(search.ToLower())
                        select c;
                return clients; 
            }
        }

        public IEnumerable<Client> GetValids()
        {
            using (var context = SegguDataModelContext.Create())
            {
                var clients =
                        from c in context.Clients
                        join p in context.Policies
                        on c.Id equals p.ClientId
                        where p.EndDate > DateTime.Today
                        && p.IsAnnulled == false
                        select c;
                return clients; 
            }
        }

        public bool ExistsDocument(string dni)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Clients.Any(x => x.Document == dni); 
            }
        }

        public override void Update(Client obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Clients.Find(obj.Id);
                Mapper.Map<Client, Client>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}
