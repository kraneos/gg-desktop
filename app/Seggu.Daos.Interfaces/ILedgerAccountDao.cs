using Seggu.Data;

namespace Seggu.Daos.Interfaces
{
    public interface ILedgerAccountDao : IGenericDao<LedgerAccount>
    {
        string GetCobranzaId();
    }
}
