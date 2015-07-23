using Seggu.Data;

namespace Seggu.Daos.Interfaces
{
    public interface ILiquidationDao : IGenericDao<Liquidation>
    {
        void Create(Liquidation obj, string id);
    }
}
