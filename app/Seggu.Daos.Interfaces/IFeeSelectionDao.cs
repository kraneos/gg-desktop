using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IFeeSelectionDao : IGenericDao<FeeSelection>
    {
        int Save(FeeSelection obj, int guid);
    }
}
