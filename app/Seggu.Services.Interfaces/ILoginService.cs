using System.Threading.Tasks;

namespace Seggu.Services.Interfaces
{
    public interface ILoginService
    {
        Task ManageLoginRegisters(string password);
        bool HasValidSetting();
        void Logout();
        Task Login(string username, string password);
        bool IsPaid();
    }
}
