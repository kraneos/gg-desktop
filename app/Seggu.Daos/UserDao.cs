using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Daos
{
    public class UserDao : IdEntityDao<User>, IUserDao
    {
        public UserDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public IEnumerable<User> GetFiltered(string filter)
        {
            return this.Set.Where(u => u.Username.Contains(filter));
        }

        public User Get(string username, string password)
        {
            return this.Set.Single(x => x.Username == username && x.Password == password);
        }

        public bool Exists(string username, string password)
        {
            return this.Set.Any(x => x.Username == username && x.Password == password);
        }
    }
}
