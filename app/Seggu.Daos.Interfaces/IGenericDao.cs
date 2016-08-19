using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IGenericDao<T>
    {
        //SegguDataModelContext GetContainer();
        List<T> GetAll();
        T Get(object id);
        void Save(T obj);
        void Update(T obj);
        void UpdateMany(List<T> objs);
        void Delete(object id, T obj);
        void Delete(object id);
        void DeleteMany(List<T> objs);
    }
}
