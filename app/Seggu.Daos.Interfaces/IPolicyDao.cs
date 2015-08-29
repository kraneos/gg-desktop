using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IPolicyDao : IIdEntityDao<Policy>
    { 
        IEnumerable<Policy> GetByPolicyNumber(string polNum);
        IEnumerable<Policy> GetByVehiclePlate(string plate);
        IEnumerable<Policy> GetValidsByClient(long clientId);
        IEnumerable<Policy> GetNotValidsByClient(long clientId);
        void Edit(Policy newPolicy);
    }
}
