using Seggu.Domain;
using System.Collections;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IContactDao : IParseIdEntityDao<Contact>
    {
        List<Contact> GetByCompany(int id);
    }
}
