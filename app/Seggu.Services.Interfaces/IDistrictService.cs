using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seggu.Data;
using Seggu.Dtos;

namespace Seggu.Services.Interfaces
{
    public interface IDistrictService
    {
        IEnumerable<DistrictDto> GetFilteredByProvince(string provinceId);
        IEnumerable<DistrictDto> GetAll();

    }
}
