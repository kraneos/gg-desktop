using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface ILiquidationDao : IParseIdEntityDao<Liquidation>
    {
        void Create(Liquidation obj, long id);
    }
}
