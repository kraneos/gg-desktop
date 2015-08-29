using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IProducerCodeDao: IGenericDao<ProducerCode>
    {
        bool ProducerHasCompany(long id);

        IEnumerable<ProducerCode> GetByCompany(long id);

        ProducerCode GetByCompanyProducer(long companyId, long producerId);
        
    }
}
