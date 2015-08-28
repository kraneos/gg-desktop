using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IAccessoryDao: IGenericDao<Accessory>
    {
        IEnumerable<Accessory> GetByVehicleId(int id);
    }
}
