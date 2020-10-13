using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Helpers.Response;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers 
{
    [ApiController]
    [Route ("api/[controller]")]
    public class UsersController : ControllerBase 
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UsersController (IUsersService usersService, IMapper mapper, UserManager<User> userManager) 
        {
            _userManager = userManager;
            _mapper = mapper;
            _usersService = usersService;

        }

        [HttpGet("get-user/{id}", Name= "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _usersService.GetUserAsync(id);
            var userToReturn = _mapper.Map<UserForListDto>(user);
            return Ok(userToReturn);
        }

       // [Authorize(Roles = StaticDetails.SystemAdmin)]
        [HttpGet ("get-users")]
        public async Task<IActionResult> GetUsers ([FromQuery] PaginationParams pagination) 
        {
            try 
            {
                var users = await _usersService.GetUsersAsync (pagination);
                var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>> (users);
                Response.AddPagination (users.CurrentPage, users.PageSize,
                    users.TotalCount, users.TotalPages);

                return Ok (usersToReturn);
            } catch (Exception)
            {
                var error = new[] { "Error Occured please try again later,please try again later..." };
                return StatusCode(500, new { errors = new { error } });
                
            }

        }

        [HttpPost ("add-user")]
        public async Task<IActionResult> AddUser (UserForRegisterDto userForRegisterDto) 
        {
            try 
            {
                var userToCreate = _mapper.Map<User> (userForRegisterDto);
                userToCreate.IsActive = true;
                userToCreate.EmailConfirmed = true;
                userToCreate.DateCreated = DateTime.Now;
                userToCreate.UserName = userForRegisterDto.Email;

                var result = await _userManager.CreateAsync (userToCreate, userForRegisterDto.Password);

                var userToReturn = _mapper.Map<UserForListDto> (userToCreate);

                if (result.Succeeded) 
                {
                    await _userManager.AddToRoleAsync(userToCreate, StaticDetails.User);
                    return CreatedAtRoute ("GetUser", new { controller = "Users", id = userToCreate.Id }, userToReturn);
                }

                return BadRequest (result.Errors);

            } catch (Exception)
            {
                //var error = ex.Message;
               var error = new[] { "Error Occured please try again later,please try again later..." };
                return StatusCode(500, new { errors = new { error } });
            }
        }

    }
}