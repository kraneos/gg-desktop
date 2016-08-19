using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class FeeSelectionDao : IdParseEntityDao<FeeSelection>, IFeeSelectionDao
    {
        public FeeSelectionDao()
            : base()
        {

        }

        public override void Update(FeeSelection obj)
        {
            var orig = context.FeeSelections.Find(obj.Id);
            Mapper.Map<FeeSelection, FeeSelection>(obj, orig);
            context.SaveChanges();
        }
    }
}
