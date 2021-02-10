using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CompaniesController> _logger;
         private readonly IMemoryCache _cache;
        private readonly IUtilitiesService _utilitiesService;
        public CompaniesController(ICompaniesService companiesService, IMemoryCache memoryCache, IUtilitiesService utilitiesService, 
                                    IMapper mapper, IEmailService emailService, ILogger<CompaniesController> logger)
        {
            _logger = logger;
            _companiesService = companiesService;
            _utilitiesService=utilitiesService;
            _cache=memoryCache;
            _mapper = mapper;
            _emailService = emailService;
        }

        [HttpGet("get-company/{id}", Name = "GetCompany")]
      [Authorize]

        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _companiesService.GetCompanyAsync(id);
                return Ok(company);
            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);
                
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        // [Authorize(Policy = "SystemAdmin")]   
        [HttpGet("get-companies")]
       [Authorize]

        public async Task<IActionResult> GetCompanies([FromQuery] PaginationParams pagination)
        {
            try
            {
           
                var companies = await _companiesService.GetCompaniesAsync(pagination);
                var companiesToReturn = _mapper.Map<IEnumerable<CompanyForListDto>>(companies);
                Response.AddPagination(companies.CurrentPage, companies.PageSize,
                    companies.TotalCount, companies.TotalPages);
                return Ok(companiesToReturn);
            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }

        }

        [HttpGet]
        public async Task<IActionResult> Company(int companyId, int financialYearId)
        {
            try
            {
                var company = await _companiesService.GetCompanyInfoByFinancialYear(companyId, financialYearId);

                return Ok(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("add-company")]
        //[Authorize]

        // [Authorize(Roles = Constants.SYS+ "," + Constants.User)]
        public async Task<IActionResult> AddCompany(CompanyForRegisterDto companyForRegisterDto)
        {
            try
            {
        
                if(companyForRegisterDto.LossCf>0){
                    return StatusCode(400, new { errors = new[] { "Since it is a loss brought foward, a negative value is needed!!" } });
                }
                var companyRecord = await _companiesService.GetCompanyByTinAsync(companyForRegisterDto.TinNumber);
                if (companyRecord != null)
                {
                    return StatusCode(400, new { errors = new[] { "Company already exist!" } });

                }

                var companyToCreate = _mapper.Map<Company>(companyForRegisterDto);
                companyToCreate.IsActive = true;
                companyToCreate.DateCreated = DateTime.Now;
                companyToCreate.CompanyName = companyForRegisterDto.CompanyName;
                companyToCreate.ClosingYear=companyToCreate.OpeningYear;

                await _companiesService.AddCompanyAsync(companyToCreate);

                var companyToReturn = _mapper.Map<CompanyForListDto>(companyToCreate);

                return CreatedAtRoute("GetCompany", new { controller = "Companies", id = companyToReturn.Id }, companyToReturn);

            }
            catch (Exception ex)
            {
                // var email = User.FindFirst(ClaimTypes.Email).Value;
                // _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);


                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }
    }
}