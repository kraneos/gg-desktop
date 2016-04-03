using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Api.Domain
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
