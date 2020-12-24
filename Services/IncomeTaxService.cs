using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Services
{
    public class IncomeTaxService : IIncomeTaxService
    {
        private readonly IIncomeTaxRepository _incomeTaxRepository;
        private readonly IProfitAndLossService _profitAndLossService;

        private readonly ITrialBalanceRepository _trialBalanceRepository;

        private readonly IBalancingAdjustmentService _balancingAdjustmentService;

        private readonly ICapitalAllowanceService _capitalAllowanceService;

        private readonly IInvestmentAllowanceService _investmentAllowanceService;

        public IncomeTaxService(IIncomeTaxRepository incomeTaxRepository, IInvestmentAllowanceService investmentAllowanceService, ICapitalAllowanceService capitalAllowanceService, IProfitAndLossService profitAndLossService, IBalancingAdjustmentService balancingAdjustmentService, ITrialBalanceRepository trialBalanceRepository)
        {
            _incomeTaxRepository = incomeTaxRepository;
            _profitAndLossService = profitAndLossService;
            _trialBalanceRepository = trialBalanceRepository;
            _balancingAdjustmentService = balancingAdjustmentService;
            _capitalAllowanceService = capitalAllowanceService;
            _investmentAllowanceService = investmentAllowanceService;
        }

        public async Task<List<IncomeTaxDto>> GetIncomeTax(int companyId, int yearId, bool IsItLevyView)
        {
            decimal totalAllowable = 0;
            decimal totalDisallowable = 0;
            // decimal profitAndLossPerAccount = 0;
            decimal capitalAllowanceClaimed = 0;
            decimal twoThirdaccessibleType = 0;
            decimal losscf = 0;
            decimal accessibleBalancingCharge = 0;
            var total = await _capitalAllowanceService.GetCapitalAllowanceSummaryForIncomeTax(companyId);
            var investment = await _investmentAllowanceService.GetInvestmentAllowanceForIncomeTax(companyId, yearId);
            decimal capitalAllowanceOfTheYear = 0;
            var value = await _balancingAdjustmentService.GetBalancingAdjustmentForIncomeTax(companyId, yearId.ToString());
            var broughtFoward = await _incomeTaxRepository.GetBroughtFowardByCompanyId(companyId);
            var incomeListDto = new List<IncomeTaxDto>();
            var profitOrLoss = await _profitAndLossService.GetProfitAndLossForIncomeTax(companyId, yearId);
            //  profitAndLossPerAccount = profitOrLoss;
            decimal taxableProfit = 0;
            decimal incomeTaxPayablePercent = (decimal)30 / 100;
            decimal educationTaxAssesibleProfit = (decimal)2 / 100;
            decimal percentage = (decimal)1 / 100;     //annual percentage rate
            decimal twothird = (decimal)2 / 3;
            twothird = Math.Round(twothird, 1);
            bool isAssessibleProfit = false;
            decimal iTLevy = 0;


            if (IsItLevyView)
            {
                string ITLevyValue = await _profitAndLossService.GetITLevy(companyId, yearId);
                if (!string.IsNullOrEmpty(ITLevyValue))
                {
                    decimal percent = percentage * decimal.Parse(ITLevyValue);
                    iTLevy = percent;

                }

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Profits/Loss per accounts",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(profitOrLoss)}"
                });

                if (iTLevy < 0)
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Less : I.T Levy",
                        ColumnOne = "",
                        ColumnTwo = $"₦{Utilities.FormatAmount(iTLevy)}"
                    });

                }
                else
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Less : I.T Levy",
                        ColumnOne = "",
                        ColumnTwo = $"₦({Utilities.FormatAmount(iTLevy)})"
                    });

                }


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = $"₦({Utilities.FormatAmount(profitOrLoss - iTLevy)})"
                });




            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Profits/Loss per accounts",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(profitOrLoss)}"
                });

            }


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

            var allowableDisAllowable = await _incomeTaxRepository.GetAllowableDisAllowableByCompanyIdYearIdAllowable(companyId, yearId, 0);
            int i = 0;
            foreach (var item in allowableDisAllowable)
            {

                i++;

                if (i == allowableDisAllowable.ToList().Count())
                {


                    totalDisallowable += item.Debit;
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = item.Item,
                        ColumnOne = $"₦{Utilities.FormatAmount(item.Debit)}",
                        ColumnTwo = $"₦{Utilities.FormatAmount(totalDisallowable)}",
                        Id = item.Id,
                        CanDelete = true,
                    });



                }      //regular
                else
                {

                    totalDisallowable += item.Debit;
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = item.Item,
                        ColumnOne = $"₦{Utilities.FormatAmount(item.Debit)}",
                        ColumnTwo = "",
                        Id = item.Id,
                        CanDelete = true,
                    });

                }


            }

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Allowable Income",
                ColumnOne = "",
                ColumnTwo = ""
            });

            i = 0;
            allowableDisAllowable = await _incomeTaxRepository.GetAllowableDisAllowableByCompanyIdYearIdAllowable(companyId, yearId, 1);  // get allowable
            foreach (var allowable in allowableDisAllowable)
            {
                i++;   //0 disallowable 1//allowable
                if (i == allowableDisAllowable.ToList().Count())
                {
                    totalAllowable += -allowable.Credit;
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = allowable.Item,
                        ColumnOne = $"₦{Utilities.FormatAmount(-allowable.Credit)}",
                        ColumnTwo = $"₦{Utilities.FormatAmount(totalAllowable)}",
                        CanDelete = true,
                        Id = allowable.Id
                    });



                }      //regular
                else
                {

                    totalAllowable += -allowable.Credit;
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = allowable.Item,
                        ColumnOne = $"₦({Utilities.FormatAmount(-allowable.Credit)})",
                        ColumnTwo = "",
                        CanDelete = true,
                        Id = allowable.Id
                    });

                }


            }


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
            var x = totalAllowable + totalDisallowable;

            decimal accessibleType = profitOrLoss + x;

            if (accessibleType < 0)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Accessible Loss",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(accessibleType)}",
                });
            }
            else
            {
                isAssessibleProfit = true;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Accessible Gain",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(accessibleType)}",
                });
            }

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
                ColumnTwo = $"₦{Utilities.FormatAmount(value.Item2)}",
            });
            accessibleBalancingCharge = accessibleType + value.Item2;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(accessibleBalancingCharge)}",
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
                ColumnTwo = $"₦{Utilities.FormatAmount(broughtFoward.LossBf)}",
            });
            losscf = accessibleBalancingCharge + broughtFoward.LossBf;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Loss c/f",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(losscf)}",
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = "",
            });
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Less Capital Allowances:",
                ColumnOne = "",
                ColumnTwo = "",
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Unrelieved Capital allowance b/f",
                ColumnOne = $"₦{Utilities.FormatAmount(broughtFoward.UnRelievedBf)}",
                ColumnTwo = ""
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Claims of the Year",
                ColumnOne = $"₦{Utilities.FormatAmount(total)}",
                ColumnTwo = ""
            });


            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Balancing Allowance",
                ColumnOne = $"₦{Utilities.FormatAmount(value.Item1)}",
                ColumnTwo = ""
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Investment Allowance",
                ColumnOne = $"₦{Utilities.FormatAmount(investment)}",
                ColumnTwo = ""
            });
            capitalAllowanceOfTheYear = broughtFoward.UnRelievedBf + total + value.Item1 + investment;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Capital allowance for the year",
                ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceOfTheYear)}",
                ColumnTwo = ""
            });

            if (!isAssessibleProfit)     //if accessible loss 
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Capital allowance claimed",
                    ColumnOne = "-",
                    ColumnTwo = "-"
                });
            }
            else
            {

                twoThirdaccessibleType = twothird * accessibleType;
                if (twoThirdaccessibleType > capitalAllowanceOfTheYear)
                {
                    capitalAllowanceClaimed = capitalAllowanceOfTheYear;
                }
                else
                {
                    capitalAllowanceClaimed = twoThirdaccessibleType;
                }
                if (capitalAllowanceClaimed < 0)
                {

                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Capital allowance claimed",
                        ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceClaimed)}",
                        ColumnTwo = $"₦{Utilities.FormatAmount(capitalAllowanceClaimed)}",
                    });

                }
                else
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Capital allowance claimed",
                        ColumnOne = $"₦({Utilities.FormatAmount(capitalAllowanceClaimed)})",
                        ColumnTwo = $"₦({Utilities.FormatAmount(capitalAllowanceClaimed)})",
                    });


                }

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Unrelieved Capital Allowance Carried Foward c/f",
                    ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceOfTheYear - capitalAllowanceClaimed)}",
                    ColumnTwo = ""
                });


            }

            if (!isAssessibleProfit)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Unrelieved Capital Allowance Carried Foward c/f",
                    ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceOfTheYear)}",
                    ColumnTwo = ""
                });

            }



            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = "",
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = "",
            });
            taxableProfit = accessibleBalancingCharge - capitalAllowanceClaimed;
            if (isAssessibleProfit)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Total Taxable Profit",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(taxableProfit)}"
                });
            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Total Taxable Profit",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                });
            }
            if (isAssessibleProfit)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = " Income Tax thereon on total profit at 30%",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(incomeTaxPayablePercent * taxableProfit)}",
                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = " Income Tax thereon on total profit at 30%",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                });

            }

            if (isAssessibleProfit)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Education Tax @ 2% of Assessable profit",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(educationTaxAssesibleProfit * taxableProfit)}",


                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Education Tax @ 2% of Assessable profit",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                });

            }


            if (IsItLevyView)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "I.T. Levy",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(iTLevy)}",


                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "IT Levy",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                });

            }











            var minimumTaxValue = await _profitAndLossService.GetMinimumTax(companyId, yearId);
            if (minimumTaxValue != null)
            {
                var turnOver = decimal.Parse(minimumTaxValue.Revenue) + decimal.Parse(minimumTaxValue.OtherIncome);
                var percent = percentage * turnOver;

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Minimum Tax Payable",
                    ColumnOne = "-",
                    ColumnTwo = $"₦{Utilities.FormatAmount(percent)}",
                });

            }
            else
            {


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Minimum Tax Payable",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                });

            }


            return incomeListDto;
        }

        public async Task SaveAllowableDisAllowable(CreateIncomeTaxDto incomeTax)
        {

            foreach (var item in incomeTax.IncomeList)
            {
                var allowableDisAllowable = new AllowableDisAllowable();
                allowableDisAllowable.SelectionId = GetSelectionType(item);
                allowableDisAllowable.YearId = incomeTax.YearId;
                allowableDisAllowable.TrialBalanceId = item.TrialBalanceId;
                allowableDisAllowable.CompanyId = incomeTax.CompanyId;
                if (incomeTax.TypeId == 1)
                {
                    allowableDisAllowable.IsAllowable = true;
                }
                else
                {
                    allowableDisAllowable.IsAllowable = false;
                }
                if (incomeTax.TypeId == 1)
                {
                    string trialBalanceValue = $"MAPPED TO [INCOME TAX] Allowable Income";
                    await _trialBalanceRepository.UpdateTrialBalance(item.TrialBalanceId, trialBalanceValue, false);
                }
                else
                {
                    string trialBalanceValue = $"MAPPED TO [INCOME TAX] DisAllowable Income";
                    await _trialBalanceRepository.UpdateTrialBalance(item.TrialBalanceId, trialBalanceValue, false);
                }
                await _incomeTaxRepository.CreateAllowableDisAllowable(allowableDisAllowable);

            }

            _incomeTaxRepository.CreateBalanceBroughtFoward(new BroughtFoward
            {
                CompanyId = incomeTax.CompanyId,
                IsStarted = false,
                LossBf = incomeTax.LossBroughtFoward,
                UnRelievedBf = incomeTax.UnrelievedCapitalAllowanceBroughtFoward
            });


        }



        public async Task DeleteAllowableDisAllowable(int allowableDisAllowableId)
        {

            var itemToDelete = await _incomeTaxRepository.GetAllowableDisAllowableById(allowableDisAllowableId);

            _incomeTaxRepository.DeleteAllowableDisAllowableById(allowableDisAllowableId);

            await _trialBalanceRepository.UpdateTrialBalance(itemToDelete.TrialBalanceId, null, true);  //fice

        }



        public async Task<BroughtFoward> GetBroughtFoward(int companyId)
        {

            return await _incomeTaxRepository.GetBroughtFowardByCompanyId(companyId);

        }






        public int GetSelectionType(IncomeListDto incomeTax)
        {


            if (!incomeTax.IsDebit && !incomeTax.IsBoth && incomeTax.IsCredit)
            {
                return 1;
            }

            if (incomeTax.IsDebit && !incomeTax.IsBoth && !incomeTax.IsCredit)
            {
                return 0;
            }

            return 0;

        }

    }
}