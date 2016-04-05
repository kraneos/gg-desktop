using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class EndorseVM : ViewModel
    {
        public int EndorseType { get; set; }
        public string Number { get; set; }
        public string Cause { get; set; }
        public long PolicyId { get; set; }
        public Nullable<long> ClientId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime RequestDate { get; set; }
        public Nullable<System.DateTime> ReceptionDate { get; set; }
        public Nullable<System.DateTime> EmissionDate { get; set; }
        public Nullable<decimal> Prima { get; set; }
        public Nullable<decimal> Premium { get; set; }
        public Nullable<decimal> Surcharge { get; set; }
        public Nullable<decimal> Value { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsAnnulled { get; set; }
        public Nullable<System.DateTime> AnnulationDate { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
    }
}
