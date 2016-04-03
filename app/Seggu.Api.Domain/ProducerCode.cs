namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProducerCode : AuditableEntity
    {
        public Guid ProducerId { get; set; }
        public Guid CompanyId { get; set; }
        public string Code { get; set; }
    
        public virtual Producer Producer { get; set; }
        public virtual Company Company { get; set; }
    }
}
