using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class AccessoryTypeService : IAccessoryTypeService
    {
                
        private IAccessoryTypeDao AccessoryTypeDao;

        public AccessoryTypeService(IAccessoryTypeDao AccessoryTypeDao)
        {
            this.AccessoryTypeDao = AccessoryTypeDao;
        }

        public IEnumerable<AccessoryTypeDto> GetAll()
        {
            var AccessoryTypes = this.AccessoryTypeDao.GetAll();
            return AccessoryTypes.OrderBy(x => x.Name).Select(ct => AccessoryTypeDtoMapper.GetDto(ct));
        }
    }
}
