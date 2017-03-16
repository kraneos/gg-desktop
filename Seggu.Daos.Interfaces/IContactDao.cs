using Seggu.Domain;
using System.Collections;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IContactDao : IParseIdEntityDao<Contact>
    {
        IEnumerable<Contact> GetByCompany(int id);
    }
}
