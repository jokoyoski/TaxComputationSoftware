using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxComputationSoftware.Dtos;

namespace TaxComputationSoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitalAllowanceSummaryController : ControllerBase
    {
        [HttpGet("companyId")]
        [Authorize]

        public async Task<IActionResult> Allowance(int companyId)
        {
            var value = new List<CapitalAllowanceSummaryDto>();
            value.Add(new CapitalAllowanceSummaryDto
            {
                Description = "Furniture and Fittings",
                OpeningResidue = "₦300,0",
                Addition = "₦23000",
                DisposalOrTransfer = "₦23000",
                Initial = "₦23000",
                Annual = "₦23000",
                Total = "₦23000",
                ClosingResidue = "₦23000"
            });
            value.Add(new CapitalAllowanceSummaryDto
            {
                Description = "Plant and Machinery",
                OpeningResidue = "₦300,0",
                Addition = "₦23000",
                DisposalOrTransfer = "₦23000",
                Initial = "₦23000",
                Annual = "₦23000",
                Total = "₦23000",
                ClosingResidue = "₦23000"
            });

            value.Add(new CapitalAllowanceSummaryDto
            {
                Description = "Office Equipments",
                OpeningResidue = "₦300,0",
                Addition = "₦23000",
                DisposalOrTransfer = "₦23000",
                Initial = "₦23000",
                Annual = "₦23000",
                Total = "₦23000",
                ClosingResidue = "₦23000"
            });

            value.Add(new CapitalAllowanceSummaryDto
            {
                Description = "LeaseHold",
                OpeningResidue = "₦300,0",
                Addition = "₦23000",
                DisposalOrTransfer = "₦23000",
                Initial = "₦23000",
                Annual = "₦23000",
                Total = "₦23000",
                ClosingResidue = "₦23000"
            });

            value.Add(new CapitalAllowanceSummaryDto
            {
                Description = "Total",
                OpeningResidue = "₦300,0",
                Addition = "₦23000",
                DisposalOrTransfer = "₦23000",
                Initial = "₦23000",
                Annual = "₦23000",
                Total = "₦23000",
                ClosingResidue = "₦23000"
            });




            return Ok(value);
        }

    }


}


