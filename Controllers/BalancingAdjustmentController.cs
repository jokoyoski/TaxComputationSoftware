

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Dto;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalancingAdjustmentController : ControllerBase
    {
        private readonly IBalancingAdjustmentService _balancingAdjustmentService;
        private readonly ICapitalAllowanceService _capitalAllowanceService;


        public BalancingAdjustmentController(IBalancingAdjustmentService balancingAdjustmentService, ICapitalAllowanceService capitalAllowanceService)
        {
            _balancingAdjustmentService = balancingAdjustmentService;
            _capitalAllowanceService = capitalAllowanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalancingAdjustment(int companyId, string year)
        {
            var response = await _balancingAdjustmentService.DisplayBalancingAdjustment(companyId, year);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBalancingAdjustment([FromForm] AddBalanceAdjustmentDto addBalanceAdjustmentDto)
        {


            if (int.Parse(addBalanceAdjustmentDto.Year) < int.Parse(addBalanceAdjustmentDto.YearBought))
            {
                return BadRequest(new { errors = new[] { "Year asset was bought cannot be greater than the year of balancing adjustment!!" } });

            }

            var previousRecord = await _capitalAllowanceService.GetCapitalAllowanceByAssetIdYear(addBalanceAdjustmentDto.AssetId, addBalanceAdjustmentDto.CompanyId, addBalanceAdjustmentDto.YearBought);
            if (int.Parse(addBalanceAdjustmentDto.Year) < DateTime.Now.Year)
            {
                return StatusCode(400, new { errors = new[] { "Balancing Adjustment for previous year is not allowed !!!" } });
            }
            if (previousRecord == null)
            {
                return BadRequest(new { errors = new[] { "The asset you are trying to calulate its balancing adjustment does not exist" } });

            }

            if (previousRecord != null)
            {
                if (previousRecord.Channel == Constants.FixedAsset)
                {
                    return BadRequest(new { errors = new[] { "The annual for this item has already been calculated from fixed asset" } });


                }

                if (previousRecord.Channel == Constants.OldBalancingAdjustmentSet)
                {
                    return BadRequest(new { errors = new[] { "The annual for this item has already been calculated" } });


                }
                if (previousRecord.Channel == Constants.BalancingAdjustmentSet)
                {
                    return BadRequest(new { errors = new[] { "The annual for this item has already been calculated from balancing adjustment" } });


                }




                if (previousRecord.NumberOfYearsAvailable == 0)
                {
                    return BadRequest(new { errors = new[] { "The asset has exceeded its lifespan" } });


                }
            }
            var response = await _balancingAdjustmentService.AddBalanceAdjustment(addBalanceAdjustmentDto);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBalancingAdjustmentYearBought(int Id)
        {
            var response = await _balancingAdjustmentService.DeleteBalancingAdjustmentYearBoughtAsync(Id);

            return Ok(response);
        }

    }
}