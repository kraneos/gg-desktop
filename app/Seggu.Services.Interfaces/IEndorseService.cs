using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IEndorseService
    {
        IEnumerable<EndorseDto> GetByPolicyId(int Id);
        void Save(EndorseFullDto pol);
    }
}
