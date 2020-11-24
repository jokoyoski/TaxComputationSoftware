using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;

namespace TaxComputationAPI.Services
{
    public class CapitalAllowanceService : ICapitalAllowanceService
    {
        private readonly ICapitalAllowanceRepository _capitalAllowanceRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;

        public CapitalAllowanceService(ICapitalAllowanceRepository capitalAllowanceRepository, IUtilitiesRepository utilitiesRepository)
        {
            _capitalAllowanceRepository = capitalAllowanceRepository;
            _utilitiesRepository = utilitiesRepository;
        }

        public async Task<CapitalAllowanceDto> GetCapitalAllowance(int assetId, int companyId)
        {

            var capitalAllowance = await _capitalAllowanceRepository.GetCapitalAllowance(assetId, companyId);


            return GetCapitalAllowance(capitalAllowance.ToList());
        }

        public Task<int> SaveCapitalAllowance(CapitalAllowance capitalAllowance)
        {

            return _capitalAllowanceRepository.SaveCapitaLAllowance(capitalAllowance);

        }



        public async Task<int> SaveCapitalAllowanceFromFixedAsset(decimal addition, string year, int companyId, int assetId)
        {


            var assetDetails = await _utilitiesRepository.GetAssetMappingById(assetId);
            int totalNoOfYears = (int)100 / assetDetails.Annual;

            var additionValue = addition;
            var disposal = 0;

            decimal initial = addition * assetDetails.Initial / 100;
            var annual = addition - initial / totalNoOfYears;
            var total = initial + annual;
            var closingResidue = addition - total;
            var remianingYears = totalNoOfYears - 1;

            var previousRecord = await _capitalAllowanceRepository.GetCapitalAllowanceByAssetIdYear(assetId, companyId, year);

            var capitalAllowance = new CapitalAllowance
            {
                TaxYear = year,
                OpeningResidue = closingResidue,
                ClosingResidue = closingResidue,
                Annual = annual,
                Initial = 0,
                Total = total,
                YearsToGo = remianingYears.ToString(),
                CompanyId = companyId,
                AssetId = assetId,


            };
            if (previousRecord != null)
            {

                return await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAsset(capitalAllowance);

            }
            else
            {
                return await _capitalAllowanceRepository.SaveCapitaLAllowance(capitalAllowance);
            }

        }


        public async Task<int> SaveCapitalAllowanceFromBalancingAdjustment(decimal residue, string year, int companyId, int assetId)
        {

            var residueValue = residue;
            var previousRecord = await _capitalAllowanceRepository.GetCapitalAllowanceByAssetIdYear(assetId, companyId, year);
            decimal openingValue = previousRecord.OpeningResidue - residue;
            decimal closingValue = openingValue - previousRecord.Total;
            var capitalAllowance = new CapitalAllowance
            {
                TaxYear = year,
                OpeningResidue = openingValue,
                ClosingResidue = closingValue,
                CompanyId = companyId,
                AssetId = assetId,


            };


            return await _capitalAllowanceRepository.UpdateCapitalAllowanceBybalancingAdjustment(capitalAllowance);

        }


        private CapitalAllowanceDto GetCapitalAllowance(List<CapitalAllowance> capitalAllowances)
        {
            var capitalAllowanceList = new List<CapitalAllowanceViewDto>();
            if (capitalAllowances.Count > 0)
            {
                var capitalAllowanceDto = new CapitalAllowanceDto();
                var capitalAllowance = new CapitalAllowance();
                decimal openingResidualTotal = 0;
                decimal disposalTotal = 0;
                decimal initialTotal = 0;
                decimal annualTotal = 0;
                decimal totalTotal = 0;
                decimal closingResidueTotal = 0;
                decimal additionTotal = 0;
                foreach (var item in capitalAllowances)
                {

                    if (item.OpeningResidue > 0)
                    {
                        openingResidualTotal += Utilities.GetDecimal(item.OpeningResidue);
                    }

                    if (item.Addition > 0)
                    {
                        additionTotal += Utilities.GetDecimal(item.Addition);
                    }

                    if (item.Disposal > 0)
                    {
                        disposalTotal += Utilities.GetDecimal(item.Disposal);
                    }
                    if (item.Initial > 0)
                    {
                        initialTotal += Utilities.GetDecimal(item.Initial);
                    }
                    if (item.Annual > 0)
                    {
                        annualTotal += Utilities.GetDecimal(item.Annual);
                    }
                    if (item.Total > 0)
                    {
                        totalTotal += Utilities.GetDecimal(item.Total);
                    }
                    if (item.ClosingResidue > 0)
                    {
                        closingResidueTotal += Utilities.GetDecimal(item.ClosingResidue);
                    }

                }
                foreach (var x in capitalAllowances)
                {
                    var m = new CapitalAllowanceViewDto
                    {
                        TaxYear = x.TaxYear,
                        OpeningResidue = Utilities.FormatAmount(x.OpeningResidue),
                        Addition = Utilities.FormatAmount(x.Addition),
                        Disposal = Utilities.FormatAmount(x.Disposal),
                        Initial = Utilities.FormatAmount(x.Initial),
                        Annual = Utilities.FormatAmount(x.Annual),
                        Total = Utilities.FormatAmount(x.Total),
                        YearsToGo = x.YearsToGo,
                        ClosingResidue = Utilities.FormatAmount(x.ClosingResidue),
                    };
                    capitalAllowanceList.Add(m);
                }

                return new CapitalAllowanceDto()
                {
                    OpeningResidualTotal = openingResidualTotal,
                    AdditionTotal = additionTotal,
                    DisposalTotal = disposalTotal,
                    InitialTotal = initialTotal,
                    AnnualTotal = annualTotal,
                    TotalTotal = totalTotal,
                    ClosingResidueTotal = closingResidueTotal,
                    capitalAllowances = capitalAllowanceList




                };
            }
            else
            {
                return new CapitalAllowanceDto();
            }




        }
    }
}
