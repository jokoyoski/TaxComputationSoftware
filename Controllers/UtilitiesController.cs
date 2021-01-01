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

namespace TaxComputationAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase {
        private readonly IConfiguration _config;
        private readonly IUtilitiesService _utilitiesService;
        private readonly IMapper _mapper;
        private readonly ILogger<UtilitiesController> _logger;
        private readonly IMailManagerService _mailManagerService;

        public UtilitiesController (IConfiguration config, IUtilitiesService utilitiesService, IMapper mapper, ILogger<UtilitiesController> logger, IMailManagerService mailManagerService) {
            _config = config;
            _logger = logger;
            _mapper = mapper;
            _utilitiesService = utilitiesService;
            _mailManagerService = mailManagerService;
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
            catch (Exception)
            {
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
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpDelete("asset-class/{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAssetMapping(int Id)
        {
            try
            {

                var assetMappingRecord = await _utilitiesService.GetAssetMappingById(Id);
                if (assetMappingRecord == null)
                {
                    // var error = new[] { "Asset mapping does not exist!" };
                    return StatusCode(400, new { errors = new[] { "Asset mapping does not exist!" } });

                }

                await _utilitiesService.DeleteAssetMappingAsync(Id);

                return Ok("Asset mapping deleted successfully !!");
            }
            catch (Exception ex)
            {
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
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }
         [HttpGet("module-items/{moduleCode}")]
       /// [Authorize]
        public async Task<IActionResult> GetItemModules(string moduleCode)
        {
            try
            {
                if(moduleCode==null){
                    return StatusCode(400, new { errors = new[] { "Your module code annot be null" } });

                }
                var itemModules = await _utilitiesService.GetModuleMappingbyCode(moduleCode);

                return Ok(itemModules);

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpPost("email-company-reminder")]
        public async Task<IActionResult> SendCompanyEMail(int companyId, string message)
        {
            try
            {
                await _mailManagerService.SendEmail(companyId, message, _config.GetValue<string>("SendGridApiKey:Key"));
                return Ok("A reminder email has been sent to your mail.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("email-reminder")]
        public async Task<IActionResult> SendEMail(string message)
        {
            try
            {
                await _mailManagerService.SendEmail(message, _config.GetValue<string>("SendGridApiKey:Key"));
                return Ok("A notification email has been sent to your mail.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}