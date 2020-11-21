using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class FixedAssetController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly IFixedAssetService _fixedAssetService;
        private readonly ILogger<FixedAssetController> _logger;

        public FixedAssetController (IMapper mapper, IFixedAssetService fixedAssetService, ILogger<FixedAssetController> logger) {
            _logger = logger;
            _mapper = mapper;
            _fixedAssetService = fixedAssetService;
        }

        [HttpPost]
       [Authorize]

        public async Task<IActionResult> AddFixedAsset (CreateFixedAssetDto createFixed) {
            try {

                if (createFixed == null) {
                    var error = new [] { "Bad Input !" };

                    return StatusCode (400, new { errors = new { error } });
                }
                if (createFixed.MappedCode == null) {
                    return BadRequest ();
                }
                if (createFixed.YearId <=0) {
                    
                    return StatusCode (400, new { errors = new []{"Please select a valid year"} });
                }

                 if (createFixed.AssetId <=0) {
                    
                    return StatusCode (400, new { errors = new []{"Please select a valid asset class"} });
                }

                if (createFixed.CompanyId == 0) {
                    return StatusCode (400, new { errors = new []{"Please select a valid company"} });
                    
                }

            

                await _fixedAssetService.SaveFixedAsset (createFixed);

                return Ok ("saved successfully");

            } catch (Exception ex) 
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                
                 return StatusCode (500, new { errors = new []{"Error Occured please try again later,please try again later..."} });
            }
        }
        
        [HttpPut("fixed-asset/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFixedAsset (int id) {
            
             await _fixedAssetService.DeleteFixedAsset(id);
               
                return Ok ("Item Unmapped");
        }


        [HttpGet ("{companyId}/{yearId}")]
        [Authorize]
        public async Task<IActionResult> GetFixedAsset (int companyId, int yearId) {
            try {
                if (yearId == 0) {
                     return StatusCode (400, new { errors = new []{"Please select a Valid year"} });
                }
                var fixedAsset = await _fixedAssetService.GetFixedAssetsByCompany (companyId, yearId);
                if (fixedAsset == null) {
                    return StatusCode (404, new { errors = new []{"Record not found at this time please try again later"} });
                }
                return Ok (fixedAsset);

            } catch (Exception ex) {
                var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                 return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
                
            }
        }

    }
}