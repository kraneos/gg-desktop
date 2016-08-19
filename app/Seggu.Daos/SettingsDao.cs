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
            return context.Settings.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public override void Update(Setting obj)
        {
            context.SaveChanges();
        }

    }
}
