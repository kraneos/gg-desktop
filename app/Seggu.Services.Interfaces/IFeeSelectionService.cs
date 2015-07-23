using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IFeeSelectionService
    {
        IEnumerable<FeeSelectionDto> GetByLiquidation(string liquidationId);
        string Save(FeeSelectionDto feeSelection);
        void Delete(FeeSelectionDto dto);
    }
}
