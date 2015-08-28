using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IProducerCodeDao: IGenericDao<ProducerCode>
    {
        bool ProducerHasCompany(int id);

        IEnumerable<ProducerCode> GetByCompany(int id);

        ProducerCode GetByCompanyProducer(int companyId, int producerId);
        
    }
}
