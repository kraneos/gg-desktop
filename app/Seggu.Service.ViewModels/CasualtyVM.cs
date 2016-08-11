using Parse;
using System;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Casualty")]
    public class CasualtyVM : ViewModel
    {
        [ParseFieldName("number")]
        public int Number { get; set;}
        [ParseFieldName("ourCharge")]
        public bool OurCharge { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
        [ParseFieldName("occurredDate")]
        public DateTime OcurredDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("receiveDate")]
        public DateTime ReceiveDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("policeReportDate")]
        public DateTime PoliceDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("casualtyType")]
        public ParseObject CasualtyType { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("policy")]
        public ParseObject Policy { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("estimatedCompensation")]
        public double EstimatedCompensation { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("definedCompensation")]
        public double DefinedCompensation { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("notes")]
        public string Notes { get; set; }

    }
}