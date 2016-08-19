using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class AttachedFileDao : IdParseEntityDao<AttachedFile>, IAttachedFileDao
    {
        public AttachedFileDao()
            : base()
        {
        }

        public IEnumerable<AttachedFile> GetByPolicyId(long guid)
        {
            return this.Set
                .Where(f => f.PolicyId == guid);
        }

        public override void Update(AttachedFile obj)
        {
            var orig = context.AttachedFiles.Find(obj.Id);
            Mapper.Map<AttachedFile, AttachedFile>(obj, orig);
            context.SaveChanges();
        }
    }
}
