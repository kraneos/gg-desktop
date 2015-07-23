using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IAccessoryDao: IGenericDao<Accessory>
    {
        IEnumerable<Accessory> GetByVehicleId(Guid id);
    }
}
