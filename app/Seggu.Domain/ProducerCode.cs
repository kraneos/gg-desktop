namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProducerCode
    {
        public int ProducerId { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
    
        public virtual Producer Producer { get; set; }
        public virtual Company Company { get; set; }
    }
}
