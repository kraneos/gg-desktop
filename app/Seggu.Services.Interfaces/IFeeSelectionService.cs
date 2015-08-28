using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IFeeSelectionService
    {
        IEnumerable<FeeSelectionDto> GetByLiquidation(int liquidationId);
        int Save(FeeSelectionDto feeSelection);
        void Delete(FeeSelectionDto dto);
    }
}
