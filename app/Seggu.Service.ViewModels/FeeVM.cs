namespace Seggu.Service.ViewModels
{
    public class FeeVM : ParseViewModel
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public decimal Value { get; set; }
        public int State { get; set; }
        public DateVM ExpirationDate { get; set; }
        public string PolicyId { get; set; }
        public PointerVM Policy { get; set; }
        public string StateName { get; set; }
    }
}