using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers 
{
    [ApiController]
    [Route ("api/[controller]")]
    public class AuthenticationController : ControllerBase 
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController (IConfiguration config, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, ILogger<AuthenticationController> logger) 
        {
            _logger = logger;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;

        }

        [HttpPost ("login")]
        public async Task<IActionResult> Login (UserForLoginDto userForLoginDto) 
        {
            try 
            {
                string[] error = new string[] { };
                var user = await _userManager.FindByNameAsync (userForLoginDto.Email);
                if (user == null) 
                {

                    error = new [] { "User Not Found" };
                    return StatusCode (400, new { errors = new { error } });

                }
                var result = await _signInManager.CheckPasswordSignInAsync (user, userForLoginDto.Password, false);

                if (result.Succeeded) 
                {
                    var appUser = _mapper.Map<UserForListDto> (user);

                    return Ok (new 
                    {
                        token = GenerateJwtToken (user).Result,
                            user = appUser
                    });
                }

                error = new [] { "Your login details are not valid" };
                return StatusCode (500, new { errors = new { error } });

            } catch (Exception ex) 
            {
                var user = await _userManager.FindByNameAsync (userForLoginDto.Email);
                var email = user.Email;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                var error = new [] { "Error Occured please try again later,please try again later..." };
                return StatusCode (500, new { errors = new { error } });
            }

        }

        private async Task<string> GenerateJwtToken (User user) 
        {
            var claims = new List<Claim> {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
                new Claim (ClaimTypes.Email, user.Email),
            };

            var roles = await _userManager.GetRolesAsync (user);

            foreach (var role in roles) 
            {
                claims.Add (new Claim (ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey (Encoding.UTF8
                .GetBytes (_config.GetSection ("AppSettings:Token").Value));

            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity (claims),
                Expires = DateTime.Now.AddDays (1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler ();

            var token = tokenHandler.CreateToken (tokenDescriptor);

            return tokenHandler.WriteToken (token);
        }

    }
}