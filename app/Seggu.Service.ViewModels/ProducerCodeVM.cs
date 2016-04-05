using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class ProducerCodeVM : ViewModelBase
    {
        public Guid ProducerId { get; set; }
        public Guid CompanyId { get; set; }
        public string Code { get; set; }

    }
}
