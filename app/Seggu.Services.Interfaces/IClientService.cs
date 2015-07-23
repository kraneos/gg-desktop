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

        ClientIndexDto GetShortDtoById(string clientId);

        ClientFullDto GetById(string clientId);

        IEnumerable<ClientIndexDto> GetValids();
    }
}
