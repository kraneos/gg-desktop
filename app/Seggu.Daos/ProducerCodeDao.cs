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
            using (var context = SegguDataModelContext.Create())
            {
                var prod = context.ProducerCodes.Any(p => p.ProducerId == id);
                return prod; 
            }
        }
        public IEnumerable<ProducerCode> GetByCompany(long id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    from p in context.ProducerCodes
                    where p.CompanyId == id
                    select p; 
            }
        }
        public ProducerCode GetByCompanyProducer(long companyId, long producerId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var producerCode = (from p in context.ProducerCodes
                                    where p.CompanyId == companyId && p.ProducerId == producerId
                                    select p).SingleOrDefault();

                return producerCode;
            }
        }

        public override void Update(ProducerCode obj)
        {
        }
    }
}
