using Seggu.Daos.Interfaces;
using Seggu.Data;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class LedgerAccountDao : GenericDao<LedgerAccount>, ILedgerAccountDao
    {
        public string GetCobranzaId()
        {
            return this.Set.First(x => x.Name == "Cobranza").Id.ToString();
        }
    }
}
