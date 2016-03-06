namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccessoryType : ParseKeyValueEntity
    {
        public AccessoryType()
        {
            this.Accessories = new HashSet<Accessory>();
        }
    
        public virtual ICollection<Accessory> Accessories { get; set; }
    }
}
