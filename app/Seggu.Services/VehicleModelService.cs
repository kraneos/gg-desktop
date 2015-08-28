using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelDao VehicleModelDao;

        public VehicleModelService(IVehicleModelDao VehicleModelDao)
        {
            this.VehicleModelDao = VehicleModelDao;
        }

        public IEnumerable<VehicleModelDto> GetAll()
        {
            var models = this.VehicleModelDao.GetAll();
            return models.OrderBy(x => x.Name).Select(b => VehicleModelDtoMapper.GetDto(b));
        }

        public IEnumerable<VehicleModelDto> GetByBrand(int brandId)
        {
            var models = this.VehicleModelDao.GetAll();
            return models.OrderBy(x => x.Name)
                .Where(m => m.BrandId == brandId)
                .Select(b => VehicleModelDtoMapper.GetDto(b));
        }
        public void Save(VehicleModelDto model)
        {
            bool isNew = model.Id == default(int);
            var vehicleModel = VehicleModelDtoMapper.GetObject(model);
            if (isNew)
                VehicleModelDao.Save(vehicleModel);
            else
                VehicleModelDao.Update(vehicleModel);
        }
        public void Delete(VehicleModelDto model)
        {
            var vehicleModel = VehicleModelDtoMapper.GetObject(model);
            VehicleModelDao.Delete(vehicleModel.Id);
        }

        public void Delete(int id)
        {
            try
            {
                var guid = id;
                VehicleModelDao.Delete(guid);
            }
            catch
            {
                throw;
            }
        }

        public bool ExistName(string name)
        {
            return VehicleModelDao.GetByName(name);
        }
    }
}
