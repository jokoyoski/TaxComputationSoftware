using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancingAdjController : ControllerBase
    {
        private readonly IBalancingAdjService _balancingAdjService;
        private readonly IMapper _mapper;
        private readonly ILogger<BalancingAdjController> _logger;

        public BalancingAdjController(IBalancingAdjService balancingAdjService, IMapper mapper, ILogger<BalancingAdjController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _balancingAdjService = balancingAdjService;
        }

        [HttpPost("balancing-adjustment")]
        public async Task<IActionResult> CreateBalancingAdjustment(BalancingAdjustmentDto balancingAdjustmentDto)
        {
            try
            {
                var balancingAdjRecord = await _balancingAdjService.GetBalancingAdjAsync(balancingAdjustmentDto.AssetId);
                if (balancingAdjRecord != null)
                {
                    var error = new[] { "Asset mapping exist!" };
                    return StatusCode(400, new { errors = new { error } });
                }
                var balancingAdjToAdd = _mapper.Map<BalancingAdjustment>(balancingAdjustmentDto);
                balancingAdjToAdd.AssetId = balancingAdjustmentDto.AssetId;

                await _balancingAdjService.AddBalancingAdjAsync(balancingAdjToAdd);

                return Ok("Balancing Adjustment added successfully !!");

            }
            catch (Exception ex)
            {
                var error = new[] { "Error occured while trying to process your request please try again later !" };
                return StatusCode(500, new { errors = new { error } });
            }
        }
    }
}
