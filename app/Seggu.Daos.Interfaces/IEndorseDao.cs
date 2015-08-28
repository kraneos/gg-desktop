using Seggu.Domain;
using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IEndorseDao : IGenericDao<Endorse>
    {
        IEnumerable<Endorse> GetByPolicyId(int Id);
        void SaveEndorse(Endorse obj);
        void UpdateEndorse(Endorse obj);
        void Edit(Endorse newEndorse);
    }
}
