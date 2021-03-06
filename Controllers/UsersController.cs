using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Helpers.Response;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class UsersController : ControllerBase {
        private readonly IEmailService _emailService;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UsersController> _logger;
        public UsersController (IEmailService emailService, IUsersService usersService, IMapper mapper, UserManager<User> userManager, ILogger<UsersController> logger) {
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
            _emailService = emailService;
            _usersService = usersService;

        }

        [HttpGet ("get-user/{id}", Name = "GetUser")]
        [Authorize]
        public async Task<IActionResult> GetUser (int id) {
            try {
                var user = await _usersService.GetUserAsync (id);
                var userToReturn = _mapper.Map<UserForListDto> (user);
                return Ok (userToReturn);
            } catch (Exception ex) {
                var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
            
            }
        }

       
        [HttpGet ("get-users")]
        [Authorize]
        public async Task<IActionResult> GetUsers ([FromQuery] PaginationParams pagination) {
            try {
                var users = await _usersService.GetUsersAsync (pagination);
                var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>> (users);
                Response.AddPagination (users.CurrentPage, users.PageSize,
                    users.TotalCount, users.TotalPages);

                return Ok (usersToReturn);
            } catch (Exception ex) {
                 var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

              return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
            
            }

        }

        [HttpPost ("add-user")]
        // [Authorize(Roles = StaticDetails.SystemAdmin)]
        public async Task<IActionResult> AddUser (UserForRegisterDto userForRegisterDto) {
            try {
                var userToCreate = _mapper.Map<User> (userForRegisterDto);
                userToCreate.IsActive = true;
                userToCreate.EmailConfirmed = true;
                userToCreate.DateCreated = DateTime.Now;
                userToCreate.UserName = userForRegisterDto.Email;

                var result = await _userManager.CreateAsync (userToCreate, userForRegisterDto.Password);

                var userToReturn = _mapper.Map<UserForListDto> (userToCreate);

                if (result.Succeeded) 
                {
                    await _userManager.AddToRoleAsync (userToCreate, StaticDetails.User);
                    await _userManager.AddToRoleAsync (userToCreate, StaticDetails.SystemAdmin);
                    return CreatedAtRoute ("GetUser", new { controller = "Users", id = userToCreate.Id }, userToReturn);
                }

                return BadRequest (result.Errors);

            } catch (Exception ex) 
            {
                // var errors = ex.Message;
                 var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);


                  return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
            
            }
        }

    }
}