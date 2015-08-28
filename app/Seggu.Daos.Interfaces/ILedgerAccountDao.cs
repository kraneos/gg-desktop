using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface ILedgerAccountDao : IGenericDao<LedgerAccount>
    {
        int GetCobranzaId();
    }
}
