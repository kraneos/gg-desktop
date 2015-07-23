using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;


namespace Seggu.Services
{
    public sealed class VehicleService : IVehicleService
    {
        private IVehicleDao vehicleDao;

        public VehicleService(IVehicleDao vehicleDao )
        {
            this.vehicleDao = vehicleDao;
        }

        public VehicleDto GetByPolicyId(string policyId)
        {
            var vehicle = vehicleDao.GetByPolicyId(new Guid(policyId));
            return VehicleDtoMapper.GetDto(vehicle);
        }

        public void Save(VehicleDto vehicle)
        {
            //bool isNew = vehicle.Id == null;
            var obj = VehicleDtoMapper.GetObjectWithCover(vehicle);
            //if (isNew)
            //    vehicleDao.Save(obj);
            //else
                vehicleDao.SaveVehicle(obj);
        }
    }

}
