using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Data.Entity;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class FeeSelectionDao : IdEntityDao<FeeSelection>, IFeeSelectionDao
    {
    }
}
