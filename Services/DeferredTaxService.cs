using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Services
{
    public class DeferredTaxService : IDeferredTaxService
    {

        private readonly IIncomeTaxService _incomeTaxService;

        private readonly IDeferredTaxRepository _deferredTaxRepository;

        private readonly ICapitalAllowanceService _capitalAllowanceService;
        private readonly ITrialBalanceRepository _trialBalanceRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly IFixedAssetService _fixedAssetService;



        public DeferredTaxService(IIncomeTaxService incomeTaxService, ICapitalAllowanceService capitalAllowanceService, ITrialBalanceRepository trialBalanceRepository, IFixedAssetService fixedAssetService, IDeferredTaxRepository deferredTaxRepository, IUtilitiesRepository utilitiesRepository)
        {
            _incomeTaxService = incomeTaxService;
            _fixedAssetService = fixedAssetService;
            _deferredTaxRepository = deferredTaxRepository;
            _utilitiesRepository = utilitiesRepository;
            _trialBalanceRepository = trialBalanceRepository;
            _capitalAllowanceService = capitalAllowanceService;
        }
        public async Task SaveDeferredTax(CreateDeferredTax deferredTax)
        {

            foreach (var item in deferredTax.TrialBalanceList)
            {
                var fairValueGain = new FairValueGain();
                fairValueGain.SelectionId = GetSelectionType(item);
                fairValueGain.YearId = deferredTax.YearId;
                fairValueGain.TrialBalanceId = item.TrialBalanceId;
                fairValueGain.CompanyId = deferredTax.CompanyId;

                string trialBalanceValue = $"MAPPED TO [DEFERRED TAX] Fair Value Gain";
                await _trialBalanceRepository.UpdateTrialBalance(item.TrialBalanceId, trialBalanceValue, false);
                await _deferredTaxRepository.CreateFairValueGain(fairValueGain);

            }
            // if (!deferredTax.IsStarted)
            //  {
            //  _deferredTaxRepository.CreateDeferredTaxBroughtFoward(deferredTax.CompanyId, deferredTax.DeferredTaxBroughtFoward);

            // }


        }

        public async Task<List<DeferredTaxDto>> GetDeferredTax(int companyId, int yearId, bool IsBringDeferredTaxFoward)
        {

            var financialYear = await _utilitiesRepository.GetFinancialCompanyAsync(companyId);
            var financialYearRecord = financialYear.OrderByDescending(x=>x.Id).Where(x => x.Id < yearId).FirstOrDefault();
            var record = await _deferredTaxRepository.GetDeferredTaxFowarByCompanyId(companyId);
            var broughtFoward = record.ToList().Where(x => x.YearId == financialYearRecord.Id).OrderByDescending(x => x.Id).FirstOrDefault();
            var netbookValue = await _fixedAssetService.GetFixedAssetsByCompanyForDeferredTax(companyId, yearId);
            var capitalAllowanceSummary = await _capitalAllowanceService.GetCapitalAllowanceSummaryForDeferredTax(companyId);
           // var unrelievedCapitalAllowanceCf = await _incomeTaxService.GetIncomeTaxForDeferred(companyId, yearId);
           var unrelievedCf=await _incomeTaxService.GetAsessableLossUnRelievedByCompanyIdYearId(companyId,yearId);
            var fairValueGains = await _deferredTaxRepository.GetFairValueGainByCompanyIdAndYear(companyId, yearId);
            decimal deferredTaxCf = 0;
            decimal lessTotal = 0;
            if (broughtFoward == null)
            {
                broughtFoward = new DeferredTaxFoward
                {


                };
            }
            decimal temporaryDifference = 0;
            decimal deferredTaxLiabilityPercent = (decimal)30 / 100;
            decimal fairValueGainPercent = (decimal)10 / 100;
            decimal tenPercentFairValueGain = 0;
            decimal fairValueGainTotal = 0;
            decimal taxLiabilityAsset = 0;
            decimal lossCf = 0;
            bool isTaxable = false;

            var deferredTaxDto = new List<DeferredTaxDto>();
            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "Net Book Value of Fixed Assests",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(netbookValue)}",
                CanBolden = true
            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = "",

            });



            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "Less: ",
                ColumnOne = "",
                ColumnTwo = "",
                CanBolden = true
            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "Tax Written Down Value",
                ColumnOne = $"₦{Utilities.FormatAmount(capitalAllowanceSummary)}",
                ColumnTwo = "",
                CanBolden = true

            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "Unutilised Capital Allowances c/f",
                ColumnOne = $"₦{Utilities.FormatAmount(unrelievedCf.UnRelievedCf)}",
                ColumnTwo = "",
                CanBolden = true

            });
            // if(unrelievedCapitalAllowanceCf.Item1!=0)
            //  {
            //   lossCf+=-unrelievedCapitalAllowanceCf.Item1;
            //  }
            if (unrelievedCf.AssessableLoss != 0)
            {
                lossCf = unrelievedCf.AssessableLoss > 0 ? unrelievedCf.AssessableLoss : -unrelievedCf.AssessableLoss;


            }
            lessTotal = lossCf +unrelievedCf.UnRelievedCf + capitalAllowanceSummary;

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "Unabsorbed losses c/f",
                ColumnOne = $"₦{Utilities.FormatAmount(lossCf)}",
                ColumnTwo = $"₦{Utilities.FormatAmount(lessTotal)}",
                CanBolden = true
            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = "",

            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = "",

            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = "",

            });
            temporaryDifference = netbookValue - lessTotal;
            if (temporaryDifference > 0)
            {
                isTaxable = true;
                deferredTaxDto.Add(new DeferredTaxDto
                {
                    Description = "Taxable Temporary Difference",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(netbookValue - lessTotal)}",
                    CanBolden = true

                });
                temporaryDifference = netbookValue - lessTotal;
            }
            else
            {

                deferredTaxDto.Add(new DeferredTaxDto
                {
                    Description = "Deductable Temporary Difference",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(netbookValue - lessTotal)}",
                    CanBolden = true

                });
                temporaryDifference = netbookValue - lessTotal;

            }

            taxLiabilityAsset = temporaryDifference * deferredTaxLiabilityPercent; //30 percent
            if (isTaxable)
            {

                deferredTaxDto.Add(new DeferredTaxDto
                {
                    Description = "Deferred Tax Liability at 30%",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(temporaryDifference * deferredTaxLiabilityPercent)}",
                    CanBolden = true

                });
            }
            else
            {
                deferredTaxDto.Add(new DeferredTaxDto
                {
                    Description = "Deferred Tax Asset at 30%",
                    ColumnOne = "",
                    ColumnTwo = $"₦{Utilities.FormatAmount(temporaryDifference * deferredTaxLiabilityPercent)}",
                    CanBolden = true

                });

            }

            foreach (var value in fairValueGains)
            {
                if (value.SelectionId == 0)
                {
                    fairValueGainTotal += value.Debit;
                }
                else
                {
                    fairValueGainTotal += value.Credit;
                }

            }
            tenPercentFairValueGain = fairValueGainTotal * fairValueGainPercent;  //ten percent
            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "Deferred Tax on Fair Value Gain on Investment Property at 10%",
                ColumnOne = $"₦{Utilities.FormatAmount(fairValueGainTotal)}",
                ColumnTwo = $"₦{Utilities.FormatAmount(fairValueGainTotal * fairValueGainPercent)}",
                CanBolden = true

            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = ""

            });
            deferredTaxCf = taxLiabilityAsset + tenPercentFairValueGain;
            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(taxLiabilityAsset + tenPercentFairValueGain)}",
                CanBolden = true

            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "Deferred Tax B/F",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(broughtFoward.DeferredTaxCarriedFoward)}",
                CanBolden = true

            });

            deferredTaxDto.Add(new DeferredTaxDto
            {
                Description = "Deferred Tax Movement",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(deferredTaxCf - broughtFoward.DeferredTaxCarriedFoward)}",
                CanBolden = true

            });
            if (IsBringDeferredTaxFoward)
            {
                _deferredTaxRepository.CreateDeferredTaxBroughtFoward(companyId, deferredTaxCf, yearId);
            }
            //await _deferredTaxRepository.UpdateDeferredTaxBroughtFowardByDeferredTax(companyId, deferredTaxCf);

            return deferredTaxDto;


        }


        public int GetSelectionType(TrialBalanceValue incomeTax)
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