using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class LedgerAccountDao : IdEntityDao<LedgerAccount>, ILedgerAccountDao
    {
        public long GetCobranzaId()
        {
            return this.Set.First(x => x.Name == "Cobranza").Id;
        }
    }
}
