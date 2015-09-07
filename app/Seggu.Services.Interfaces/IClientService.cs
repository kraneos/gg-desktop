using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IClientService
    {
        void Save(ClientFullDto clientInformation);

        IEnumerable<ClientFullDto> GetByDNI(string str);

        IEnumerable<ClientFullDto> GetByName(string str);

        IEnumerable<ClientIndexDto> GetAll();

        ClientIndexDto GetShortDtoById(int clientId);

        ClientFullDto GetById(int clientId);

        IEnumerable<ClientIndexDto> GetValids();

        bool ExistsDocument(string dni);
    }
}
