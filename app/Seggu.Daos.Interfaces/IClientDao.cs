using Seggu.Domain;
using System.Collections.Generic;
using Seggu.Dtos;

namespace Seggu.Daos.Interfaces
{
    public interface IClientDao : IParseIdEntityDao<Client>
    {
        List<ClientIndexDto> GetByDni(string search);

        List<ClientIndexDto> GetByFullName(string search);
        List<Client> GetValids();


        bool ExistsDocument(string dni);
        ClientFullDto GetFull(int id);
    }
}
