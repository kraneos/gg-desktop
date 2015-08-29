using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public static class ProducerDtoMapper
    {
        public static ProducerDto GetDto(Producer x)
        {
            var dto = new ProducerDto();
            dto.Id = (int)x.Id;
            dto.Name = x.Name;
            dto.Matrícula = x.RegistrationNumber;
            dto.Cobrador = x.IsCollector;
            return dto;
        }

        public static ProducerCompanyDto GetProducerCompanyDto(ProducerCode pc)
        {
            var dto = new ProducerCompanyDto();
            dto.Id = (int)pc.ProducerId;
            dto.Name = pc.Producer.Name;
            dto.Code = pc.Code;
            dto.RegistrationNumber = pc.Producer.RegistrationNumber;
            return dto;
        }

        public static Producer GetObject(ProducerDto producer)
        {
            var obj = new Producer();
            obj.Id = producer.Id;
            obj.Name = producer.Name;
            obj.RegistrationNumber = producer.Matrícula;
            obj.IsCollector = producer.Cobrador;
            return obj;
        }
    }
}
