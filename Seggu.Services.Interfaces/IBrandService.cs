using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetAll();

        void Update(BrandDto brand);

        void Save(BrandDto brand);

        BrandDto Get(int brandId);

        void Delete(int Id);
        bool ExistName(string name);

        bool HasRelatedRecords(int id);
    }
}
