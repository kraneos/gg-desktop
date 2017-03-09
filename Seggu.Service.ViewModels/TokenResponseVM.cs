using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [DataContract]
    public class TokenResponseVM
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
    }
}
