using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seggu.Api.Models
{
    public class BatchResponse<T>
    {
        public T Success { get; set; }
        public ErrorMessage Error { get; set; }
    }

    public class ErrorMessage
    {
        public int Code { get; set; }
        public string Error { get; set; }
    }
}