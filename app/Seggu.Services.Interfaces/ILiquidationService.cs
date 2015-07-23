using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface ILiquidationService 
    {
        IEnumerable<LiquidationDto> GetAll();
        void Save(LiquidationDto newLiquidation);
        void Delete(LiquidationDto dto);
    }
}
