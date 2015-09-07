using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Data.Entity;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class FeeSelectionDao : IdEntityDao<FeeSelection>, IFeeSelectionDao
    {
        public FeeSelectionDao(SegguDataModelContext context)
            : base(context)
        {

        }

    }
}
