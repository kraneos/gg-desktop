using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
public    class ContactVM : ViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Notes { get; set; }
        public Nullable<Guid> CompanyId { get; set; }
        public string Bussiness { get; set; }

    }
}
