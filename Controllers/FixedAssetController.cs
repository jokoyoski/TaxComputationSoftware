using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
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

<<<<<<< HEAD
      public FixedAssetController(IMapper mapper,IFixedAssetService fixedAssetService){
         _mapper=mapper;
         _fixedAssetService=fixedAssetService;
       }
      
         [HttpPost]
        public async Task<IActionResult> AddFixedAsset(CreateFixedAssetDto createFixed)
        {
            try
            { 


               
               if(createFixed==null){
                  var error = new[] { "Bad Input !" };
                  
                return StatusCode(400, new { errors = new { error } });
               } 

             
               if(createFixed.YearId==0){
                    var error = new[] { "Please select a valid year" };
                   return StatusCode(400, new { errors = new { error } });
=======
        public FixedAssetController (IMapper mapper, IFixedAssetService fixedAssetService, ILogger<FixedAssetController> logger) {
            _logger = logger;
            _mapper = mapper;
            _fixedAssetService = fixedAssetService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFixedAsset (CreateFixedAssetDto createFixed) {
            try {

                if (createFixed == null) {
                    var error = new [] { "Bad Input !" };

                    return StatusCode (400, new { errors = new { error } });
                }
                if (createFixed.MappedCode == null) {
                    return BadRequest ();
                }
                if (createFixed.YearId == 0) {
                    var error = new [] { "Please select a valid year" };
                    return StatusCode (400, new { errors = new { error } });
>>>>>>> 3040f12d78de78bc7bbcd69fe0b953cb417cb32e
                }

                if (createFixed.CompanyId == 0) {
                    var error = new [] { "Please select a valid Company" };
                    return StatusCode (400, new { errors = new { error } });
                }
                if (createFixed.IsCost == true && (createFixed.CostAddition == 0 && createFixed.CostClosing == 0 && createFixed.CostDisposal == 0)) {
                    var error = new [] { "You selected a Cost but didnt pass a cost input value" };
                    return StatusCode (400, new { errors = new { error } });
                }
                if (createFixed.IsCost == false && (createFixed.DepreciationAddition == 0 && createFixed.DepreciationClosing == 0 && createFixed.DepreciationDisposal == 0)) {
                    var error = new [] { "You selected a depreciation but didnt pass a depreciation input value" };
                    return StatusCode (400, new { errors = new { error } });
                }

                await _fixedAssetService.SaveFixedAsset (createFixed);

                return Ok ("saved successfully");

            } catch (Exception ex) 
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                var error = new [] { "Error Occured please try again later,please try again later..." };
                return StatusCode (500, new { errors = new { error } });
            }
        }

        [HttpGet ("{companyId}/{yearId}")]
        public async Task<IActionResult> GetFixedAsset (int companyId, int yearId) {
            try {
                if (yearId == 0) {
                    var error = new [] { "Please select the year" };
                    return StatusCode (400, new { errors = new { error } });
                }
                var fixedAsset = await _fixedAssetService.GetFixedAssetsByCompany (companyId, yearId);
                if (fixedAsset == null) {
                    var error = new [] { "Record not found at this time, please try later" };
                    return StatusCode (404, new { errors = new { error } });
                }
                return Ok (fixedAsset);

            } catch (Exception ex) {
                var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                var error = new [] { "Error occured while trying to process your request please try again later !" };
                return StatusCode (500, new { errors = new { error } });
            }
        }

    }
}