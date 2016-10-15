namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class User : IdEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
