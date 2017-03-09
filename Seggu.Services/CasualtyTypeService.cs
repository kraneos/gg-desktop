using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class CasualtyTypeService : ICasualtyTypeService
    {
        private ICasualtyTypeDao casualtyTypeDao;

        public CasualtyTypeService(ICasualtyTypeDao casualtyTypeDao)
        {
            this.casualtyTypeDao = casualtyTypeDao;
        }

        public IEnumerable<CasualtyTypeDto> GetAll()
        {
            var casualtyTypes = this.casualtyTypeDao.GetAll();
            return casualtyTypes.OrderBy(x => x.Name).Select(ct => CasualtyTypeDtoMapper.GetDto(ct));
        }
    }
}
