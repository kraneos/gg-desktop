using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Seggu.Daos
{
    public class ProducerDao : IdParseEntityDao<Producer>, IProducerDao
    {
        public ProducerDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public IEnumerable<Producer> GetCollectors()
        {
            return
                from p in this.Set
                where p.IsCollector
                select p;
        }

        public bool GetByRegistrationNumberId(string registrationNumber, long id )
        {
           var prod = this.Set.FirstOrDefault(p => p.RegistrationNumber == registrationNumber);
           if (prod == null)
           {
               return false;
           }
           else if (prod.Id == id)
           {
               return false;
           }
           return true;
        }

        public bool GetByRegistrationNumber(string registrationNumber)
        {
            var prod = this.Set.FirstOrDefault(p => p.RegistrationNumber == registrationNumber);
            if (prod == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<ProducerCode> GetByCompanyId(int id)
        {
            return context
                .ProducerCodes
                .Include("Producer")
                .Where(pc => pc.CompanyId == id);
        }
    }
}
