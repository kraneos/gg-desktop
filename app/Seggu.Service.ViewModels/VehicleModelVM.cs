using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("VehicleModel")]
    public class VehicleModelVM : KeyValueViewModel
    {
        [ParseFieldName("origin")]
        public int Origin { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("brand")]
        public ParseObject Brand { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("vehicleType")]
        public ParseObject VehicleType { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }

    }
}
