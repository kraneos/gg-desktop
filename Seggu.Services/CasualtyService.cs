using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public class CasualtyService : ICasualtyService
    {
        private ICasualtyDao casualtyDao;

        public CasualtyService(ICasualtyDao casualtyDao)
        {
            this.casualtyDao = casualtyDao;
        }

        public IEnumerable<CasualtyDto> GetByPolicyId(int id)
        {
            var policyId = id;
            var casualties = this.casualtyDao.GetByPolicyId(policyId).OrderBy(X => X.Number);
            return casualties.Select(x => CasualtyDtoMapper.GetDto(x));
        }

        public void Save(CasualtyDto dto)
        {
            var isNew = dto.Id == default(int);
            var casualty = CasualtyDtoMapper.GetObject(dto);

            if (isNew)
                casualtyDao.Save(casualty);
            else
                casualtyDao.Update(casualty);
        }

    }
}
