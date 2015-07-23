using Seggu.Data;
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
            dto.CashAccountId = obj.CashAccountId.ToString();
            dto.CasualtyId = obj.CasualtyId.ToString();
            dto.EndorseId = obj.EndorseId.ToString();
            dto.FilePath = obj.FilePath;
            dto.Id = obj.Id.ToString();
            dto.PolicyId = obj.PolicyId.ToString();
            dto.EndorseId = obj.EndorseId.ToString();
            return dto;
        }

        public static AttachedFile GetObject(AttachedFileDto dto)
        {
            var obj = new AttachedFile();

            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.FilePath = dto.FilePath;
            obj.EndorseId = string.IsNullOrEmpty(dto.EndorseId) ? (Guid?)null : new Guid(dto.EndorseId);
            obj.PolicyId = string.IsNullOrEmpty(dto.PolicyId) ? (Guid?)null : new Guid(dto.PolicyId);
            obj.CashAccountId = string.IsNullOrEmpty(dto.CashAccountId) ? (Guid?)null : new Guid(dto.CashAccountId);
            obj.CasualtyId = string.IsNullOrEmpty(dto.CasualtyId) ? (Guid?)null : new Guid(dto.CasualtyId);

            return obj;
        }
    }
}
