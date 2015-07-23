using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IEndorseDao : IGenericDao<Endorse>
    {
        IEnumerable<Endorse> GetByPolicyId(Guid Id);
        void SaveEndorse(Endorse obj);
        void UpdateEndorse(Endorse obj);
        void Edit(Endorse newEndorse);
    }
}
