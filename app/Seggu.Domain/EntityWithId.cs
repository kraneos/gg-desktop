namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class EntityWithId
    {
        public int Id { get; set; }
    }
}
