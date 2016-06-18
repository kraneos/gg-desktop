using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.Services.Interfaces
{
    public interface ILoginService
    {
        void ManageLoginRegisters(ParseUser parseUser, string password);

        //IEnumerable<BankDto> GetAll();
        //void Save(BankDto bank);
        //void Update(BankDto bank);
        //void Delete(int id);
        //bool ExistNumber(string number);
        //bool ExistName(string name);
        //bool HasAssociatedRecords(int id);
    }
}
