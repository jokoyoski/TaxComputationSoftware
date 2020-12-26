
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxComputationSoftware.Dtos;

namespace TaxComputationAPI.Controllers 
{
    [Route ("api/[controller]")]
    [ApiController]
    public class DeferredTaxController : ControllerBase 
    {
        public DeferredTaxController()
        {
            
        }


        [HttpGet]
        public async Task<IActionResult> GetDeferredTax(int companyId, string year)
        {
            var response = new List<IncomeTaxDto>
            {

                new  IncomeTaxDto 
                { 
                    Description = "Net Book Value of Fixed Assests",
                    ColumnOne = "",
                    ColumnTwo = "₦ 56,881,000.71",
                    Id=70
                },
                new  IncomeTaxDto 
                { 
                    Description = "Tax Written Down Value",
                    ColumnOne = "₦ 26,890,205.624",
                    ColumnTwo = "",
                    Id=34
                },
                new  IncomeTaxDto 
                { 
                    Description = "Unutilised Capital Allowances c/f",
                    ColumnOne = "₦ 0.376",
                    ColumnTwo = "",
                    Id=12
                },
                new  IncomeTaxDto 
                { 
                    Description = "Unabsorbed losses c/f",
                    ColumnOne = "₦ 0",
                    ColumnTwo = "₦ (26,890,205.624)",
                    Id=28
                },
                new  IncomeTaxDto 
                { 
                    Description = "Taxable Temporary Difference",
                    ColumnOne = "",
                    ColumnTwo = "₦ 29,990,794.71",
                    Id=91
                },
                new  IncomeTaxDto 
                { 
                    Description = "Deferred Tax Liability at 30%",
                    ColumnOne = "",
                    ColumnTwo = "₦ 8,997,238.413",
                    Id=2
                },
                new  IncomeTaxDto 
                { 
                    Description = "Deferred Tax on Fair Value Gain on Investment Property at 10%",
                    ColumnOne = "₦ 25,000,000",
                    ColumnTwo = "₦ 2,500,000",
                    Id=84
                },
                new  IncomeTaxDto 
                { 
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = "₦ 11,497,238.413",
                    Id=9
                },
                new  IncomeTaxDto 
                { 
                    Description = "Deferred Tax B/F 31/12/2018",
                    ColumnOne = "",
                    ColumnTwo = "₦ 13,071,175",
                    Id=9
                },
                new  IncomeTaxDto 
                { 
                    Description = "Deferred Tax Movement",
                    ColumnOne = "",
                    ColumnTwo = "₦ (1,573,936.587)",
                    Id=84
                }

            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeferredTax(CreateDeferredTax createDeferredTax)
        {

            return Ok();
        }

    }
}