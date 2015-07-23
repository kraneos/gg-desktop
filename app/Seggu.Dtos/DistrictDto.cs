using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class DistrictDto : KeyValueDto
    {
        public string ProvinceId { get; set; }
    }
}
