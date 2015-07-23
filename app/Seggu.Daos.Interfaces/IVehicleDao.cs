using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleDao : IGenericDao<Vehicle>
    {
        Vehicle GetByPolicyId(Guid PolicyId);
        IEnumerable<Vehicle> GetByPlate(string plate);
        void SaveVehicle(Vehicle vehicle);
    }
}
