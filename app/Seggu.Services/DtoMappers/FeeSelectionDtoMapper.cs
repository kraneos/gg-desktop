using Seggu.Data;
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
            dto.Id = x.Id.ToString();
            dto.Name = x.Name;
            dto.Total = x.Total;
            dto.Notes = x.Notes;
            dto.LiquidationId = x.LiquidationId.ToString();
            return dto;
        }

        public static FeeSelection GetObject(FeeSelectionDto dto)
        {
            var fs = new FeeSelection();
            fs.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            fs.Name = dto.Name;
            fs.LiquidationId = new Guid(dto.LiquidationId);
            fs.Notes = dto.Notes;
            fs.Total = dto.Total;
            return fs;
        }
    }
}
