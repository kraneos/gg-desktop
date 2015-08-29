using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.IO;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class AttachedFileDtoMapper
    {
        public static AttachedFileDto GetDto(AttachedFile obj)
        {
            var dto = new AttachedFileDto();
            dto.CashAccountId = ((int?)obj.CashAccountId) ?? default(int);
            dto.CasualtyId = ((int?)obj.CasualtyId )?? default(int);
            dto.EndorseId = ((int?)obj.EndorseId )?? default(int);
            dto.FilePath = obj.FilePath;
            dto.Id = (int)obj.Id;
            dto.PolicyId = ((int?)obj.PolicyId )?? default(int);
            dto.EndorseId = ((int?)obj.EndorseId) ?? default(int);
            return dto;
        }

        public static AttachedFile GetObject(AttachedFileDto dto)
        {
            var obj = new AttachedFile();

            obj.Id = dto.Id;
            obj.FilePath = dto.FilePath;
            obj.EndorseId = dto.EndorseId ;
            obj.PolicyId = dto.PolicyId;
            obj.CashAccountId = dto.CashAccountId;
            obj.CasualtyId = dto.CasualtyId;

            return obj;
        }
    }
}
