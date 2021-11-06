using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Services;

namespace TaxComputationSoftware.Controllers
{
    [Route("api/[controller]")]
    public class RollOverController : ControllerBase
    {

        private readonly RollOverService _rollOverService;
        private readonly IFixedAssetService _fixedAssetService;
        public RollOverController(RollOverService rollOverService, IFixedAssetService fixedAssetService)
        {
            _rollOverService = rollOverService;
            _fixedAssetService = fixedAssetService;
        }


        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> RollOver(int companyId)
        {

            try
            {

                var currentYear1 = await _rollOverService.GetLastFinancialYear(companyId);
                var value = _rollOverService.DeleteOldCapitalAllowanceAndSummary(companyId);
                await _rollOverService.SaveRollFowardCapitalAllowance(companyId);
                await _rollOverService.SaveRollFowardArchivedCapitalAllowance(companyId);
                await _rollOverService.SaveRollFowardCapitalAllowanceSummary(companyId);
                await _rollOverService.CalculateAnnualCalculation(companyId);
                int i = 0;
                var currentYear2 = await _rollOverService.GetLastFinancialYear(companyId);
                var fixedAsset = await _fixedAssetService.GetFixedAssetsByCompanyForRollOver(companyId, currentYear1.Id);
                foreach (var item in fixedAsset.fixedAssetResponse.FixedAssetData)
                {

                    await _fixedAssetService.SaveFixedAssetRollOver(new TaxComputationAPI.Dtos.CreateFixedAssetDto()
                    {
                        CompanyId=companyId,
                        YearId = currentYear2.Id,
                        OpeningCost = fixedAsset.costs[i],
                        OpeningDepreciation = fixedAsset.depreciations[i],
                        AssetId = item.AssetId,
                        IsCost=true,
                    });
                    i++;
                }
                i=0;
                foreach (var item in fixedAsset.fixedAssetResponse.FixedAssetData)
                {

                    await _fixedAssetService.SaveFixedAssetRollOver(new TaxComputationAPI.Dtos.CreateFixedAssetDto()
                    {
                        CompanyId=companyId,
                        YearId = currentYear2.Id,
                        OpeningCost = fixedAsset.costs[i],
                        OpeningDepreciation = fixedAsset.depreciations[i],
                        AssetId = item.AssetId,
                        IsCost=false,
                    });
                    i++;
                }
                return Ok("Successfully Rolled Foward!!!!!!");
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { errors = new[] { "Error Occured !!!" } });

            }
            return Ok();

        }




        [HttpPost("rollback")]
        // [Authorize]
        public async Task<IActionResult> RollBack(int companyId)
        {

            try
            {
                var valueYear1 = await _rollOverService.GetRollBackYearAsync(companyId);
                if (valueYear1 != null)
                {
                    var value = _rollOverService.DeleteCapitalAllowanceAndSummary(companyId);
                    _rollOverService.SaveRollBackCapitalAllowance(companyId);
                    _rollOverService.SaveRollBackArchivedCapitalAllowance(companyId);
                    _rollOverService.SaveRollBackCapitalAllowanceSummary(companyId);
                    var result = await _rollOverService.GetRollBackYearAsync(companyId);
                    var valueYear = await _rollOverService.GetRollBackYearAsync(companyId);
                    var record = await _rollOverService.GetFinancialYear(valueYear.YearId);
                    if (valueYear != null)
                    {
                        if (record != null)
                        {
                            _rollOverService.RollBackYear(companyId);
                        }
                    }
                    var fixedAsset = await _fixedAssetService.GetFixedAssetsByCompanyForRollOver(companyId, record.Id);
                    if (fixedAsset != null)
                    {
                        foreach (var item in fixedAsset.fixedAssetResponse.FixedAssetData)
                        {
                            await _fixedAssetService.DeleteFixedAssetById(item.Id);
                        }
                    }

                    _rollOverService.DeleteFinancialYear(result.YearId);
                    _rollOverService.DeleteIncomeTaxBroughtFoward(result.YearId);
                    _rollOverService.DeleteDeferredTaxBroughtFoward(result.YearId);
                    return Ok("Rolled back Successfully");
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { errors = new[] { "Error Occured !!!" } });


            }
            return Ok();

        }



    }
}