using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class IntegralVM : ViewModel
    {
        public Nullable<Guid> PolicyId { get; set; }
        public Nullable<Guid> EndorseId { get; set; }
    }
}
