using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Locality")]
    public class LocalityVM : KeyValueViewModel
    {
        [ParseFieldName("district")]
        public ParseObject District { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
    }
}
