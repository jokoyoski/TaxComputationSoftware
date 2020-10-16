using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;
        private readonly IMapper _mapper;
        public CompaniesController(ICompaniesService companiesService, IMapper mapper)
        {
            _companiesService = companiesService;
            _mapper = mapper;
        }

        [HttpGet("get-company/{id}", Name = "GetCompany")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _companiesService.GetCompanyAsync(id);
            return Ok(company);
        }

        [HttpGet("get-companies")]
       // [Authorize(Policy = "SystemAdmin")]   
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
            catch (Exception)
            {
                var error = new[] { "Error Occured please try again later,please try again later..." };
                return StatusCode(500, new { errors = new { error } });
            }

        }


        [HttpPost("add-company")]
      // [Authorize(Roles = Constants.SYS+ "," + Constants.User)]
        public async Task<IActionResult> AddCompany(CompanyForRegisterDto companyForRegisterDto)
        {
            try
            {
                var companyRecord=await _companiesService.GetCompanyByTinAsync(companyForRegisterDto.TinNumber);
                if(companyRecord!=null){
                     var error = new[] { "Company Already exist!" };
                return StatusCode(400, new { errors = new { error } });
                }
                var companyToCreate = _mapper.Map<Company>(companyForRegisterDto);
                companyToCreate.IsActive = true;
                companyToCreate.DateCreated = DateTime.Now;
                companyToCreate.CompanyName = companyForRegisterDto.CompanyName;
                
                await _companiesService.AddCompanyAsync(companyToCreate);

                var companyToReturn = _mapper.Map<CompanyForListDto>(companyToCreate);

                return CreatedAtRoute("GetCompany", new { controller = "Companies", id = companyToReturn.Id }, companyToReturn);

            }
            catch (Exception ex)
            {
                 var error = new[] { "Error Occured please try again later,please try again later..." };
                return StatusCode(500, new { errors = new { error } });
            }
        }
    }
}
