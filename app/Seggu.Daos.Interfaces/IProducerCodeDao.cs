using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IProducerCodeDao: IGenericDao<ProducerCode>
    {
        bool ProducerHasCompany(System.Guid id);

        IEnumerable<ProducerCode> GetByCompany(System.Guid id);

        ProducerCode GetByCompanyProducer(System.Guid companyId, System.Guid producerId);
        
    }
}
