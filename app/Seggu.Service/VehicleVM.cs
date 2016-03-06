using System;

namespace Seggu.Service
{
    public class VehicleVM
    {
        public string ObjectId { get; set; }
        public DateVM CreatedAt { get; set; }
        public DateVM UpdatedAt { get; set; }
        public DateVM LocallyUpdatedAt { get; set; }
        public long Id { get; set; }
        public string Plate { get; set; }
        public long PolicyId { get; set; }
        public PointerVM Policy { get; set; }
        public long VehicleModelId { get; set; }
        public string VehicleModelName { get; set; }
        public string BrandName { get; set; }
    }
}