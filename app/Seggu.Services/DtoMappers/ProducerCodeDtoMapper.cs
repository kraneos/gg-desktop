using Seggu.Domain;
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
            dto.CompanyId = obj.CompanyId;
            dto.ProducerId = obj.ProducerId;

            return dto;
        }

        public static ProducerCode GetObject(ProducerCodeDto dto)
        {
            var obj = new ProducerCode();
            obj.CompanyId = dto.CompanyId;
            obj.Code = dto.Code;
            obj.ProducerId = dto.ProducerId;

            return obj;
        }
    }
}
