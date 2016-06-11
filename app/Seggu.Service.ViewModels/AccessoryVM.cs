using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Accessory")]
    public class AccessoryVM : KeyValueViewModel
    {
        [ParseFieldName("stamp")]
        public string Stamp { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("expirationDate")]
        public System.DateTime ExpirationDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        //[ParseFieldName("accessoryTypeId")]
        //public string AccessoryTypeId { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("accessoryType")]
        public AccessoryTypeVM AccessoryType { get { return GetProperty<AccessoryTypeVM>(); } set { SetProperty<AccessoryTypeVM>(value); } }
        [ParseFieldName("value")]
        public double Value { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        //[ParseFieldName("vehicleId")]
        //public string VehicleId { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("vehicle")]
        public VehicleVM Vehicle { get { return GetProperty<VehicleVM>(); } set { SetProperty<VehicleVM>(value); } }
    }
}
