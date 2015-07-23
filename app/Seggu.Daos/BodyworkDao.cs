using Seggu.Daos.Interfaces;
using Seggu.Data;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class BodyworkDao : GenericDao<Bodywork>, IBodyworkDao
    {
        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }
    }
}
