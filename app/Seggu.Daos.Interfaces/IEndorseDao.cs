using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IEndorseDao : IIdEntityDao<Endorse>
    {
        IEnumerable<Endorse> GetByPolicyId(long Id);
        void SaveEndorse(Endorse obj);
        void UpdateEndorse(Endorse obj);
        void Edit(Endorse newEndorse);
    }
}
