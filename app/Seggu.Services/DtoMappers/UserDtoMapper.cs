using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public static class UserDtoMapper
    {
        public static UserDto GetDto(User u)
        {
            var dto = new UserDto();
            dto.Id = (int)u.Id;
            dto.Username = u.Username;
            dto.Password = u.Password;
            dto.Role = (short)u.Role;
            return dto;
        }

        public static User GetObject(UserDto userDto)
        {
            var obj = new User();

            obj.Password = userDto.Password;
            obj.Role = (Role)userDto.Role;
            obj.Username = userDto.Username;

            if (userDto.Id != default(int))
            {
                obj.Id = userDto.Id;
            }

            return obj;
        }
    }
}
