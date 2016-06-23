using Parse;
using Seggu.Daos.Interfaces;
using Seggu.Domain;
using Seggu.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.Services
{
    public sealed class LoginService : ILoginService
    {
        private ISettingsDao settingsDao;

        //private 
        public LoginService(ISettingsDao settingsDao)
        {
            this.settingsDao = settingsDao;
        }

        public async void ManageLoginRegisters(ParseUser parseUser, string password)
        {
            var currentUser = ParseUser.CurrentUser;
            var name = currentUser.Username;

            var lastLogin = settingsDao.GetLastLogin();

            var segguClient =
                await ParseObject.GetQuery("SegguClient").GetAsync(currentUser.Get<ParseObject>("segguClient").ObjectId);
            var role = await ParseRole.Query.WhereContains("name", segguClient.Get<string>("name")).FindAsync();
            var userRole = await ParseRole.Query.WhereEqualTo("users", currentUser).FirstAsync();
            if (!role.Any())
            {
                throw new Exception("El usuario no tiene ROLES");
            }


            if (lastLogin == null)
            {
                CreateSetting(password, currentUser, role, userRole);
            }
            else
            {
                if (lastLogin.Username == currentUser.Username)
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
    }
}
