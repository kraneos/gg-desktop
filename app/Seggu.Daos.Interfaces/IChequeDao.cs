using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IChequeDao : IParseIdEntityDao<Cheque>
    {
        bool ExistsByBank(int id);
    }
}
