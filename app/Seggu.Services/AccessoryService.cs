using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class AccessoryService : IAccessoryService
    {
        private IAccessoryDao accessoryDao;
        public AccessoryService(IAccessoryDao accessoryDao)
        {
            this.accessoryDao = accessoryDao;
        }
        public IEnumerable<AccessoryDto> GetByVehicleId(string id)
        {
            var vehicleId = new Guid(id);
            var list = this.accessoryDao.GetByVehicleId(vehicleId);
            return list.OrderByDescending(x => x.ExpirationDate)
                .Select(x => AccessoryDtoMapper.GetDto(x));
        }

        public void Save(AccessoryDto dto)
        {
            var isNew = string.IsNullOrEmpty(dto.Id);
            var accessory = AccessoryDtoMapper.GetObject(dto);

            if (isNew)
                accessoryDao.Save(accessory);
            else
                accessoryDao.Update(accessory);
        }
    }
}
