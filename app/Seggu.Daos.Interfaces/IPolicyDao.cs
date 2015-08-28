using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IPolicyDao : IGenericDao<Policy>
    { 
        IEnumerable<Policy> GetByPolicyNumber(string polNum);
        IEnumerable<Policy> GetByVehiclePlate(string plate);
        IEnumerable<Policy> GetValidsByClient(int clientId);
        IEnumerable<Policy> GetNotValidsByClient(int clientId);
        void Edit(Policy newPolicy);
    }
}
