using Seggu.Dtos;
using System;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IAttachedFileService
    {
        IEnumerable<AttachedFileDto> GetByPolicyId(int id);
        void Save(List<AttachedFileDto> attFiles);
    }
}
