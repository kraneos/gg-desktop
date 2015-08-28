using Seggu.Daos.Interfaces;
using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class DistrictService : IDistrictService
    {
        private IDistrictDao districtDao;
        public DistrictService(IDistrictDao districtDao)
        {
            this.districtDao = districtDao;
        }
        public IEnumerable<DistrictDto> GetFilteredByProvince(int provinceId)
        {
            var provId = provinceId;
            var districts = districtDao.GetByProvince(provId);
            return districts.OrderBy(x => x.Name).Select(x => DistrictDtoMapper.GetDto(x));
        }
        public IEnumerable<DistrictDto> GetAll()
        {
            return districtDao.GetAll().Select(x => DistrictDtoMapper.GetDto(x));
        }
    }
}
