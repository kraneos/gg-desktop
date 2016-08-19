using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICasualtyDao : IParseIdEntityDao<Casualty>
    {
        List<Casualty> GetByPolicyId(long guid);
    }
}
