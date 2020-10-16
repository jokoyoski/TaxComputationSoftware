using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController :ControllerBase
    {
        private readonly IUtilitiesService _utilitiesService;
        private readonly IMapper _mapper;

        public UtilitiesController(IUtilitiesService utilitiesService, IMapper mapper)
        {
            _mapper = mapper;
            _utilitiesService = utilitiesService;
        }
        [HttpGet("asset-class")]
        public async Task<IActionResult> GetAssetClass()
        {
            try
            {
              var fixedAssetListDtos=await _utilitiesService.GetAssetClassAsync();

               return Ok(fixedAssetListDtos);

            }
            catch (Exception ex)
            {
               var error = new[] { "Error occured while trying to process your request please try again later !" };
                return StatusCode(500, new { errors = new { error } });
            }
        }

        [HttpPost("asset-class")]
        public async Task<ActionResult> AddAssetClassAsync(AssetClassDto assetClassDto)
        {
            try
            {
                var assetClassRecord = await _utilitiesService.GetAssetClassAsync(assetClassDto.Name);
                if (assetClassRecord != null)
                {
                    var error = new[] { "Asset class exist!" };
                    return StatusCode(400, new { errors = new { error } });
                }
                var assetClassToAdd = _mapper.Map<AssetClass>(assetClassDto);
                assetClassToAdd.Name = assetClassDto.Name;

                await _utilitiesService.AddAssetClassAsync(assetClassToAdd);
            
                  return Ok("Asset class created successfully !!");
           }
            catch (Exception ex)
            {
               var error = new[] { "Error occured while trying to process your request please try again later !" };
                return StatusCode(500, new { errors = new { error } });
            }
        }

        [HttpGet("financial-year")]
        public async Task<IActionResult> GetFinancialYear()
        {
            try
            {
                var financialYear=await _utilitiesService.GetFinancialYearAsync();

               return Ok(financialYear);

            }
            catch (Exception ex)
            {
                var error = new[] { "Error occured while trying to process your request please try again later !" };
                return StatusCode(500, new { errors = new { error } });
            }
        }

        [HttpPost("add-financial-year")]
        public async Task<ActionResult> AddFinancialYearAsync(FinancialYearDto financialYearDto)
        {
            try
            {
                var financialYearRecord = await _utilitiesService.GetFinancialYearAsync(financialYearDto.Name);
                if(financialYearRecord!=null)
                {
                    var error = new[] { "Financial year already exist!" };
                    return StatusCode(400, new { errors = new { error } });
                }
                var financialYearToAdd = _mapper.Map<FinancialYear>(financialYearDto);
                financialYearToAdd.Name = financialYearDto.Name;

                await _utilitiesService.AddFinancialYearAsync(financialYearToAdd);
                return Ok("Asset class created successfully !!");
            }
            catch (Exception ex)
            {
                var error = new[] { "Error occured while trying to process your request please try again later !" };
                return StatusCode(500, new { errors = new { error } });
            }
        }
    }
}