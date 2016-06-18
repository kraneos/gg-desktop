using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Endorse")]
    public class EndorseVM : ViewModel
    {
        [ParseFieldName("endorseType")]
        public int EndorseType { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("number")]
        public string Number { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("cause")]
        public string Cause { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("policy")]
        public ParseObject Policy { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("client")]
        public ParseObject Client { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("startDate")]
        public System.DateTime StartDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("endDate")]
        public System.DateTime EndDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("requestDate")]
        public System.DateTime RequestDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("receptionDate")]
        public Nullable<System.DateTime> ReceptionDate { get { return GetProperty<Nullable<System.DateTime>>(); } set { SetProperty<Nullable<System.DateTime>>(value); } }
        [ParseFieldName("emissionDate")]
        public Nullable<System.DateTime> EmissionDate { get { return GetProperty<Nullable<System.DateTime>>(); } set { SetProperty<Nullable<System.DateTime>>(value); } }
        [ParseFieldName("prima")]
        public Nullable<double> Prima { get { return GetProperty<Nullable<double>>(); } set { SetProperty<Nullable<double>>(value); } }
        [ParseFieldName("premium")]
        public Nullable<double> Premium { get { return GetProperty<Nullable<double>>(); } set { SetProperty<Nullable<double>>(value); } }
        [ParseFieldName("surcharge")]
        public Nullable<double> Surcharge { get { return GetProperty<Nullable<double>>(); } set { SetProperty<Nullable<double>>(value); } }
        [ParseFieldName("value")]
        public Nullable<double> Value { get { return GetProperty<Nullable<double>>(); } set { SetProperty<Nullable<double>>(value); } }
        [ParseFieldName("notes")]
        public string Notes { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("isAnnulled")]
        public Nullable<bool> IsAnnulled { get { return GetProperty<Nullable<bool>>(); } set { SetProperty<Nullable<bool>>(value); } }
        [ParseFieldName("annulationDate")]
        public Nullable<System.DateTime> AnnulationDate { get { return GetProperty<Nullable<System.DateTime>>(); } set { SetProperty<Nullable<System.DateTime>>(value); } }
        [ParseFieldName("isRemoved")]
        public Nullable<bool> IsRemoved { get { return GetProperty<Nullable<bool>>(); } set { SetProperty<Nullable<bool>>(value); } }
    }
}
