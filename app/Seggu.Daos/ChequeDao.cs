using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public class ChequeDao : IdParseEntityDao<Cheque>, IChequeDao
    {
        public override void Update(Cheque obj)
        {

        }

        public bool ExistsByBank(int id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Cheques.Any(x => x.BankId == id);
            }
        }
    }
}
