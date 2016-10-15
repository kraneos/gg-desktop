using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Domain
{
    public class Synchronization : IdEntity
    {
        public string ClassName { get; set; }
        public DateTime LastSync { get; set; }
    }
}
