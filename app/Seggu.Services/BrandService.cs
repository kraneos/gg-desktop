using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class BrandService : IBrandService
    {
        private IBrandDao brandDao;

        public BrandService(IBrandDao brandDao)
        {
            this.brandDao = brandDao;
        }

        public IEnumerable<BrandDto> GetAll()
        {
            var brands = this.brandDao.GetAll();
            return brands.OrderBy(x => x.Name).Select(b => BrandDtoMapper.GetDto(b));
        }

        public void Update(BrandDto brand)
        {
            this.brandDao.Update(BrandDtoMapper.GetObject(brand));
        }

        public void Save(BrandDto brand)
        {
            brand.Id = Guid.Empty.ToString();
            var b = BrandDtoMapper.GetObject(brand);
            this.brandDao.Save(b);
        }

        public BrandDto Get(string brandId)
        {
            return BrandDtoMapper.GetDto(this.brandDao.Get(new Guid(brandId)));
        }

        public void Delete(string id)
        {
            try
            {
                var guid = new Guid(id);
                brandDao.Delete(guid);
            }
            catch
            {
                throw;
            }
        }

        public bool ExistName(string name)
        {
            return brandDao.GetByName(name);
        }
    }
}
