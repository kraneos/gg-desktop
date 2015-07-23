using Seggu.Data;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IProducerDao : IGenericDao<Producer>
    {
        IEnumerable<Producer> GetCollectors();
        bool GetByRegistrationNumberId(string registrationNumber, System.Guid id);
        bool GetByRegistrationNumber(string registrationNumber);  
    }
}
