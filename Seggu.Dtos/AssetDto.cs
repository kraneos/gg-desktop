using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class AssetDto : KeyValueDto
    {
        public decimal Amount { get; set; }
    }
}
