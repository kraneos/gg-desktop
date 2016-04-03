namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class IdEntity : AuditableEntity
    {
        public Guid Id { get; set; }
    }
}
