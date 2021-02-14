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

        private readonly IUtilitiesRepository _utilitiesRepository;

        private readonly IInvestmentAllowanceService _investmentAllowanceService;

        private readonly IMinimumTaxService _minimumTaxService;

        public IncomeTaxService(IIncomeTaxRepository incomeTaxRepository, IMinimumTaxService minimumTaxService, IUtilitiesRepository utilitiesRepository, IInvestmentAllowanceService investmentAllowanceService, ICapitalAllowanceService capitalAllowanceService, IProfitAndLossService profitAndLossService, IBalancingAdjustmentService balancingAdjustmentService, ITrialBalanceRepository trialBalanceRepository)
        {
            _incomeTaxRepository = incomeTaxRepository;
            _profitAndLossService = profitAndLossService;
            _trialBalanceRepository = trialBalanceRepository;
            _balancingAdjustmentService = balancingAdjustmentService;
            _capitalAllowanceService = capitalAllowanceService;
            _investmentAllowanceService = investmentAllowanceService;
            _utilitiesRepository = utilitiesRepository;
            _minimumTaxService = minimumTaxService;
        }

        public async Task<(decimal, decimal)> GetIncomeTaxForDeferred(int companyId, int yearId)
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
            var financialYear = await _utilitiesRepository.GetFinancialCompanyAsync(companyId);
            //var financialYearRecords = financialYear.Where(x => x.Id < yearId);
            var financialYearRecord = financialYear.OrderByDescending(x => x.Id).Where(x => x.Id < yearId).FirstOrDefault();
            // var financialYearRecord=financialYearRecords.OrderByDescending(x=>x.Id).FirstOrDefault();
            //   var financialYearRecord = financialYear.Where(x => x.Id < yearId).FirstOrDefault();
            var record = await _incomeTaxRepository.GetBroughtFowardByCompanyId(companyId);
            var broughtFoward = record.ToList().Where(x => x.YearId == financialYearRecord.Id).FirstOrDefault();
            var incomeListDto = new List<IncomeTaxDto>();
            var profitOrLoss = await _profitAndLossService.GetProfitAndLossForIncomeTax(companyId, yearId);
            decimal unrelievedCf = 0;
            //  profitAndLossPerAccount = profitOrLoss;
            decimal taxableProfit = 0;
            decimal incomeTaxPayablePercent = (decimal)30 / 100;
            decimal educationTaxAssesibleProfit = (decimal)2 / 100;
            decimal percentage = (decimal)1 / 100;     //annual percentage rate
            decimal twothird = (decimal)662 / 3;
            twothird = Math.Round(twothird, 1);
            bool isAssessibleProfit = false;
            decimal compareLoss = 0;
            decimal iTLevy = 0;

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

                    });

                }


            }

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Deduct Allowable Income",
                ColumnOne = "",
                ColumnTwo = "",
                CanBolden = true
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
                        ColumnOne = $"₦{Utilities.FormatAmount(-allowable.Credit)}",
                        ColumnTwo = "",
                        CanDelete = true,
                        Id = allowable.Id
                    });

                }


            }

            var x = totalAllowable + totalDisallowable;
            decimal accessibleType = profitOrLoss + x;

            if (accessibleType < 0)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Accessible Loss",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(accessibleType)}",
                    CanBolden = true,
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
                    CanBolden = true,
                });
            }


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

            losscf = profitOrLoss + broughtFoward.LossCf;
            if (losscf > 0)
            {
                losscf = 0;
            }

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Loss b/f",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(broughtFoward.LossCf)}",
                CanBolden = true
            });
            //losscf = losscf;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Loss c/f",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(losscf)}",
                CanBolden = true
            });



            /*  if (broughtFoward.LossCf != 0)
            {
                compareLoss += -broughtFoward.LossCf;
            }
             */

            /*var

            if (compareLoss > 0 && !isAssessibleProfit) //los broughtfoward + loss
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Loss b/f",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(broughtFoward.LossCf)}",
                    CanBolden = true
                });
                losscf = accessibleBalancingCharge + broughtFoward.LossCf;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Loss c/f",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(losscf)}",
                    CanBolden = true
                });

            }


            if (compareLoss > 0 && isAssessibleProfit) //loss brought fooward and gain
            {

                if (accessibleBalancingCharge > compareLoss)
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Loss b/f",
                        ColumnOne = "",
                        ColumnTwo = $"₦{Utilities.FormatAmount(broughtFoward.LossCf)}",
                        CanBolden = true
                    });
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Current Gain is Greater than Loss b/f",
                        ColumnOne = "",
                        ColumnTwo = "",
                        CanBolden = true
                    });

                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Loss c/f",
                        ColumnOne = "",
                        ColumnTwo = "-",
                        CanBolden = true
                    });
                    losscf = 0;
                }
                else if (accessibleBalancingCharge < compareLoss)
                {

                    losscf = compareLoss - accessibleBalancingCharge;
                    losscf = -losscf;
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Loss b/f",
                        ColumnOne = "",
                        ColumnTwo = $"₦{Utilities.FormatAmount(broughtFoward.LossCf)}",
                    });
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Current Gain is Lesser than Loss b/f",
                        ColumnOne = "",
                        ColumnTwo = "",
                        CanBolden = true
                    });

                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Loss c/f",
                        ColumnOne = "",
                        ColumnTwo = $"₦{Utilities.FormatAmount(losscf)}",
                        CanBolden = true
                    });

                }
            }


            if (broughtFoward.LossCf == 0 && isAssessibleProfit) //no loss bf + gain
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "No Loss b/f and No Current Loss",
                    ColumnOne = "",
                    ColumnTwo = "",
                    CanBolden = true
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Loss c/f",
                    ColumnOne = "",
                    ColumnTwo = "",
                    CanBolden = true
                });
                losscf = 0;
            }


            if (broughtFoward.LossCf == 0 && !isAssessibleProfit)   //no loss bf  + loss
            {
                losscf = accessibleBalancingCharge;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "No Loss b/f but Current Loss Exist",
                    ColumnOne = "",
                    ColumnTwo = "",
                    CanBolden = true
                });
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Loss c/f",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(losscf)}",
                    CanBolden = true
                });

            }  */

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
                CanBolden = true
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Unrelieved Capital allowance b/f",
                ColumnOne = $"₦{Utilities.FormatAmount(broughtFoward.UnRelievedCf)}",
                ColumnTwo = "",
                CanBolden = true
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Claims of the Year",
                ColumnOne = $"₦{Utilities.FormatAmount(total)}",
                ColumnTwo = "",
                CanBolden = true
            });


            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Balancing Allowance",
                ColumnOne = $"₦{Utilities.FormatAmount(value.Item1)}",
                ColumnTwo = "",
                CanBolden = true
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Investment Allowance",
                ColumnOne = $"₦{Utilities.FormatAmount(investment)}",
                ColumnTwo = "",
                CanBolden = true
            });
            capitalAllowanceOfTheYear = broughtFoward.UnRelievedCf + total + value.Item1 + investment;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Capital allowance for the year",
                ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceOfTheYear)}",
                ColumnTwo = "",
                CanBolden = true
            });

            if (!isAssessibleProfit)     //if accessible loss 
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Capital allowance claimed",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                    CanBolden = true
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
                        CanBolden = true
                    });

                }
                else
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Capital allowance claimed",
                        ColumnOne = $"₦({Utilities.FormatAmount(capitalAllowanceClaimed)})",
                        ColumnTwo = $"₦({Utilities.FormatAmount(capitalAllowanceClaimed)})",
                        CanBolden = true
                    });


                }
                unrelievedCf = capitalAllowanceOfTheYear - capitalAllowanceClaimed;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Unrelieved Capital Allowance Carried Foward c/f",
                    ColumnOne = $"₦{Utilities.FormatAmount(unrelievedCf)}",
                    ColumnTwo = "",
                    CanBolden = true
                });


            }

            if (!isAssessibleProfit)
            {
                unrelievedCf = capitalAllowanceOfTheYear;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Unrelieved Capital Allowance Carried Foward c/f",
                    ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceOfTheYear)}",
                    ColumnTwo = "",
                    CanBolden = true
                });

            }
            return (losscf, unrelievedCf);
        }



        public async Task<List<IncomeTaxDto>> GetIncomeTax(int companyId, int yearId, bool IsItLevyView, bool IsBringLossFoward)
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
            var financialYear = await _utilitiesRepository.GetFinancialCompanyAsync(companyId);
            var result = financialYear.OrderByDescending(x => x.Id);
            var result1 = result.Where(x => x.Id < yearId);
            var financialYearRecord = result1.FirstOrDefault();
            var record = await _incomeTaxRepository.GetBroughtFowardByCompanyId(companyId);
            var broughtFoward = record.ToList().Where(x => x.YearId == financialYearRecord.Id).FirstOrDefault();
            var incomeListDto = new List<IncomeTaxDto>();
            var profitOrLoss = await _profitAndLossService.GetProfitAndLossForIncomeTax(companyId, yearId);
            decimal unrelievedCf = 0;
            decimal taxableProfit = 0;
            decimal incomeTaxPayablePercent = (decimal)30 / 100;
            decimal educationTaxAssesibleProfit = (decimal)2 / 100;
            decimal percentage = (decimal)1 / 100;     //annual percentage rate
            decimal twothird = (decimal)662 / 3;
            twothird = Math.Round(twothird, 1);
            bool isAssessibleProfit = false;
            decimal compareLoss = 0;
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
                    ColumnTwo = $"₦{Utilities.FormatAmount(profitOrLoss)}",
                    CanBolden = true
                });

                if (iTLevy < 0)
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Less : I.T Levy",
                        ColumnOne = "",
                        ColumnTwo = $"₦{Utilities.FormatAmount(iTLevy)}",
                        CanBolden = true
                    });

                }
                else
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Less : I.T Levy",
                        ColumnOne = "",
                        ColumnTwo = $"₦({Utilities.FormatAmount(iTLevy)})",
                        CanBolden = true
                    });

                }

                profitOrLoss = profitOrLoss - iTLevy;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(profitOrLoss)}"
                });




            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Profits/Loss per accounts",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(profitOrLoss)}",
                    CanBolden = true
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
                ColumnTwo = "",
                CanBolden = true,
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
                Description = "Deduct Allowable Income",
                ColumnOne = "",
                ColumnTwo = "",
                CanBolden = true
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
                        ColumnOne = $"₦{Utilities.FormatAmount(-allowable.Credit)}",
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
                    CanBolden = true,
                });
            }
            else
            {
                isAssessibleProfit = true;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Asessable Gain",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(accessibleType)}",
                    CanBolden = true,
                });
            }


            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Balancing Charge",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(value.Item2)}",
                CanBolden = true
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
            if (broughtFoward == null)
            {
                broughtFoward = new BroughtFoward
                {

                    LossCf = 0,

                };
            }
            /* if (broughtFoward.LossCf != 0)
            {
                compareLoss += -broughtFoward.LossCf;
            } */
            losscf = profitOrLoss + broughtFoward.LossCf;
            if (losscf > 0)
            {
                losscf = 0;
            }

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Loss b/f",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(broughtFoward.LossCf)}",
                CanBolden = true
            });
            //losscf = losscf;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Loss c/f",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(losscf)}",
                CanBolden = true
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
                CanBolden = true
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Unrelieved Capital allowance b/f",
                ColumnOne = $"₦{Utilities.FormatAmount(broughtFoward.UnRelievedCf)}",
                ColumnTwo = "",
                CanBolden = true
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Claims of the Year",
                ColumnOne = $"₦{Utilities.FormatAmount(total)}",
                ColumnTwo = "",
                CanBolden = true
            });


            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Balancing Allowance",
                ColumnOne = $"₦{Utilities.FormatAmount(value.Item1)}",
                ColumnTwo = "",
                CanBolden = true
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Investment Allowance",
                ColumnOne = $"₦{Utilities.FormatAmount(investment)}",
                ColumnTwo = "",
                CanBolden = true
            });
            capitalAllowanceOfTheYear = broughtFoward.UnRelievedCf + total + value.Item1 + investment;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Capital allowance for the year",
                ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceOfTheYear)}",
                ColumnTwo = "",
                CanBolden = true
            });

            if (!isAssessibleProfit)     //if accessible loss 
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Capital allowance claimed",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                    CanBolden = true
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
                        CanBolden = true
                    });

                }
                else
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Capital allowance claimed",
                        ColumnOne = $"₦({Utilities.FormatAmount(capitalAllowanceClaimed)})",
                        ColumnTwo = $"₦({Utilities.FormatAmount(capitalAllowanceClaimed)})",
                        CanBolden = true
                    });


                }
                unrelievedCf = capitalAllowanceOfTheYear - capitalAllowanceClaimed;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Unrelieved Capital Allowance Carried Foward c/f",
                    ColumnOne = $"₦{Utilities.FormatAmount(unrelievedCf)}",
                    ColumnTwo = "",
                    CanBolden = true
                });


            }

            if (!isAssessibleProfit)
            {
                unrelievedCf = capitalAllowanceOfTheYear;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Unrelieved Capital Allowance Carried Foward c/f",
                    ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceOfTheYear)}",
                    ColumnTwo = "",
                    CanBolden = true
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
                    ColumnTwo = $"₦{Utilities.FormatAmount(taxableProfit)}",
                    CanBolden = true,

                });
            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Total Taxable Profit",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                    CanBolden = true,

                });
            }
            if (isAssessibleProfit)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = " Income Tax thereon on total profit at 30%",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(incomeTaxPayablePercent * taxableProfit)}",
                    CanBolden = true
                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = " Income Tax thereon on total profit at 30%",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                    CanBolden = true
                });

            }

            if (isAssessibleProfit)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Education Tax @ 2% of Assessable profit",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(educationTaxAssesibleProfit * taxableProfit)}",
                    CanBolden = true


                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Education Tax @ 2% of Assessable profit",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                    CanBolden = true
                });

            }


            if (IsItLevyView)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "I.T. Levy",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(iTLevy)}",
                    CanBolden = true


                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "IT Levy",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                    CanBolden = true
                });

            }

            var minimumTaxValue = await _profitAndLossService.GetMinimumTax(companyId, yearId);
            var minimumTaxPercentage = await _minimumTaxService.GetMinimumTaxPercentageCompanyIdYearId(companyId, yearId);
            if (minimumTaxPercentage == null)
            {
                minimumTaxPercentage.MinimumTaxPercentage = 0;
            }

            if (minimumTaxValue != null)
            {
                var turnOver = decimal.Parse(minimumTaxValue.Revenue) + decimal.Parse(minimumTaxValue.OtherIncome);
                var percent = minimumTaxPercentage.MinimumTaxPercentage * turnOver;

                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Minimum Tax Payable",
                    ColumnOne = "-",
                    ColumnTwo = $"₦{Utilities.FormatAmount(percent)}",
                    CanBolden = true
                });

            }
            else
            {


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Minimum Tax Payable",
                    ColumnOne = "-",
                    ColumnTwo = "-",
                    CanBolden = true
                });

            }
            decimal values=0;
            if(!isAssessibleProfit){
              values=accessibleType;
            }else{
                values=0;
            }
            _incomeTaxRepository.SaveAsessableUnRelieved(new AsessableLossUnRelieved{
                CompanyId=companyId,
                YearId=yearId,
                UnRelievedCf=unrelievedCf,
                AssessableLoss=values,
            });
            if (IsBringLossFoward)
            {
                _incomeTaxRepository.CreateBalanceBroughtFoward(new BroughtFoward
                {
                    LossCf = losscf,
                    UnRelievedCf = unrelievedCf,
                    YearId = yearId,
                    CompanyId = companyId
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

            /*  _incomeTaxRepository.CreateBalanceBroughtFoward(new BroughtFoward
              {
                  CompanyId = incomeTax.CompanyId,
                  IsStarted = true,
                  LossCf = incomeTax.LossBroughtFoward,
                  UnRelievedBf = incomeTax.UnrelievedCapitalAllowanceBroughtFoward
              }); */


        }



        public async Task DeleteAllowableDisAllowable(int allowableDisAllowableId)
        {

            var itemToDelete = await _utilitiesRepository.GetAllowableDisAllowableById(allowableDisAllowableId);
            _utilitiesRepository.DeleteAllowableDisAllowableById(allowableDisAllowableId);


        }



        public async Task<BroughtFoward> GetBroughtFoward(int companyId)
        {

            return null;

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

        public Task<AsessableLossUnRelieved> SaveAsessableUnRelieved(AsessableLossUnRelieved asessableLossUn)
        {
            return _incomeTaxRepository.SaveAsessableUnRelieved(asessableLossUn);
        }

        public Task<AsessableLossUnRelieved> GetAsessableLossUnRelievedByCompanyIdYearId(int companyId, int yearId)
        {
            return _incomeTaxRepository.GetAsessableLossUnRelievedByCompanyIdYearId(companyId, yearId);
        }
    }
}