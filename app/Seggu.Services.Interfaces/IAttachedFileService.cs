using Seggu.Dtos;
using System;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IAttachedFileService
    {
        IEnumerable<AttachedFileDto> GetByPolicyId(string id);
        void Save(List<AttachedFileDto> attFiles);
    }
}
