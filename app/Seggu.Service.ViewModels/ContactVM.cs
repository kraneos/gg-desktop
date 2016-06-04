using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Contact")]
    public class ContactVM : ViewModel
    {
        [ParseFieldName("firstName")]
        public string FirstName { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("lastName")]
        public string LastName { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("phone")]
        public string Phone { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("mail")]
        public string Mail { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("notes")]
        public string Notes { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("company")]
        public ParseObject Company { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("bussiness")]
        public string Bussiness { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }

    }
}
