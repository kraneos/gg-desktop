using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface ILedgerAccountDao : IIdEntityDao<LedgerAccount>
    {
        long GetCobranzaId();
    }
}
