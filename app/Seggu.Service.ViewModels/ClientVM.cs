using System;

namespace Seggu.Service.ViewModels
{
    public class ClientVM : ViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Mail { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cuit { get; set; }
        public string IngresosBrutos { get; set; }
        public string CollectionTimeRange { get; set; }
        public string BankingCode { get; set; }
        public string Notes { get; set; }
        public bool IsSmoker { get; set; }
        public int Sex { get; set; }
        public int IVA { get; set; }
        public int MaritalStatus { get; set; }
        public int DocumentType { get; set; }
        public string Occupation { get; set; }
    }
}