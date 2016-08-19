using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class BodyworkService : IBodyworkService
    {
        private IBodyworkDao bodyworkDao;

        public BodyworkService(IBodyworkDao bodyworkDao)
        {
            this.bodyworkDao = bodyworkDao;
        }
        public void Save(BodyworkDto bodywork)
        {
            //bodywork.Id = Guid.Empty.ToString();
            var b = BodyworkDtoMapper.GetObject(bodywork);
            this.bodyworkDao.Save(b);
        }
        public IEnumerable<BodyworkDto> GetAll()
        {
            var bodyworks = this.bodyworkDao.GetAll();
            return bodyworks.OrderBy(x => x.Name).Select(b => BodyworkDtoMapper.GetDto(b));
        }
        public void Delete(int id)
        {
            try
            {
                var guid = id;
                bodyworkDao.Delete(guid);
            }
            catch
            {
                throw;
            }
        }
        public bool ExistName(string name)
        {
            return bodyworkDao.GetByName(name);
        }
        public IEnumerable<BodyworkDto> GetByVehicleType(int vehicleTypeId)
        {
            var bodyworks = this.bodyworkDao.GetByVehicleType(vehicleTypeId);
            return bodyworks.Select(b => BodyworkDtoMapper.GetDto(b));
        }
        public void SaveChanges(VehicleTypeDto vehicleTypeDto, IEnumerable<BodyworkDto> existing) => this.bodyworkDao.SaveChanges(VehicleTypeDtoMapper.GetObject(vehicleTypeDto), existing.Select(BodyworkDtoMapper.GetObject).ToList());
    }
}
