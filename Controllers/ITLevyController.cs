using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITLevyController : ControllerBase
    {
        private readonly ILogger<ITLevyController> _logger;
        private readonly IProfitAndLossService _profitAndLossService;
        public ITLevyController(IProfitAndLossService profitAndLossService, ILogger<ITLevyController> logger)
        {
            _profitAndLossService = profitAndLossService;
            _logger = logger;
        }
    }
}
