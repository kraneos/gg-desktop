using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.Domain
{
    public class SynchronizationProcess : IdEntity
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public SynchronizationProcessType Type { get; set; }
    }
}
