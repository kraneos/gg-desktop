using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Employee")]
    public class EmployeeVM : ViewModel
    {
        [ParseFieldName("policy")]
        public ParseObject Policy { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("endorse")]
        public ParseObject Endorse { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("firstName")]
        public string FirstName { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("lastName")]
        public string LastName { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("birthDate")]
        public System.DateTime BirthDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("dni")]
        public string DNI { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("cuit")]
        public string CUIT { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("isRemoved")]
        public Nullable<bool> IsRemoved { get { return GetProperty<Nullable<bool>>(); } set { SetProperty<Nullable<bool>>(value); } }
        [ParseFieldName("insuranceAmount")]
        public double InsuranceAmount { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
    }
}
