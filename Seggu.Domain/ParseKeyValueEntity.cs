using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Domain
{
    public abstract class ParseKeyValueEntity : IdParseEntity
    {
        public string Name { get; set; }
    }
}
