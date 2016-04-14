using System;

namespace Seggu.Service.ViewModels
{
    public class VehicleVM : ViewModel
    {
        public string Plate { get; set; }
        public string Engine { get; set; }
        public string Year { get; set; }
        public string Chassis { get; set; }
        public Guid PolicyId { get; set; }
        public Nullable<Guid> EndorseId { get; set; }
        public Guid VehicleModelId { get; set; }
        public Guid UseId { get; set; }
        public Guid BodyworkId { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
    }
}