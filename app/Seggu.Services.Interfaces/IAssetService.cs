using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface IAssetService
    {
        IEnumerable<AssetDto> GetAll();

        void Update(AssetDto asset);
        //void Delete(string id);

        void Create(AssetDto asset);
    }
}
