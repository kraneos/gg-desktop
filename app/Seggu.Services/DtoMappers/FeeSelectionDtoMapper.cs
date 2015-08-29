using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class FeeSelectionDtoMapper
    {
        public static FeeSelectionDto GetDto(FeeSelection x)
        {
            var dto = new FeeSelectionDto();
            dto.Id = (int)x.Id;
            dto.Name = x.Name;
            dto.Total = x.Total;
            dto.Notes = x.Notes;
            dto.LiquidationId = (int)x.LiquidationId;
            return dto;
        }

        public static FeeSelection GetObject(FeeSelectionDto dto)
        {
            var fs = new FeeSelection();
            fs.Id = dto.Id;
            fs.Name = dto.Name;
            fs.LiquidationId = dto.LiquidationId;
            fs.Notes = dto.Notes;
            fs.Total = dto.Total;
            return fs;
        }
    }
}
