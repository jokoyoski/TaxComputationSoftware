using System.Threading.Tasks;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Interfaces
{
    public interface IAuthenticationService
    {
        bool SaveUserCode(string code, string email);
        Task<UserCode> GetUserCodeByCode(string code);
        bool GetUserStatus(UserCode userCode);
    }
}