using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext _context;
        public AuthenticationRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<UserCode> GetUserCodeByCode(string code)
        {
            var userCode = await _context.UserCodes.FirstOrDefaultAsync(x => x.Code == code);
            return userCode;
        }

        public bool GetUserStatus(UserCode userCode)
        {
            bool isValid = false;
            var user = _context.UserCodes.FirstOrDefault(x => x.Code == userCode.Code && x.Email == userCode.Email && x.DateCreated >= DateTime.Now);
            isValid = user == null ? isValid = false : isValid = true;
            return isValid;
        }

        public bool SaveUserCode(string code, string email)
        {
            TimeSpan duration = new TimeSpan(2, 0, 0, 0);

            var userCode = new UserCode
            {
                Code = code,
                Email = email,
                DateCreated = DateTime.Now.Add(duration)
            };
            try
            {
                var saveCode = _context.UserCodes.Add(userCode);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}