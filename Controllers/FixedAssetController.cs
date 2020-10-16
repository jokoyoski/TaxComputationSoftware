using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FixedAssetController :ControllerBase
    {
      private readonly IMapper _mapper;
      private readonly IFixedAssetService _fixedAssetService;

      public FixedAssetController(IMapper mapper,IFixedAssetService fixedAssetService){
         _mapper=mapper;
         _fixedAssetService=fixedAssetService;
       }
      
         [HttpPost]
        public async Task<IActionResult> AddFixedAsset(CreateFixedAssetDto createFixed)
        {
            try
            { 
             
               if(createFixed==null){
                  var error = new[] { "Bad Input !" };
                  
                return StatusCode(400, new { errors = new { error } });
               } 
                if(createFixed.MappedCode==null){
                 return BadRequest();
              }
             await  _fixedAssetService.SaveFixedAsset(createFixed);
                
               return Ok("saved successfully");

            }
            catch (Exception ex)
            {
               var error = new[] { "Error Occured please try again later,please try again later..." };
                return StatusCode(500, new { errors = new { error } });
            }
        }






        [HttpGet("{companyId}/{yearId}")]
        public async Task<IActionResult> GetFixedAsset(int companyId,int yearId)
        {
            try
            {
                var fixedAsset=await _fixedAssetService.GetFixedAssetsByCompany(companyId,yearId);
                 if(fixedAsset==null){
                 var error = new[] { "Record not found at this time, please try later" };
                return StatusCode(404, new { errors = new { error } });
                 }
               return Ok(fixedAsset);

            }
            catch (Exception ex)
            {
                var error = new[] { "Error occured while trying to process your request please try again later !" };
                return StatusCode(500, new { errors = new { error } });
            }
        }
    }
}