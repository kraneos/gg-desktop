using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services
{
    public class UserService : IUserService
    {
        private IUserDao userDao;
        
        public UserService(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return this.userDao.GetAll().ToList().Select(u => UserDtoMapper.GetDto(u));
        }

        public IEnumerable<UserDto> GetFiltered(string filter)
        {
            return this.userDao.GetFiltered(filter).ToList().Select(u => UserDtoMapper.GetDto(u));
        }

        public void Delete(int userId)
        {
            this.userDao.Delete(userId);
        }

        public bool Exists(string username, string password)
        {
            return this.userDao.Exists(username, password);
        }

        public UserDto Get(string username, string password)
        {
            var user = this.userDao.Get(username, password);
            return UserDtoMapper.GetDto(user);
        }

        public void Create(UserDto userDto)
        {
            this.userDao.Save(UserDtoMapper.GetObject(userDto));
        }

        public void Update(UserDto userDto)
        {
            this.userDao.Update(UserDtoMapper.GetObject(userDto));
        }
    }
}
