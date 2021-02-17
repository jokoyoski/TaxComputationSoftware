using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<AuthenticationRepository> _logger;

        public AuthenticationRepository(DataContext context, IEmailService emailService, ILogger<AuthenticationRepository> logger)
        {
            _context = context;
            _emailService = emailService;
            _logger = logger;
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
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return false;
            }

        }
    }
}