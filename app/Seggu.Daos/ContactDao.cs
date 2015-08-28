using Seggu.Daos.Interfaces;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class ContactDao : GenericDao<Contact> , IContactDao
    {
    }
}
