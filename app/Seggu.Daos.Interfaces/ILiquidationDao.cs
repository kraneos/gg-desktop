using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface ILiquidationDao : IGenericDao<Liquidation>
    {
        void Create(Liquidation obj, int id);
    }
}
