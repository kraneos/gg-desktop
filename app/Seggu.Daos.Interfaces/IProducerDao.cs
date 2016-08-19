using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IProducerDao : IParseIdEntityDao<Producer>
    {
        List<Producer> GetCollectors();
        bool GetByRegistrationNumberId(string registrationNumber, long id);
        bool GetByRegistrationNumber(string registrationNumber);
        List<ProducerCode> GetByCompanyId(int id);
    }
}
