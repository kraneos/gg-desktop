using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class LocalityDto : KeyValueDto
    {
        public string DistrictId { get; set; }
    }
}
