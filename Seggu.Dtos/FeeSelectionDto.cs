﻿using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class FeeSelectionDto : KeyValueDto
    {
        public decimal Total { get; set; }

        public string Notes { get; set; }

        public int LiquidationId { get; set; }
    }
}
