using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("District")]
    public class DistrictVM : KeyValueViewModel
    {
        [ParseFieldName("province")]
        public ParseObject Province { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
    }
}
