using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace Seggu.Daos
{
    public sealed class ClientDao : IdParseEntityDao<Client>, IClientDao
    {
        public ClientDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public IEnumerable<Client> GetByDni(string search)
        {
            return
                from c in this.Set
                where c.Document.StartsWith(search)
                select c;
        }

        public IEnumerable<Client> GetByFullName(string search)
        {
            var clients =
                from c in this.Set
                where string.Concat(c.LastName.ToLower(), " ", c.FirstName.ToLower()).Contains(search.ToLower())
                select c;
            return clients;
        }

        public IEnumerable<Client> GetValids()
        {
            var clients =
                from c in this.Set
                join p in this.context.Policies
                on c.Id equals p.ClientId
                where p.EndDate > DateTime.Today
                && p.IsAnnulled == false
                select c;
            return clients;
        }

        public bool ExistsDocument(string dni)
        {
            return this.Set.Any(x => x.Document == dni);
        }

        public override void Update(Client obj)
        {
            // Update Client Fields
            var orig = context.Clients.Find(obj.Id);
            Mapper.Map<Client, Client>(obj, orig);

            context.SaveChanges();
        }
    }
}
