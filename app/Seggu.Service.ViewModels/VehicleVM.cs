using System;

namespace Seggu.Service.ViewModels
{
    public class VehicleVM : ViewModel
    {
        public long Id { get; set; }
        public string Plate { get; set; }
        public long PolicyId { get; set; }
        public PointerVM Policy { get; set; }
        public long VehicleModelId { get; set; }
        public string VehicleModelName { get; set; }
        public string BrandName { get; set; }
    }
}