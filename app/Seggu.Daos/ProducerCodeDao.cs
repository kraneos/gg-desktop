using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public class ProducerCodeDao: GenericDao<ProducerCode>, IProducerCodeDao
    {
        public ProducerCodeDao()
            : base()
        {
        }

        public bool ProducerHasCompany(long id)
        {
            var prod = this.Set.Any(p => p.ProducerId == id);
            return prod;
        }
        public IEnumerable<ProducerCode> GetByCompany(long id)
        {
            return
                from p in this.Set
                where p.CompanyId == id
                select p;
        }
        public ProducerCode GetByCompanyProducer(long companyId, long producerId)
        {
            var producerCode = (from p in this.Set
                 where p.CompanyId == companyId && p.ProducerId == producerId
                select p).SingleOrDefault();

            return producerCode;          
        }

        public override void Update(ProducerCode obj)
        {
        }
    }
}
