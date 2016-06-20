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

        public new void Update(Client obj)
        {
            // Update Client Fields
            var orig = context.Clients.Find(obj.Id);
            orig.FirstName = obj.FirstName;
            orig.LastName = obj.LastName;
            orig.CellPhone = obj.CellPhone;
            orig.Mail = obj.Mail;
            orig.Document = obj.Document;
            orig.BirthDate = obj.BirthDate;
            orig.Cuit = obj.Cuit;
            orig.IngresosBrutos = obj.IngresosBrutos;
            orig.CollectionTimeRange = obj.CollectionTimeRange;
            orig.BankingCode = obj.BankingCode;
            orig.Notes = obj.Notes;
            orig.IsSmoker = obj.IsSmoker;
            orig.Sex = obj.Sex;
            orig.IVA = obj.IVA;
            orig.MaritalStatus = obj.MaritalStatus;
            orig.DocumentType = obj.DocumentType;
            orig.Occupation = obj.Occupation;

            // Update Addresses Fields
            foreach (var origAddress in orig.Addresses)
            {
                var address = obj.Addresses.FirstOrDefault(x => x.Id == origAddress.Id);
                if (address == null) continue;
                origAddress.Street = address.Street;
                origAddress.Phone = address.Phone;
                origAddress.Number = address.Number;
                origAddress.Floor = address.Floor;
                origAddress.Appartment = address.Appartment;
                origAddress.LocalityId = address.LocalityId;
                origAddress.PostalCode = address.PostalCode;
                origAddress.AddressType = address.AddressType;
            }
            context.SaveChanges();
        }
    }
}
