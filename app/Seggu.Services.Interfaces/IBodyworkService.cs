using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IBodyworkService
    {
        IEnumerable<BodyworkDto> GetAll();

        void Save(BodyworkDto bodywork);

        void Delete(int Id);
        bool ExistName(string name);
    }
}
