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

        private readonly ICompaniesService _companiesService;

        public IncomeTaxService(IIncomeTaxRepository incomeTaxRepository, ICompaniesService companiesService, IMinimumTaxService minimumTaxService, IUtilitiesRepository utilitiesRepository, IInvestmentAllowanceService investmentAllowanceService, ICapitalAllowanceService capitalAllowanceService, IProfitAndLossService profitAndLossService, IBalancingAdjustmentService balancingAdjustmentService, ITrialBalanceRepository trialBalanceRepository)
        {
            _incomeTaxRepository = incomeTaxRepository;
            _profitAndLossService = profitAndLossService;
            _trialBalanceRepository = trialBalanceRepository;
            _balancingAdjustmentService = balancingAdjustmentService;
            _capitalAllowanceService = capitalAllowanceService;
            _investmentAllowanceService = investmentAllowanceService;
            _utilitiesRepository = utilitiesRepository;
            _minimumTaxService = minimumTaxService;
            _companiesService = companiesService;
        }

        public async Task<List<IncomeTaxDto>> GetIncomeTax(int companyId, int yearId, bool IsItLevyView, bool IsBringLossFoward)
        {
            var valuess = await _capitalAllowanceService.GetCapitalAllowanceByCompanyId(companyId);
            var results = valuess.FirstOrDefault(x => x.TaxYear == yearId.ToString());
            if (results == null)
            {
               return null;
            }
            decimal totalAllowable = 0;
            decimal totalDisallowable = 0;
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
            decimal incomeTaxPayablePercent = 0.3M;
            decimal educationTaxAssesibleProfit = 0.02M;
            var companyDetails = await _companiesService.GetCompanyAsync(companyId);
            decimal percentage = 0.01M;     //annual percentage rate
            bool isAssessibleProfit = false;
            decimal iTLevy = 0M;


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
                });

                if (iTLevy < 0)
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Less : I.T Levy",
                        ColumnOne = "",
                        ColumnTwo = $"₦{Utilities.FormatAmount(iTLevy)}",
                    });

                }
                else
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Less : I.T Levy",
                        ColumnOne = "",
                        ColumnTwo = $"₦({Utilities.FormatAmount(iTLevy)})",
                    });

                }

                profitOrLoss = profitOrLoss - iTLevy;
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(profitOrLoss)}",
                    CanBolden = true
                });




            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Profits/Loss per accounts",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(profitOrLoss)}",
                });

            }



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
                    totalAllowable += allowable.Credit;
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = allowable.Item,
                        ColumnOne = $"₦{Utilities.FormatAmount(allowable.Credit)}",
                        ColumnTwo = $"₦({Utilities.FormatAmount(totalAllowable)})",
                        CanDelete = true,
                        Id = allowable.Id,
                        CanUnderlineUpColumn1 = true

                    });



                }      //regular
                else
                {

                    totalAllowable += allowable.Credit;
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = allowable.Item,
                        ColumnOne = $"₦{Utilities.FormatAmount(allowable.Credit)}",
                        ColumnTwo = "",
                        CanDelete = true,
                        Id = allowable.Id
                    });

                }


            }
            var x = profitOrLoss + totalDisallowable;
            decimal accessibleType = x - totalAllowable;
            if (accessibleType < 0)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Asessable Loss",
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
                    Description = "Asessable Profit",
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
            });
            accessibleBalancingCharge = accessibleType + value.Item2;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(accessibleBalancingCharge)}",
                CanBolden = true
            });
            if (broughtFoward == null)
            {
                broughtFoward = new BroughtFoward
                {

                    LossCf = 0,

                };
            }
            losscf = accessibleBalancingCharge + broughtFoward.LossCf;
            if (losscf > 0)
            {
                losscf = 0;
            }

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Loss b/f",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(broughtFoward.LossCf)}",

            });
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Loss c/f",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(losscf)}",
                CanBolden = true
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
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Claims of the Year",
                ColumnOne = $"₦{Utilities.FormatAmount(total)}",
                ColumnTwo = "",
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Balancing Allowance",
                ColumnOne = $"₦{Utilities.FormatAmount(value.Item1)}",
                ColumnTwo = "",
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Investment Allowance",
                ColumnOne = $"₦{Utilities.FormatAmount(investment)}",
                ColumnTwo = "",
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

                twoThirdaccessibleType = (2 * accessibleType) / 3;
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
                    CanBolden = true,
                    CanUnderlineDownColumn2 = true
                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = " Income Tax thereon on total profit at 30%",
                    ColumnOne = "-",
                    ColumnTwo = "₦0.0",
                    CanBolden = true,
                    CanUnderlineDownColumn2 = true
                });

            }

            if (isAssessibleProfit)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Education Tax @ 2% of Assessable profit",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(educationTaxAssesibleProfit * accessibleType)}",
                    CanBolden = true,
                    CanUnderlineDownColumn2 = true


                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Education Tax @ 2% of Assessable profit",
                    ColumnOne = "-",
                    ColumnTwo = "₦0.0",
                    CanBolden = true,
                    CanUnderlineDownColumn2 = true
                });

            }


            if (IsItLevyView)
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "I.T. Levy",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(iTLevy)}",
                    CanBolden = true,
                    CanUnderlineDownColumn2 = true


                });


            }
            else
            {
                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "IT Levy",
                    ColumnOne = "-",
                    ColumnTwo = "₦0.0",
                    CanBolden = true,
                    CanUnderlineDownColumn2 = true
                });

            }
            //bool boma=true;
            if (companyDetails.MinimumTaxTypeId == 0)
            {    //// if old 
                var minimumTaxValue = await _minimumTaxService.GetOldMinimumTax(companyId, yearId);
                if (minimumTaxValue.ResponseDescription != "Minimum tax not found")
                {
                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Minimum Tax Payable",
                        ColumnOne = "-",
                        ColumnTwo = $"₦{Utilities.FormatAmount(minimumTaxValue.Values[5].Value2)}",
                        CanBolden = true,
                        CanUnderlineDownColumn2 = true

                    });

                }
                else
                {


                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Minimum Tax Payable",
                        ColumnOne = "-",
                        ColumnTwo = "₦0.0",
                        CanBolden = true,
                        CanUnderlineDownColumn2 = true

                    });

                }
            }
            else
            { ///if new 
                var minimumTaxValue = await _profitAndLossService.GetNewMinimumTax(companyId, yearId);
                var minimumTaxPercentage = await _minimumTaxService.GetMinimumTaxPercentageCompanyIdYearId(companyId, yearId);
                if (minimumTaxPercentage == null)
                {
                    minimumTaxPercentage = new MinimumTaxPercentageValue
                    {
                        MinimumTaxPercentage = 0
                    };

                }

                if (minimumTaxValue != null)
                {
                    var turnOver = minimumTaxValue.Revenue + minimumTaxValue.OtherOperatingGain + minimumTaxValue.OtherOperatingIncome;
                    var percent = minimumTaxPercentage.MinimumTaxPercentage * turnOver;

                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Minimum Tax Payable",
                        ColumnOne = "-",
                        ColumnTwo = $"₦{Utilities.FormatAmount(percent)}",
                        CanBolden = true,
                        CanUnderlineDownColumn2 = true

                    });

                }
                else
                {


                    incomeListDto.Add(new IncomeTaxDto
                    {
                        Description = "Minimum Tax Payable",
                        ColumnOne = "-",
                        ColumnTwo = "₦0.0",
                        CanBolden = true,
                        CanUnderlineDownColumn2 = true

                    });

                }
            }


            decimal values = 0;
            if (!isAssessibleProfit)
            {
                values = accessibleType;
            }
            else
            {
                values = 0;
            }
            await _incomeTaxRepository.SaveAsessableUnRelieved(new AsessableLossUnRelieved
            {
                CompanyId = companyId,
                YearId = yearId,
                UnRelievedCf = unrelievedCf,
                AssessableLoss = losscf,
            });

            await _incomeTaxRepository.CreateBalanceBroughtFoward(new BroughtFoward
            {
                LossCf = losscf,
                UnRelievedCf = unrelievedCf,
                YearId = yearId,
                CompanyId = companyId
            });




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
                    string trialBalanceValue = $"MAPPED TO [INCOME TAX] DisAllowable Expenses";
                    await _trialBalanceRepository.UpdateTrialBalance(item.TrialBalanceId, trialBalanceValue, false);
                }
                await _incomeTaxRepository.CreateAllowableDisAllowable(allowableDisAllowable);

            }


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