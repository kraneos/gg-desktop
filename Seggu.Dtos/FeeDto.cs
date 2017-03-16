using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class FeeDto : EntityWithIdDto
    {
        public int CompanyId { get; set; }
        public string Cliente { get; set; }
        public int ClientId { get; set; }
        public string Nro_Póliza { get; set; }
        public string Nro_Endoso { get; set; }
        public string Cuota { get; set; }
        public DateTime Venc_Cuota { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public decimal Pago_Cía { get; set; }
        public int PolicyId { get; set; }
        //public string Venc_Póliza { get; set; }
        public int FeeSelectionId { get; set; }
        public bool Annulated { get; set; }
        public string Estado { get; set; }
        public string Fecha_Liquidación { get; set; }
        public int EndorseId { get; set; }
    }
}
