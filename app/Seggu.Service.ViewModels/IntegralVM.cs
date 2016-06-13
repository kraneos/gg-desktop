using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Integral")]
    public class IntegralVM : ViewModel
    {
        [ParseFieldName("policy")]
        public ParseObject Policy { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("endorse")]
        public ParseObject Endorse { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
    }
}
