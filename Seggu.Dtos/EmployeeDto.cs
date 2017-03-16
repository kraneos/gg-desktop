using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class EmployeeDto: EntityWithIdDto
    {
        public int PolicyId { get; set; }
        public int? EndorseId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string DNI { get; set; }
        public string CUIT { get; set; }
        public bool IsRemoved { get; set; }

        public decimal Suma { get; set; }

        public IEnumerable<CoverageDto> Coverages { get; set; }
    }
}
