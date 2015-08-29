using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface ILiquidationDao : IIdEntityDao<Liquidation>
    {
        void Create(Liquidation obj, long id);
    }
}
