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
                var value= 10.40.ToString("0,00");
                List<AssetClass>fixedAssetListDtos=new List<AssetClass>();
                 for(int i=0;i<10;i++){
                fixedAssetListDtos.Add(new AssetClass{
                 Name="Furniture and Fittings"
                });
                 }

               return Ok(fixedAssetListDtos);

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return StatusCode(500, "Error Occured please try again later,please try again later...");
            }
        }

        [HttpPost("add-assetclass")]
        public async Task<ActionResult> AddAssetClassAsync(AssetClassDto assetClassDto)
        {
            try
            {
                var assetClassRecord = _utilitiesService.GetAssetClassAsync(assetClassDto.Name);
                if (assetClassRecord == null)
                {
                    var error = new[] { "Company Already exist!" };
                    return StatusCode(400, new { errors = new { error } });
                }
                var assetClassToAdd = _mapper.Map<AssetClass>(assetClassDto);
                assetClassToAdd.Name = assetClassDto.Name;

                await _utilitiesService.AddAssetClassAsync(assetClassToAdd);
                var assetClassToReturn = _mapper.Map<AssetClassDto>(assetClassToAdd);

                return CreatedAtRoute("GetAssetClass", new { controller = "Utilities", id = assetClassToReturn.Name }, assetClassToReturn);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return StatusCode(500, "Error Occured please try again later,please try again later...");
            }
        }

        [HttpGet("financialyear")]
        public async Task<IActionResult> GetFinancialYear()
        {
            try
            {
                List<FinancialYear>financialYears=new List<FinancialYear>();
                 for(int i=0;i<10;i++){
                financialYears.Add(new FinancialYear{
                 Name="2020"
                });
                 }

               return Ok(financialYears);

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return StatusCode(500, "Error Occured please try again later,please try again later...");
            }
        }

        [HttpPost("add-financialyear")]
        public async Task<ActionResult> AddFinancialYearAsync(FinancialYearDto financialYearDto)
        {
            try
            {
                var financialYearRecord = _utilitiesService.GetFinancialYearAsync(financialYearDto.Name);
                if(financialYearRecord==null)
                {
                    var error = new[] { "Company Already exist!" };
                    return StatusCode(400, new { errors = new { error } });
                }
                var financialYearToAdd = _mapper.Map<FinancialYear>(financialYearDto);
                financialYearToAdd.Name = financialYearDto.Name;

                await _utilitiesService.AddFinancialYearAsync(financialYearToAdd);
                var financialYearToReturn = _mapper.Map<FinancialYearDto>(financialYearToAdd);

                return CreatedAtRoute("GetFinancialYear", new { controller = "Utilities", id = financialYearToReturn.Name }, financialYearToReturn);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return StatusCode(500, "Error Occured please try again later,please try again later...");
            }
        }
    }
}