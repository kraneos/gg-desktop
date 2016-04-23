using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class FilterVM
    {
        public DateTime? From { get; set; }
        public int? Page { get; set; }
        public int? Count { get; set; }
    }
}
