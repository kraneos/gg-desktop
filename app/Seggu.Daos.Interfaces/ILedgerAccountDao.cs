using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface ILedgerAccountDao : IParseIdEntityDao<LedgerAccount>
    {
        long GetCobranzaId();
    }
}
