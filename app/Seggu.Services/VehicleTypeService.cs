using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class VehicleTypeService : IVehicleTypeService
    {
        private IVehicleTypeDao VehicleTypeDao;

        public VehicleTypeService(IVehicleTypeDao VehicleTypeDao)
        {
            this.VehicleTypeDao = VehicleTypeDao;
        }

        public VehicleTypeDto Get(int vehicleTypeId)
        {
            return VehicleTypeDtoMapper.GetDto(this.VehicleTypeDao.Get(vehicleTypeId));
        }

        public IEnumerable<VehicleTypeDto> GetAll()
        {
            var vehicletype = this.VehicleTypeDao.GetAll();
            return vehicletype.OrderBy(x => x.Name).Select(vt => VehicleTypeDtoMapper.GetDto(vt));
        }
        public void Save(VehicleTypeDto vType)
        {
            //vType.Id = Guid.Empty.ToString();
            var b = VehicleTypeDtoMapper.GetObject(vType);
            this.VehicleTypeDao.Save(b);
        }

        public void Delete(int id)
        {
            try
            {
                var guid = id;
                VehicleTypeDao.Delete(guid);
            }
            catch
            {
                throw;
            }
        }

        public bool ExistName(string name)
        {
            return VehicleTypeDao.GetByName(name);
        }
    }
}
