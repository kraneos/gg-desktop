using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface ILedgerAccountService
    {
        IEnumerable<LedgerAccountDto> GetAll();

        void Create(LedgerAccountDto la);

        string GetCobranzaId();
        //void Update(LedgerAccountDto ledgerAccount);
        //void Delete(string id);
    }
}
