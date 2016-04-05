using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class ProducerVM : KeyValueViewModel
    {
        public string RegistrationNumber { get; set; }
        public bool IsCollector { get; set; }

    }
}
