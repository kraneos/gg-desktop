using System;
using System.Collections.Generic;


namespace Seggu.Dtos
{
    [Serializable]
    public class CasualtyDto : EntityWithIdDto
    {
        public int PolicyId { get; set; }
        public string Number { get; set; }
        public int CasualtyTypeId { get; set; }
        public string FilePath { get; set; }
        public bool OurCharge { get; set; }
        public string OccurredDate { get; set; }
        public string ReceiveDate { get; set; }
        public string PoliceReportDate { get; set; }
        public decimal EstimatedCompensation { get; set; }
        public decimal DefinedCompensation { get; set; }
        public string Notes { get; set; }

        public string Producer { get; set; }
        //public IEnumerable<VehicleDto> Vehicles { get; set; }
        //public ClientFullDto Client { get; set; }//por que trae esto?
    }

}
