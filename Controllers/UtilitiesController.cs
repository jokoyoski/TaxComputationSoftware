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
                    var error = new [] { "Asset class exist!" };
                      return StatusCode (500, new { errors = new []{"Error occured while trying to process your request please try again later !"} });
            
            
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

        [HttpGet("asset-mapping")]
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
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpPost("asset-mapping")]
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

        [HttpPut("asset-mapping/{Id}")]
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

        [HttpDelete("asset-mapping/{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAssetMapping(int Id, AssetMappingDeleteDto assetMappingDeleteDto)
        {
            try
            {

                var assetMappingRecord = await _utilitiesService.GetAssetMappingById(Id);
                if (assetMappingRecord == null)
                {
                    // var error = new[] { "Asset mapping does not exist!" };
                    return StatusCode(400, new { errors = new[] { "Asset mapping does not exist!" } });

                }
                var assetMappingToDelete = _mapper.Map<AssetMapping>(assetMappingDeleteDto);
                assetMappingToDelete.Id = Id;

                await _utilitiesService.DeleteAssetMappingAsync(assetMappingToDelete);

                return Ok("Asset mapping deleted successfully !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpGet("items-mapping")]
        [Authorize]
        public async Task<IActionResult> ListItemsMapping()
        {
            try
            {
                var itemsMappingDtos = await _utilitiesService.GetItemsMappingAsync();

                return Ok(itemsMappingDtos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpPost("items-mapping")]
        public async Task<IActionResult> CreateItemsClassMapping(ItemsMappingDto itemMappingDto)
        {
            try
            {
                var itemMappingRecord = await _utilitiesService.GetItemsMappingByMappedCode(itemMappingDto.MappedCode);
                if (itemMappingRecord != null)
                {
                    var error = new[] { "Item mapping exist!" };
                    return StatusCode(400, new { errors = new { error } });
                }
                var itemMappingToAdd = _mapper.Map<ItemsMapping>(itemMappingDto);
                itemMappingToAdd.MappedCode = itemMappingDto.MappedCode;

                await _utilitiesService.AddItemsMappingAsync(itemMappingToAdd);

                return Ok("Item mapping created successfully !!");

            }
            catch (Exception ex)
            {
                var error = new[] { "Error occured while trying to process your request please try again later !" };
                return StatusCode(500, new { errors = new { error } });
            }
        }

        [HttpPut("items-mapping/{Id}")]
        [Authorize]
        public async Task<IActionResult> UpdateItemsMapping(int Id, ItemsMappingUpdateDto itemsMappingUpdateDto)
        {
            try
            {

                var itemMappingRecord = await _utilitiesService.GetItemsMappingById(Id);
                if (itemMappingRecord == null)
                {
                    // var error = new[] { "Asset mapping does not exist!" };
                    return StatusCode(400, new { errors = new[] { "Item mapping does not exist!" } });

                }
                var itemMappingToUpdate = _mapper.Map<ItemsMapping>(itemsMappingUpdateDto);
                itemMappingToUpdate.Id = Id;

                await _utilitiesService.UpdateItemsMappingAsync(itemMappingToUpdate);

                return Ok("Item mapping updated successfully !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpDelete("items-mapping/{Id}")]
        [Authorize]

        public async Task<IActionResult> DeleteItemsMapping(int Id, ItemsMappingDeleteDto itemMappingDeleteDto)
        {
            try
            {

                var itemMappingRecord = await _utilitiesService.GetItemsMappingById(Id);
                if (itemMappingRecord == null)
                {
                    // var error = new[] { "Asset mapping does not exist!" };
                    return StatusCode(400, new { errors = new[] { "Item mapping does not exist!" } });

                }
                var itemMappingToDelete = _mapper.Map<ItemsMapping>(itemMappingDeleteDto);
                itemMappingToDelete.Id = Id;

                await _utilitiesService.DeleteItemsMappingAsync(itemMappingToDelete);

                return Ok("Item mapping deleted successfully !!");
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