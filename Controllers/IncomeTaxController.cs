using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationSoftware.Dtos;

namespace TaxComputationSoftware.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class IncomeTaxController : ControllerBase
    {
        private readonly ILogger<IncomeTaxController> _logger;
        public IncomeTaxController(ILogger<IncomeTaxController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{companyId}/{yearId}")]
        [Authorize]
        public async Task<IActionResult> GetIncometax(int companyId, int yearId)
        {

            if (yearId == 0)
            {
                return StatusCode(400, new { errors = new[] { "Please select a Valid year" } });
            }
            try
            {

                var incomeListDto = new List<IncomeTaxDto>();

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Profits/Loss per accounts",
                    ColumnOne = "",
                    ColumnTwo = "₦(48,765,894)",
                    Id=70
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Add: Disallowable Expenses",
                    ColumnOne = "",
                    ColumnTwo = ""
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Depreciation",
                    ColumnOne = "₦3,256,182",
                    ColumnTwo = "",
                    CanDelete = true,
                    Id=8,
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Fines and Penalties",
                    ColumnOne = "₦3,256,182",
                    ColumnTwo = "",
                    CanDelete = true,
                    Id=7,
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Promotion",
                    ColumnOne = "₦3,256,182",
                    ColumnTwo = "₦490,003",
                    CanDelete = true,
                    Id=6
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Allowable Income",
                    ColumnOne = "",
                    ColumnTwo = ""
                });


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Gain on disposal assets",
                    ColumnOne = "₦3,256,182",
                    ColumnTwo = "₦490,003",
                    CanDelete = true,
                    Id=4,
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Asessable Loss",
                    ColumnOne = "",
                    ColumnTwo = "₦(48,765,894)"
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Balancing Charge",
                    ColumnOne = "",
                    ColumnTwo = "₦(48,765,894)"
                });


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Loss b/f",
                    ColumnOne = "",
                    ColumnTwo = "₦(48,765,894)"
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Loss c/f",
                    ColumnOne = "",
                    ColumnTwo = "₦(48,765,894)"
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Less Capital Allowances",
                    ColumnOne = "",
                    ColumnTwo = ""

                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Unrelieved Capital allowance b/f",
                    ColumnOne = "₦(48,765,894)",
                    ColumnTwo = ""
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Claims of the year",
                    ColumnOne = "₦(48,765,894)",
                    ColumnTwo = ""
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Balancing Allowance",
                    ColumnOne = "₦(48,765,894)",
                    ColumnTwo = ""
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Investment Allowance",
                    ColumnOne = "₦(48,765,894)",
                    ColumnTwo = ""
                }); incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Capital Allowance of the year",
                    ColumnOne = "₦34,000",
                    ColumnTwo = ""
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Capital Allowance Claimed",
                    ColumnOne = "-",
                    ColumnTwo = "-"
                });


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Unreleived Capital Allowance c/f",
                    ColumnOne = "₦34,000",
                    ColumnTwo = ""
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                }); incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Total Profit",
                    ColumnOne = "",
                    ColumnTwo = "NIL"
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Income Tax thereon on total profit at 30%",
                    ColumnOne = "",
                    ColumnTwo = "NIL"
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Education Tax @ 2% of Assessable profit",
                    ColumnOne = "",
                    ColumnTwo = "NIL"
                });

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = ""
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Minimum Tax Payable",
                    ColumnOne = "",
                    ColumnTwo = "NIL"
                });



                return Ok(incomeListDto);

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

        [HttpPost("add-income-tax")]
        [Authorize]
        public async Task<IActionResult> AddIncomeTax(CreateIncomeTaxDto createIncomeTaxDto)
        {
            try
            {
                return Ok("Income tax created successfully");

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }




        [HttpDelete("remove-allowable/disallowable/{id}")]
        [Authorize]
        public async Task<IActionResult> RemoveItem(int id)
        {
            try
            {
                return Ok("Income tax deleted successfully");

            }
            catch (Exception ex)
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation("Exception for {email}, {ex}", email, ex.Message);
                return StatusCode(500, new { errors = new[] { "Error occured while trying to process your request please try again later !" } });

            }
        }

    }
}

