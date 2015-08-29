using Seggu.Daos.Interfaces;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class CashAccountDao : IdEntityDao<CashAccount> , ICashAccountDao
    {
    }
}
