using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class LocalityDto : KeyValueDto
    {
        public int DistrictId { get; set; }
    }
}
