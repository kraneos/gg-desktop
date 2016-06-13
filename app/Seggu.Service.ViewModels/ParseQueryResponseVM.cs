using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
   public class ParseQueryResponseVM<T> where T : ViewModel
    {
        public List<T> Results { get; set; }
    }
}
