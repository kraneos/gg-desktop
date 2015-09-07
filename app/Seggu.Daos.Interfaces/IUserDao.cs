using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Daos.Interfaces
{
    public interface IUserDao : IIdEntityDao<User>
    {
        IEnumerable<User> GetFiltered(string filter);

        User Get(string username, string password);

        bool Exists(string username, string password);
    }
}
