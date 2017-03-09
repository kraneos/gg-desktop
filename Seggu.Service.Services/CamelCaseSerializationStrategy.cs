using RestSharp;
using System.Linq;

namespace Seggu.Service.Services
{
    public class CamelCaseSerializationStrategy : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            return char.ToLower(clrPropertyName[0]) + clrPropertyName.Substring(1);
        }
    }
}