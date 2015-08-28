namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccessoryType
    {
        public AccessoryType()
        {
            this.Accessories = new HashSet<Accessory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Accessory> Accessories { get; set; }
    }
}
