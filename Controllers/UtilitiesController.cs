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
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase {
        private readonly IUtilitiesService _utilitiesService;
        private readonly IMapper _mapper;
        private readonly ILogger<UtilitiesController> _logger;

        public UtilitiesController (IUtilitiesService utilitiesService, IMapper mapper, ILogger<UtilitiesController> logger) {
            _logger = logger;
            _mapper = mapper;
            _utilitiesService = utilitiesService;
        }

        [HttpGet ("asset-class")]
        [Authorize]
        public async Task<IActionResult> GetAssetClass () {
            try {
                var fixedAssetListDtos = await _utilitiesService.GetAssetClassAsync ();

                return Ok (fixedAssetListDtos);

            } catch (Exception ex) {
                 var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                 return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
            
            }
        }

        [HttpPost ("asset-class")]
        [Authorize]
        public async Task<ActionResult> AddAssetClassAsync (AssetClassDto assetClassDto) {
            try {
                var assetClassRecord = await _utilitiesService.GetAssetClassAsync (assetClassDto.Name);
                if (assetClassRecord != null) {
                    
                    return StatusCode (400, new { errors = new []{"Asset Class already exist"} });
            
                }
                var assetClassToAdd = _mapper.Map<AssetClass> (assetClassDto);
                assetClassToAdd.Name = assetClassDto.Name;

                await _utilitiesService.AddAssetClassAsync (assetClassToAdd);

                return Ok ("Asset class created successfully !!");
            } catch (Exception ex) {
                 var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                  return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
            
            }
        }

        [HttpGet ("financial-year")]
        [Authorize]
        public async Task<IActionResult> GetFinancialYear () {
            try {
                var financialYear = await _utilitiesService.GetFinancialYearAsync ();

                return Ok (financialYear);

            } catch (Exception ex) {
                var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                 return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
            
            }
        }

       /* [HttpPost ("add-financial-year")]
        public async Task<ActionResult> AddFinancialYearAsync (FinancialYearDto financialYearDto) {
            try {
                var financialYearRecord = await _utilitiesService.GetFinancialYearAsync (financialYearDto.Name);
                if (financialYearRecord != null) {
                    var error = new [] { "Financial year already exist!" };
                    return StatusCode (400, new { errors = new { error } });
                }
                var financialYearToAdd = _mapper.Map<FinancialYear> (financialYearDto);
                financialYearToAdd.Name = financialYearDto.Name;

                await _utilitiesService.AddFinancialYearAsync (financialYearToAdd);
                return Ok ("Asset class created successfully !!");
            } catch (Exception ex) {
                 var email = User.FindFirst (ClaimTypes.Email).Value;
                _logger.LogInformation ("Exception for {email}, {ex}", email, ex.Message);
                var error = new [] { "Error occured while trying to process your request please try again later !" };
                return StatusCode (500, new { errors = new { error } });
            }
        }*/
    }
}