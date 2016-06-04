using Parse;
using System;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Address")]
    public class AddressVM : ViewModel
    {
        [ParseFieldName("street")]
        public string Street { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("phone")]
        public string Phone { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("number")]
        public string Number { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("floor")]
        public string Floor { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("appartment")]
        public string Appartment { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("locality")]
        public ParseObject Locality { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("postalCode")]
        public string PostalCode { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("addressType")]
        public int AddressType { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("client")]
        public ParseObject Client { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
    }
}