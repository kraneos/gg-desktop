using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Daos.Interfaces
{
    public interface IIdEntityDao<T>: IGenericDao<T> where T : IdEntity
    {
        new long Save(T obj);
        void Delete(long id);
        T Find(long id);
    }
}
