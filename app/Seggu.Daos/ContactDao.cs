using Seggu.Daos.Interfaces;
using Seggu.Data;

namespace Seggu.Daos
{
    public sealed class ContactDao : GenericDao<Contact> , IContactDao
    {
    }
}
