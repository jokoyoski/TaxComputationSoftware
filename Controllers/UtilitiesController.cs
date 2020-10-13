using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController :ControllerBase
    {
         [HttpGet("asset-class")]
        public async Task<IActionResult> GetAssetClass()
        {
            try
            {
                var value=10.40.ToString("0,00");
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






         [HttpGet("financialyears")]
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
    }
}