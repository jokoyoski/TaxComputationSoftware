
using System;
using System.Linq;
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
        private readonly IUtilitiesService _utilitiesService;


        public BalancingAdjustmentController(IBalancingAdjustmentService balancingAdjustmentService, IUtilitiesService utilitiesService, IMemoryCache memoryCache, ICapitalAllowanceService capitalAllowanceService)
        {
            _balancingAdjustmentService = balancingAdjustmentService;
            _capitalAllowanceService = capitalAllowanceService;
            _utilitiesService = utilitiesService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalancingAdjustment(int companyId, string year)
        {
            bool isValid = false;
            // var yearBought = await _balancingAdjustmentService.GetBalancingAdjustmentYearBoughtById(int.Parse(year));

            var details = await _utilitiesService.GetFinancialYearAsync(int.Parse(year));
            var companyDetails = await _utilitiesService.GetPreNotificationsAsync();
            var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == details.CompanyId);
            isValid = Utilities.ValidateDate(companyDate.OpeningDate, companyDate.ClosingDate, details.OpeningDate, details.ClosingDate);
            var response = await _balancingAdjustmentService.DisplayBalancingAdjustment(companyId, year);
            if (isValid)
            {
                response.Values.CanDelete = true;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBalancingAdjustment([FromForm] AddBalanceAdjustmentDto addBalanceAdjustmentDto)
        {
            var record = await _balancingAdjustmentService.GetBalancingAdjustmentYearBoughtByAssetIdYearIdYearBought(int.Parse(addBalanceAdjustmentDto.Year), addBalanceAdjustmentDto.AssetId, int.Parse(addBalanceAdjustmentDto.YearBought));
            if (record != null)
            {
                return BadRequest(new { errors = new[] { "Delete the previous balancing adjustment associated with this asset!" } });

            }
            var previousRecord = await _capitalAllowanceService.GetCapitalAllowanceByAssetIdYear(addBalanceAdjustmentDto.AssetId, addBalanceAdjustmentDto.CompanyId, addBalanceAdjustmentDto.YearBought);
            if (previousRecord == null)
            {
                return BadRequest(new { errors = new[] { "The asset you are trying to calulate its balancing adjustment does not exist" } });


            }
            var details = await _utilitiesService.GetFinancialYearAsync(int.Parse(addBalanceAdjustmentDto.Year));
            var companyDetails = await _utilitiesService.GetPreNotificationsAsync();
            var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == addBalanceAdjustmentDto.CompanyId);
            int taxYear = int.Parse(details.Name);

            var itemModules = await _utilitiesService.GetFinancialCompanyAsync(addBalanceAdjustmentDto.CompanyId);
            var m = itemModules.LastOrDefault();
            if (m.Id != details.Id)
            {
                return StatusCode(400, new { errors = new[] { "This operation is not valid for previous tax years" } });

            }

            if (previousRecord.Channel == Constants.Closed)
            {
                return BadRequest(new { errors = new[] { "The annual for this item has already been calculated from fixed asset" } });
            }

            if (previousRecord != null)
            {
                if (previousRecord.Channel == Constants.Closed)
                {
                    return BadRequest(new { errors = new[] { "The annual for this item has already been calculated from fixed asset" } });
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

            var yearBought = await _balancingAdjustmentService.GetBalancingAdjustmentYearBoughtById(Id);
            var details = await _utilitiesService.GetFinancialYearAsync(int.Parse(yearBought.YearId.ToString()));
            var companyDetails = await _utilitiesService.GetPreNotificationsAsync();
            var companyDate = companyDetails.FirstOrDefault(x => x.CompanyId == details.CompanyId);
            int taxYear = int.Parse(details.Name);
            var itemModules = await _utilitiesService.GetFinancialCompanyAsync(details.CompanyId);
            var m = itemModules.LastOrDefault();
            if (m.Id != details.Id)
            {
                return StatusCode(400, new { errors = new[] { "This operation is not valid for previous tax years" } });

            }

            var response = await _balancingAdjustmentService.DeleteBalancingAdjustmentYearBoughtAsync(Id);

            return Ok(response);
        }

    }
}