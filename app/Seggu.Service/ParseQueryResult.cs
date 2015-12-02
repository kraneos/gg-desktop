using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service
{
    public class ParseQueryResult<T> where T : new()
    {
        public List<T> Results { get; set; }
    }
}
