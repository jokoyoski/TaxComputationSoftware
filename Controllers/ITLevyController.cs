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
        private readonly IProfitAndLossService _profitAndLossService;
        public ITLevyController(IProfitAndLossService profitAndLossService)
        {
            _profitAndLossService = profitAndLossService;
        }
    }
}
