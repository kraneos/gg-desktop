using Seggu.Data;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class ProducerCodeDtoMapper
    {
        public static ProducerCodeDto GetDto(ProducerCode obj)
        {
            var dto = new ProducerCodeDto();
            dto.Code = obj.Code;
            dto.CompanyId = obj.CompanyId.ToString();
            dto.ProducerId = obj.ProducerId.ToString();

            return dto;
        }

        public static ProducerCode GetObject(ProducerCodeDto dto)
        {
            var obj = new ProducerCode();
            obj.CompanyId = new Guid(dto.CompanyId);
            obj.Code = dto.Code;
            obj.ProducerId = new Guid(dto.ProducerId);

            return obj;
        }
    }
}
