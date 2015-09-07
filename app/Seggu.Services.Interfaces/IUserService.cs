using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        IEnumerable<UserDto> GetFiltered(string filter);
        void Delete(int userId);
        bool Exists(string username, string password);
        UserDto Get(string username, string password);
        void Create(UserDto userDto);
        void Update(UserDto userDto);
    }
}
