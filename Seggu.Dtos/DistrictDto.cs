using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class DistrictDto : KeyValueDto
    {
        public int ProvinceId { get; set; }
    }
}
