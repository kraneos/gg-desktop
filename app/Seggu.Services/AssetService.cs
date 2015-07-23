using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class AssetService : IAssetService
    {
        private IAssetDao assetDao;
        public AssetService(IAssetDao assetDao)
        {
            this.assetDao = assetDao;
        }

        public IEnumerable<AssetDto> GetAll()
        {
            var assets = this.assetDao.GetAll().OrderBy(x => x.Name);
            return
                from x in assets
                select AssetDtoMapper.GetDto(x);
        }

        public void Create(AssetDto asset)
        {
            this.assetDao.Save(AssetDtoMapper.GetObject(asset));
        }
        public void Update(AssetDto asset)
        {
            this.assetDao.Update(AssetDtoMapper.GetObject(asset));
        }
    }
}
