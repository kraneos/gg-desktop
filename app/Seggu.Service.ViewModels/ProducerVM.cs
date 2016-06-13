using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Producer")]
    public class ProducerVM : KeyValueViewModel
    {
        [ParseFieldName("registrationNumber")]
        public string RegistrationNumber { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("isCollector")]
        public bool IsCollector { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }

    }
}
