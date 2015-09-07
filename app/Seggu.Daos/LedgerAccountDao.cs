using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class LedgerAccountDao : IdEntityDao<LedgerAccount>, ILedgerAccountDao
    {
        public LedgerAccountDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public long GetCobranzaId()
        {
            return this.Set.First(x => x.Name == "Cobranza").Id;
        }
    }
}
