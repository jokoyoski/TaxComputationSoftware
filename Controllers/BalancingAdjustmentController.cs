

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;


        public BalancingAdjustmentController(IBalancingAdjustmentService balancingAdjustmentService, IMemoryCache memoryCache, ICapitalAllowanceService capitalAllowanceService)
        {
            _balancingAdjustmentService = balancingAdjustmentService;
            _capitalAllowanceService = capitalAllowanceService;
            _memoryCache = memoryCache;
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
            var startDate = _memoryCache.Get<DateTime>(Constants.OpeningDate);
            var endDate = _memoryCache.Get<DateTime>(Constants.ClosingDate);
            var isValid = Utilities.ValidateDate(startDate, endDate, int.Parse(addBalanceAdjustmentDto.Year));

            if (!isValid)
            {
                return StatusCode(400, new { errors = new[] { "The year selected has to be within the financial year!!" } });
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