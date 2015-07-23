using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IPolicyDao : IGenericDao<Policy>
    { 
        IEnumerable<Policy> GetByPolicyNumber(string polNum);
        IEnumerable<Policy> GetByVehiclePlate(string plate);
        IEnumerable<Policy> GetValidsByClient(Guid clientId);
        IEnumerable<Policy> GetNotValidsByClient(Guid clientId);
        void Edit(Policy newPolicy);
    }
}
