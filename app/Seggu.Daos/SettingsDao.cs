using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public class SettingsDao : GenericDao<Setting>, ISettingsDao
    {
        public SettingsDao() : base()
        {
        }

        public Setting GetLastLogin()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Settings.OrderByDescending(x => x.Id).FirstOrDefault(); 
            }
        }

        public override void Update(Setting obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var inner = context.Settings.Find(obj.Id);
                inner.ObjectId = obj.ObjectId;
                inner.ClientsRole = obj.ClientsRole;
                inner.Password = obj.Password;
                inner.UserRole = obj.UserRole;
                inner.Username = obj.Username;

                context.SaveChanges(); 
            }
        }

    }
}
