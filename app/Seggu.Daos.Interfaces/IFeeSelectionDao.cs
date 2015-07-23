using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IFeeSelectionDao : IGenericDao<FeeSelection>
    {
        void Save(FeeSelection obj, Guid guid);

    }
}
