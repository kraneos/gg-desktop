using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IGenericDao<T>
    {
        SegguDataModelContainer GetContainer();
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Save(T obj);
        void Update(T obj);
        void UpdateMany(IEnumerable<T> objs);
        void Delete(T obj);
        void Delete(Guid id);
        void DeleteMany(IEnumerable<T> objs);
    }
}
