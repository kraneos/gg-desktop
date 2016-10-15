using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
using Seggu.Services.DtoMappers;

namespace Seggu.Services
{
    public sealed class ProvinceService : IProvinceService
    {
        private IProvinceDao provinceDao;

        public ProvinceService(IProvinceDao provinceDao)
        {
            this.provinceDao = provinceDao;
        }

        public IEnumerable<ProvinceDto> GetAll()
        {
            return
                from p in this.provinceDao.GetAll().OrderBy(x => x.Name)
                select ProvinceDtoMapper.GetDto(p);
        }
    }
}
