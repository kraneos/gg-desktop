using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;
namespace Seggu.Daos
{
    public sealed class BankDao : IdEntityDao<Bank>, IBankDao
    {

        public bool GetByName(string name)
         {
            return this.Set.Any(c => c.Name == name);
        }
        
        public bool GetByNumber(string number)
        {
            return this.Set.Any(c => c.Number == number);
        }
    }
}