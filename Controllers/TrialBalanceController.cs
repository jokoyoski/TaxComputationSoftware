using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TrialBalanceController :ControllerBase
    {
        
        [HttpGet()]
        public async Task<IActionResult> GetTrialBalance()
        {
            try
            {
                List<TrialBalance>fixedAssetListDtos=new List<TrialBalance>();
                 for(int i=0;i<10;i++){
                fixedAssetListDtos.Add(new TrialBalance{
                  Item="Furniture and fittings",
                  Debit=100,
                  Credit=3000
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
    }
}