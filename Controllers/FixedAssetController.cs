using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Dtos;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FixedAssetController :ControllerBase
    {
         [HttpPost]
        public async Task<IActionResult> AddFixedAsset(CreateFixedAssetDto createFixed)
        {
            try
            {
                

               return Ok("saved successfully");

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return StatusCode(500, "Error Occured please try again later,please try again later...");
            }
        }






        [HttpGet("{companyId}/{yearId}")]
        public async Task<IActionResult> GetFixedAsset(int companyId,int yearId)
        {
            try
            {
                List<NetBookValue> value=new List<NetBookValue>();
                value.Add(new NetBookValue{
                    value=3000,
                });
                  value.Add(new NetBookValue{
                    value=3000,
                });
                  value.Add(new NetBookValue{
                    value=5000,
                });
                  value.Add(new NetBookValue{
                    value=8000,
                });
                  value.Add(new NetBookValue{
                    value=9000,
                });
                List<FixedAssetListDto>fixedAssetListDtos=new List<FixedAssetListDto>();
                FixedAssetDto fixedAsset =new FixedAssetDto();
                 for(int i=0;i<10;i++){
                   fixedAssetListDtos.Add(new FixedAssetListDto{
                    OpeningCost=3000,
                    OpeningDepreciation=4000,
                    FixedAssetName="Plant and Machinery",
                     DepreciationClosing=5000,
                     
                    
                     
                });

                 }
                 fixedAsset.values=fixedAssetListDtos;
                 fixedAsset.netBookValue=value;
                 fixedAsset.total=new Total{
                        ClosingCostTotal=300,
                        ClosingDepreciationTotal=4000,
                        AdditionCostTotal=4000
                     };

                 
               return Ok(fixedAsset);

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return StatusCode(500, "Error Occured please try again later,please try again later...");
            }
        }
    }
}