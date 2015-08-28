using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class LedgerAccountDao : GenericDao<LedgerAccount>, ILedgerAccountDao
    {
        public int GetCobranzaId()
        {
            return this.Set.First(x => x.Name == "Cobranza").Id;
        }
    }
}
