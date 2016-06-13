using Parse;
using System;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Client")]
    public class ClientVM : ViewModel
    {
        [ParseFieldName("firstName")]
        public string FirstName { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("lastName")]
        public string LastName { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("cellPhone")]
        public string CellPhone { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("mail")]
        public string Mail { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("document")]
        public string Document { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("birthDate")]
        public DateTime BirthDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("cuit")]
        public string Cuit { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("ingresosBrutos")]
        public string IngresosBrutos { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("collectionTimeRange")]
        public string CollectionTimeRange { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("bankingCode")]
        public string BankingCode { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("notes")]
        public string Notes { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("isSmoker")]
        public bool IsSmoker { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
        [ParseFieldName("sex")]
        public int Sex { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("iva")]
        public int IVA { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("maritalStatus")]
        public int maritalStatus { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("documentType")]
        public int DocumentType { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("occupation")]
        public string Occupation { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
    }
}