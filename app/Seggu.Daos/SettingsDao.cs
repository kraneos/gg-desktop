using System;
using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System.Linq;
using Seggu.Data;

namespace Seggu.Daos
{
    public class SettingsDao : GenericDao<Setting>, ISettingsDao
    {
        public SettingsDao(SegguDataModelContext context) : base(context)
        {
        }

        public Setting GetLastLogin()
        {
            return context.Settings.OrderByDescending(x => x.Id).FirstOrDefault();
        }

    }
}
