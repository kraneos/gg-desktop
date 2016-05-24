using System;

namespace Seggu.Service.ViewModels
{
    public class VehicleVM : ViewModel
    {
        public string Plate { get; set; }
        public string Engine { get; set; }
        public string Year { get; set; }
        public string Chassis { get; set; }
        public string PolicyId { get; set; }
        public string EndorseId { get; set; }
        public string VehicleModelId { get; set; }
        public string UseId { get; set; }
        public string BodyworkId { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
    }
}