using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public abstract class IdParseEntityDao<T> : GenericDao<T>, IParseIdEntityDao<T> where T : IdParseEntity
    {
        public IdParseEntityDao()
            : base()
        {
        }

        public new long Save(T obj)
        {
            base.Save(obj);

            return obj.Id;
        }

        public void Delete(long id)
        {
            base.Delete(id);
        }

        public T Find(long id)
        {
            return base.Set.Find(id);
        }
    }

    public abstract class IdEntityDao<T> : GenericDao<T>, IIdEntityDao<T> where T : IdEntity
    {
        public IdEntityDao()
            : base()
        {
        }

        public new long Save(T obj)
        {
            base.Save(obj);

            return obj.Id;
        }

        public void Delete(long id)
        {
            base.Delete(id);
        }

        public T Find(long id)
        {
            return base.Set.Find(id);
        }
    }
}
