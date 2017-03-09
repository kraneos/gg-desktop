using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IVehicleService
    {
        VehicleDto GetByPolicyId(int policyId);
        void Save(VehicleDto vehicle);
    }
}
