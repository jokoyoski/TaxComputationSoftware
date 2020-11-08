using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _repo;
        public AuthenticationService(IAuthenticationRepository repo)
        {
            _repo = repo;

        }

        public Task<UserCode> GetUserCodeByCode(string code)
        {
            return _repo.GetUserCodeByCode(code);
        }

        public bool SaveUserCode(string code, string email)
        {
            return _repo.SaveUserCode(code, email);
        }
        public bool GetUserStatus(UserCode userCode)
        {
            return _repo.GetUserStatus(userCode);
        }
    }
}