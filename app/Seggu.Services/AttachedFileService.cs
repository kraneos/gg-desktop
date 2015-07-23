using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Seggu.Services
{
    public sealed class AttachedFileService : IAttachedFileService
    {
        private IAttachedFileDao attachedFileDao;
        public AttachedFileService(IAttachedFileDao attachedFileDao)
        {
            this.attachedFileDao = attachedFileDao;
        }

        public IEnumerable<AttachedFileDto> GetByPolicyId(string id)
        {
            var policyId = new Guid(id);
            var fees = this.attachedFileDao.GetByPolicyId(policyId);
            return fees.Select(x => AttachedFileDtoMapper.GetDto(x));
        }

        public void Save(List<AttachedFileDto> attFiles)
        {
            foreach(AttachedFileDto file in attFiles)
            {
                bool isNew = string.IsNullOrEmpty(file.Id);
                if (isNew)
                    attachedFileDao.Save(AttachedFileDtoMapper.GetObject(file));
                //else
                //    attachedFileDao.Update(AttachedFileDtoMapper.GetObject(file));
            }
        }
    }
}
