using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Coverage")]
    public class CoverageVM : ViewModel
    {
        [ParseFieldName("description")]
        public string Description { get; set; }
        [ParseFieldName("risk")]
        public ParseObject Risk { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }

    }
}
