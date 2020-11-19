using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitAndLossController : ControllerBase
    {
        private readonly IProfitAndLossService _profitAndLossService;
        public ProfitAndLossController(IProfitAndLossService profitAndLossService)
        {
            _profitAndLossService = profitAndLossService;
        }
    }
}
