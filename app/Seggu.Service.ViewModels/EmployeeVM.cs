using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class EmployeeVM : ViewModel
    {
        public string PolicyId { get; set; }
        public string EndorseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string DNI { get; set; }
        public string CUIT { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
        public decimal InsuranceAmount { get; set; }
    }
}
