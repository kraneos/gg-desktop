namespace Seggu.Domain
{ 
    public partial class Accessory : ParseKeyValueEntity
    {
        public long AccessoryTypeId { get; set; }
        public virtual AccessoryType AccessoryType { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public string Stamp { get; set; }
        public decimal Value { get; set; }
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }   
    }
}
