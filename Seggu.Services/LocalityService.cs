using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class LocalityService : ILocalityService
    {
        private ILocalityDao localityDao;

        public LocalityService(ILocalityDao localityDao)
        {
            this.localityDao = localityDao;
        }

        public IEnumerable<LocalityDto> GetByDistrictId(int districtId)
        {
            var Id = districtId;
            return
                from d in this.localityDao.GetByDistrictId(Id)
                select LocalityDtoMapper.GetDto(d);
        }

        public IEnumerable<LocalityDto> GetAll()
        {
            return localityDao.GetAll().Select(x => LocalityDtoMapper.GetDto(x));
        }

    }
}
