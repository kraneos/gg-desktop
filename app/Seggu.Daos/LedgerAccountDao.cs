using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class LedgerAccountDao : IdParseEntityDao<LedgerAccount>, ILedgerAccountDao
    {
        public LedgerAccountDao()
            : base()
        {

        }

        public long GetCobranzaId()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.LedgerAccounts.First(x => x.Name == "Cobranza").Id; 
            }
        }

        public override void Update(LedgerAccount obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.LedgerAccounts.Find(obj.Id);
                Mapper.Map<LedgerAccount, LedgerAccount>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}
