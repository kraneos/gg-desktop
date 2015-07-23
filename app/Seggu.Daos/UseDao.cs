using Seggu.Daos.Interfaces;
using Seggu.Data;
using System.Collections.Generic;
using System.Linq;
namespace Seggu.Daos
{
    public sealed class UseDao : GenericDao<Use>, IUseDao
    {
        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }
    }
}
