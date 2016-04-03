using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seggu.Api.Models
{
    public class ApiFilter
    {
        public DateTime? From { get; set; }
        public int? Count { get; set; }
        public int? Page { get; set; }
    }
}