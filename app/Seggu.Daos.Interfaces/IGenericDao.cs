using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IGenericDao<T>
    {
        SegguDataModelContainer GetContainer();
        IEnumerable<T> GetAll();
        T Get(int id);
        void Save(T obj);
        void Update(T obj);
        void UpdateMany(IEnumerable<T> objs);
        void Delete(T obj);
        void Delete(int id);
        void DeleteMany(IEnumerable<T> objs);
    }
}
