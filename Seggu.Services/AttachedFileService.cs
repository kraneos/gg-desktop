using Seggu.Daos.Interfaces;
using Seggu.Domain;
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

        public IEnumerable<AttachedFileDto> GetByPolicyId(int id)
        {
            var policyId = id;
            var fees = this.attachedFileDao.GetByPolicyId(policyId);
            return fees.Select(x => AttachedFileDtoMapper.GetDto(x));
        }

        public void Save(List<AttachedFileDto> attFiles)
        {
            foreach (AttachedFileDto file in attFiles)
            {
                bool isNew = file.Id == default(int);
                if (isNew)
                    attachedFileDao.Save(AttachedFileDtoMapper.GetObject(file));
                //else
                //    attachedFileDao.Update(AttachedFileDtoMapper.GetObject(file));
            }
        }
    }
}
