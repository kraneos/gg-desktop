using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Seggu.Dtos;

namespace Seggu.Daos
{
    public sealed class ClientDao : IdParseEntityDao<Client>, IClientDao
    {
        public ClientDao()
            : base()
        {
        }

        public List<ClientIndexDto> GetByDni(string search)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                        (from c in context.Clients
                         where c.Document.StartsWith(search)
                         select Mapper.Map<ClientIndexDto>(c)).ToList();
            }
        }

        public List<ClientIndexDto> GetByFullName(string search)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var clients =
                        from c in context.Clients
                        where string.Concat(c.LastName.ToLower(), " ", c.FirstName.ToLower()).Contains(search.ToLower())
                        select Mapper.Map<ClientIndexDto>(c);
                return clients.ToList();
            }
        }

        public List<Client> GetValids()
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
                return clients.ToList();
            }
        }

        public bool ExistsDocument(string dni)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Clients.Any(x => x.Document == dni);
            }
        }

        public ClientFullDto GetFull(int id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return Mapper.Map<ClientFullDto>(context.Clients.Find(id));
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
