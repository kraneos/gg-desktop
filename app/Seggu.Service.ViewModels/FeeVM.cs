using System;

namespace Seggu.Service.ViewModels
{
    public class FeeVM : ViewModel
    {
        public string PolicyId { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public int Number { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
        public decimal CompanyPayment { get; set; }
        public bool Annulated { get; set; }
        public string FeeSelectionId { get; set; }
        public int State { get; set; }
        public string EndorseId { get; set; }
        public string RegisteredLiqDate { get; set; }
    }
}