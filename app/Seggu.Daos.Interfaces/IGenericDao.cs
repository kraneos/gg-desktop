using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IGenericDao<T>
    {
        //SegguDataModelContext GetContainer();
        IEnumerable<T> GetAll();
        T Get(object id);
        void Save(T obj);
        void Update(T obj);
        void UpdateMany(IEnumerable<T> objs);
        void Delete(object id, T obj);
        void Delete(object id);
        void DeleteMany(IEnumerable<T> objs);
    }
}
