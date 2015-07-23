using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Transactions;

namespace Seggu.Daos
{
    public class ProducerCodeDao: GenericDao<ProducerCode>, IProducerCodeDao
    {
        public override void Save(ProducerCode obj)
        {
            using (var scope = new TransactionScope())
            {
                Set.Add(obj);
                container.SaveChanges();
                scope.Complete();
            }
        }

        public bool ProducerHasCompany(Guid id)
        {
            var prod = this.Set.Any(p => p.ProducerId == id);
            return prod;
        }


        public IEnumerable<ProducerCode> GetByCompany(Guid id)
        {
            return
                from p in this.Set
                where p.CompanyId == id
                select p;
        }


        public ProducerCode GetByCompanyProducer(Guid companyId, Guid producerId)
        {
            var producerCode = (from p in this.Set
                 where p.CompanyId == companyId && p.ProducerId == producerId
                select p).SingleOrDefault();

            return producerCode;
                
                
        }
    }
}
