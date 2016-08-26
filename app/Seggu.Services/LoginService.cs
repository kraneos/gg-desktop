using Parse;
using Seggu.Daos.Interfaces;
using Seggu.Domain;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seggu.Helpers.Exceptions;

namespace Seggu.Services
{
    public sealed class LoginService : ILoginService
    {
        private ISettingsDao settingsDao;

        public LoginService(ISettingsDao settingsDao)
        {
            this.settingsDao = settingsDao;
        }

        public bool HasValidSetting()
        {
            var lastLogin = settingsDao.GetLastLogin();
            return lastLogin != null && !string.IsNullOrWhiteSpace(lastLogin.Username) && !string.IsNullOrWhiteSpace(lastLogin.Password);
        }

        public async Task Login(string username, string password)
        {
            await ParseUser.LogInAsync(username, password);
        }

        public async Task ManageLoginRegisters(string password)
        {
            var currentUser = ParseUser.CurrentUser;
            var lastLogin = settingsDao.GetLastLogin();

            var segguClient =
                await ParseObject.GetQuery("SegguClient").GetAsync(currentUser.Get<ParseObject>("segguClient").ObjectId);
            var role = await ParseRole.Query.WhereContains("name", segguClient.Get<string>("name")).FindAsync();
            var userRole = await ParseRole.Query.WhereEqualTo("users", currentUser).FirstAsync();
            if (!role.Any())
            {
                throw new ParseLoginException("El usuario no tiene ROLES");
            }

            if (lastLogin == null)
            {
                CreateSetting(password, currentUser, role, userRole);
            }
            else
            {
                if (userRole.Name != lastLogin.UserRole)
                {
                     throw new ParseLoginException("El usuario no pertenece a esta empresa");
                }
                if ( lastLogin.Username == currentUser.Username)
                {
                    //update()
                    lastLogin.Password = string.IsNullOrWhiteSpace(password) ? lastLogin.Password : password;
                    lastLogin.ObjectId = currentUser.ObjectId;
                    lastLogin.UserRole = userRole.Name;
                    lastLogin.ClientsRole = role.First(r => r.ObjectId != userRole.ObjectId).Name;
                    settingsDao.Update(lastLogin);
                }
                else
                {
                    CreateSetting(password, currentUser, role, userRole);
                }
            } 
        }

        private void CreateSetting(string password, ParseUser currentUser, IEnumerable<ParseRole> role, ParseRole userRole)
        {
            var setting = new Setting()
            {
                Username = currentUser.Username,
                Password = password,
                ObjectId = currentUser.ObjectId,
                UserRole = userRole.Name,
                ClientsRole = role.First(r => r.ObjectId != userRole.ObjectId).Name
            };
            settingsDao.Save(setting);
        }

        public void Logout()
        {
            if (ParseUser.CurrentUser != null)
                ParseUser.LogOut();
        }
    }
}
