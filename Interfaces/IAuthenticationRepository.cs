using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IAuthenticationRepository
    {
        bool SaveUserCode(string code, string email);
        Task<UserCode> GetUserCodeByCode(string code);
        bool GetUserStatus(UserCode userCode);
    }
}