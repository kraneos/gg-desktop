using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.VersionManager
{
    [DataContract]
    public class Version
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
