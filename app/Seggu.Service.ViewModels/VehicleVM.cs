using Parse;
using System;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Vehicle")]
    public class VehicleVM : ViewModel
    {
        [ParseFieldName("plate")]
        public string Plate { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("engine")]
        public string Engine { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("year")]
        public string Year { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("chassis")]
        public string Chassis { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("policy")]
        public ParseObject Policy { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("endorse")]
        public ParseObject Endorse { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("vehicleModel")]
        public ParseObject VehicleModel { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("use")]
        public ParseObject Use { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("bodywork")]
        public ParseObject Bodywork { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("isRemoved")]
        public Nullable<bool> IsRemoved { get { return GetProperty<Nullable<bool>>(); } set { SetProperty<Nullable<bool>>(value); } }
    }
}