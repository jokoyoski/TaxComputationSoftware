using System;
using System.Collections.Generic;
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
    public class UtilitiesController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUtilitiesService _utilitiesService;
        private readonly IMapper _mapper;
        private readonly ILogger<UtilitiesController> _logger;
        private readonly IMemoryCache _memoryCache;

        public UtilitiesController(IEmailService emailService, IUtilitiesService utilitiesService, IMemoryCache memoryCache, IMapper mapper, ILogger<UtilitiesController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _emailService = emailService;
            _utilitiesService = utilitiesService;
            _memoryCache = memoryCache;
        }


        [HttpGet("asset-class")]
        [Authorize]
        public async Task<IActionResult> ListAssetClassMapping()
        {
            try
            {
                var assetClassMappingDtos = await _utilitiesService.GetAssetMappingAsync();

                return Ok(assetClassMappingDtos);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpPost("asset-class")]
        public async Task<IActionResult> CreateAssetClassMapping(AssetMappingDto assetMappingDto)
        {
            try
            {
                var assetMappingRecord = await _utilitiesService.GetAssetMappingAsync(assetMappingDto.AssetName);
                if (assetMappingRecord != null)
                {
                    var error = new[] { "Asset mapping exist!" };
                    return StatusCode(400, new { errors = new { error } });
                }
                var assetMappingToAdd = _mapper.Map<AssetMapping>(assetMappingDto);
                assetMappingToAdd.AssetName = assetMappingDto.AssetName;

                await _utilitiesService.AddAssetMappingAsync(assetMappingToAdd);

                return Ok("Asset mapping created successfully !!");

            }
            catch (Exception ex)
            {
                var error = new[] { "Error occured while trying to process your request please try again later !" };

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new { error } });
            }
        }

        [HttpPut("asset-class/{Id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAssetMapping(int Id, AssetMappingUpdateDto assetMappingUpdateDto)
        {
            try
            {

                var assetMappingRecord = await _utilitiesService.GetAssetMappingById(Id);
                if (assetMappingRecord == null)
                {
                    // var error = new[] { "Asset mapping does not exist!" };
                    return StatusCode(400, new { errors = new[] { "Asset mapping does not exist!" } });

                }
                var assetMappingToUpdate = _mapper.Map<AssetMapping>(assetMappingUpdateDto);
                assetMappingToUpdate.Id = Id;

                await _utilitiesService.UpdateAssetMappingAsync(assetMappingToUpdate);

                return Ok("Asset mapping updated successfully !!");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpDelete("asset-class/{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAssetMapping(int Id)
        {
            try
            {

                // var assetMappingRecord = await _utilitiesService.GetAssetMappingById(Id);
                /*  if (assetMappingRecord == null)
                  {
                      // var error = new[] { "Asset mapping does not exist!" };
                      return StatusCode(400, new { errors = new[] { "Asset mapping does not exist!" } });

                  }

                  await _utilitiesService.DeleteAssetMappingAsync(Id); */

                return Ok("Feature disabled !!!");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);


                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }


        [HttpGet("end-date")]
        //[Authorize]
        public async Task<IActionResult> EndDate()
        {
            try
            {
                var endDate = _memoryCache.Get<DateTime>(Constants.ClosingDate);
                return Ok(endDate);

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


        [HttpGet("financial-year")]
        [Authorize]
        public async Task<IActionResult> GetFinancialYear()
        {
            try
            {
                var financialYear = await _utilitiesService.GetFinancialYearAsync();

                return Ok(financialYear);

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
        [HttpGet("module-items/{moduleCode}")]
        /// [Authorize]
        public async Task<IActionResult> GetItemModules(string moduleCode)
        {
            try
            {
                if (moduleCode == null)
                {
                    return StatusCode(400, new { errors = new[] { "Your module code annot be null" } });

                }
                var itemModules = await _utilitiesService.GetModuleMappingbyCode(moduleCode);

                return Ok(itemModules);

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


        [HttpGet("company-financial-year")]
        [Authorize]
        public async Task<IActionResult> GetFinancialYears(int companyId)
        {
            try
            {
                if (companyId <= 0)
                {
                    return StatusCode(400, new { errors = new[] { "CompanyId is invalid" } });

                }
                var itemModules = await _utilitiesService.GetFinancialCompanyAsync(companyId);

                return Ok(itemModules);

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


    }
}