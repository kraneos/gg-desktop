using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Coverage")]
    public class CoverageVM : KeyValueViewModel
    {
        [ParseFieldName("description")]
        public string Description { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("risk")]
        public ParseObject Risk { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }

    }
}
