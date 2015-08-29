using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public class ProducerDao : IdEntityDao<Producer>, IProducerDao
    {
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
    }
}
