using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IPolicyDao : IParseIdEntityDao<Policy>
    { 
        List<Policy> GetByPolicyNumber(string polNum);
        List<Policy> GetByVehiclePlate(string plate);
        List<Policy> GetValidsByClient(long clientId);
        List<Policy> GetNotValidsByClient(long clientId);
        void Edit(Policy newPolicy);
        List<Policy> GetRosView(DateTime from, DateTime to);
        bool ExistsByProducer(int producerId);
    }
}
