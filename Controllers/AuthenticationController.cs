using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Models;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Interfaces;
using System.Reflection;

namespace TaxComputationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IEmailService emailService, IConfiguration config, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, ILogger<AuthenticationController> logger, IAuthenticationService authService)
        {
            _authService = authService;
            _logger = logger;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _config = config;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                string[] error = new string[] { };
                var user = await _userManager.FindByNameAsync(userForLoginDto.Email);
                if (user == null)
                    return StatusCode (404, new { errors = new []{"User Not Found!"} });

                var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

                if (result.Succeeded)
                {
                    var appUser = _mapper.Map<UserForListDto>(user);

                    return Ok(new
                    {
                        token = GenerateJwtToken(user).Result,
                        user = appUser
                    });
                }
                return Unauthorized(new { errors = new [] {"Incorrect password! Please enter a valid password."}});

                // return StatusCode (400, new { errors = new []{"Incorrect password! Please enter a valid password"} });
            
            } catch (Exception ex) 
            {
                var user = await _userManager.FindByNameAsync(userForLoginDto.Email);
                var email = user.Email;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
                
             return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
            
            }
        }

        

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;

                var user = await _userManager.FindByEmailAsync(email);

                var checkOldPassword = await _userManager.CheckPasswordAsync(user, changePasswordDto.CurrentPassword);
                if (!checkOldPassword)
                    return BadRequest(new { status = "error", message = "Invalid Password" });

                var updatePassword = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

                if (updatePassword.Succeeded)
                {
                    return Ok(new { status = "success", message = "Password updated successfully" });
                }

                return BadRequest(new { status = "error", message = "Unable to update password at the moment. Please try again later" });

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                var error = new[] { "Error Occured please try again later,please try again later..." };

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new { error } });
            }
        }
        [HttpPost("forgot-password/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    return BadRequest(new { status = "error", message = "User with " + email + " does not exist in our records." });

                var token = StaticDetails.GenerateToken();

                SendMail sendMail = new SendMail();
                string body = $"Kindly use the code {token} to complete your account password reset.";
                var sendToken = await sendMail.SendEmail("Password Reset", email, body, _config.GetValue<string>("SendGridApiKey:Key"));
                if (sendToken)
                {
                    var saveCode = _authService.SaveUserCode(token, email);
                    if (!saveCode)
                    {
                        return StatusCode(500, "Error Occured please try again later, please try again later.......");
                    }
                    return Ok("A password reset token has been sent to your mail.");
                }

                return BadRequest("Unable to send password reset token at the moment. Please try again later");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                var error = new[] { "Error Occured please try again later,please try again later..." };

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new { error } });
            }

        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                var userCode = await _authService.GetUserCodeByCode(resetPasswordDto.Token);
                if (userCode == null)
                    return BadRequest(new { status = "error", message = "Invalid token"});
                var user = await _userManager.FindByEmailAsync(userCode.Email);
                var validateUserCode = _authService.GetUserStatus(userCode);
                if (!validateUserCode)
                    return BadRequest(new { status = "error", message = "Unable to validate credentials" });

                var removeCurrentPassword = await _userManager.RemovePasswordAsync(user);

                var resetPassword = await _userManager.AddPasswordAsync(user, resetPasswordDto.NewPassword);
                if (resetPassword.Succeeded)
                {
                    return Ok(new { status = "success", message = "Your password reset was successful." });
                }

                return BadRequest(resetPassword.Errors);

            }
            catch (Exception ex)
            {
                var userCode = await _authService.GetUserCodeByCode(resetPasswordDto.Token);
                _logger.LogInformation("Exception for {email}, {ex}", userCode.Email, ex.Message);
                var error = new[] { "Error Occured please try again later,please try again later..." };

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
                
                return StatusCode(500, new { errors = new { error } });
            }
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim> 
            {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
                new Claim (ClaimTypes.Email, user.Email),
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(100),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
