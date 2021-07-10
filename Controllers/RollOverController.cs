using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Services;

namespace TaxComputationSoftware.Controllers
{
    [Route("api/[controller]")]
    public class RollOverController : ControllerBase
    {

        private readonly RollOverService _rollOverService;
        public RollOverController(RollOverService rollOverService)
        {
            _rollOverService = rollOverService;
        }


        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> RollOver(int companyId)
        {

            try
            {

                var value = _rollOverService.DeleteOldCapitalAllowanceAndSummary(companyId);
                await _rollOverService.SaveRollFowardCapitalAllowance(companyId);
                await _rollOverService.SaveRollFowardArchivedCapitalAllowance(companyId);
                await _rollOverService.SaveRollFowardCapitalAllowanceSummary(companyId);
                await _rollOverService.CalculateAnnualCalculation(companyId);
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
                    if (valueYear != null)
                    {
                        var record = await _rollOverService.GetFinancialYear(valueYear.YearId);
                        if (record != null)
                        {
                            _rollOverService.RollBackYear(companyId);
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