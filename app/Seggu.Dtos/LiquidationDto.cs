using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class LiquidationDto : EntityWithIdDto
    {
        public string Compañía { get; set; }

        public int CompanyId { get; set; }

        public string Fecha { get; set; }

        public string Recepción { get; set; }

        public bool Registered { get; set; }

        public decimal Total { get; set; }

        public string Notas { get; set; }

        IEnumerable<FeeSelectionDto> FeeSelections { get; set; }

    }
}
