using System;

namespace Seggu.Service.ViewModels
{
    public class PolicyVM : ViewModel
    {
        public string PreviousNumber { get; set; }
        public Guid ClientId { get; set; }
        public int Period { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime RequestDate { get; set; }
        public Nullable<System.DateTime> ReceptionDate { get; set; }
        public Nullable<System.DateTime> EmissionDate { get; set; }
        public decimal Prima { get; set; }
        public decimal Premium { get; set; }
        public decimal Surcharge { get; set; }
        public Nullable<decimal> Bonus { get; set; }
        public decimal Value { get; set; }
        public string Notes { get; set; }
        public string Number { get; set; }
        public bool IsRenovated { get; set; }
        public bool IsAnnulled { get; set; }
        public Nullable<System.DateTime> AnnulationDate { get; set; }
        public bool IsRemoved { get; set; }
        public Guid ProducerId { get; set; }
        public Nullable<Guid> CollectorId { get; set; }
        public Guid RiskId { get; set; }
    }
}