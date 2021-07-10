using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Services
{
    public class RollOverService
    {
        private readonly ICapitalAllowanceRepository _capitalAllowanceRepository;
        private readonly IUtilitiesRepository _utilityRepository;
        private readonly ICompaniesRepository _companyRepository;
        private readonly IDeferredTaxRepository _deferredTaxRepository;
        private readonly IIncomeTaxRepository _incomeTaxRepository;

        public RollOverService(ICapitalAllowanceRepository capitalAllowanceRepository, IIncomeTaxRepository incomeTaxRepository, IDeferredTaxRepository deferredTaxRepository, ICompaniesRepository companyRepository, IUtilitiesRepository utilityRepository)
        {
            _capitalAllowanceRepository = capitalAllowanceRepository;
            _utilityRepository = utilityRepository;
            _companyRepository = companyRepository;
            _deferredTaxRepository = deferredTaxRepository;
            _incomeTaxRepository = incomeTaxRepository;
        }

        public async Task RollBackYear(int companyId)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId);
            company.OpeningYear = company.OpeningYear.AddYears(-1);
            company.ClosingYear = company.ClosingYear.AddYears(-1);

            int tax = company.ClosingYear.AddYears(-1).Year;
            int financialYear = company.ClosingYear.Year;

            //TODO: Lazy man work: create a new repo method to query single pernotification database object
            // var prenotification = await GetPreNotificationScopedService();
            // var single = prenotification.Where(p => p.CompanyId == companyId).FirstOrDefault();

            await _companyRepository.UpdateCompanyDate(company);

        }


        public async Task<FinancialYear> GetFinancialYear(int yearId)
        {
            return await _utilityRepository.GetFinancialYearAsync(yearId);
        }



        public async Task<FinancialYear> GetLastFinancialYear(int companyId)
        {
            return await _utilityRepository.GetLastFinancialYearAsync(companyId);
        }

        public async Task<RollBackYear> GetRollBackYearAsync(int companyId)
        {
            return await _utilityRepository.GetRollBackYear(companyId);
        }

        public async Task DeleteFinancialYear(int yearId)
        {
            await _utilityRepository.DeleteLastFinancialYearAsync(yearId);
        }

        public async Task DeleteDeferredTaxBroughtFoward(int yearId)
        {
            await _deferredTaxRepository.DeleteDeferredTaxBroughtFoward(yearId);
        }

        public async Task DeleteIncomeTaxBroughtFoward(int yearId)
        {
            await _deferredTaxRepository.DeleteIncomeTaxBroughtFoward(yearId);
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
                        Id = x.Id,
                        TaxYear = x.YearId,
                        OpeningResidue = x.OpeningResidue.ToString(),
                        Addition = x.Addition.ToString(),
                        Disposal = x.Disposal.ToString(),
                        Initial = x.Initial.ToString(),
                        Annual = x.Addition.ToString(),
                        Total = x.Total.ToString(),
                        YearsToGo = x.YearsToGo,
                        NumberOfYearsAvailable = x.NumberOfYearsAvailable,
                        ClosingResidue = x.ClosingResidue.ToString(),
                        Channel = x.Channel,
                        CompanyId = x.CompanyId,
                        AssetId = x.AssetId,
                        CompanyCode = x.CompanyCode
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
                return new CapitalAllowanceDto()
                {
                    capitalAllowances = new List<CapitalAllowanceViewDto>()
                };
            }




        }

        public async Task SaveCapitalAllowanceSummary(int assetId, int companyId)
        {
            decimal openingResidue = 0;
            decimal addition = 0;
            decimal initial = 0;
            decimal annual = 0;
            decimal total = 0;
            decimal closingResidue = 0;
            decimal disposal = 0;
            var value = await _capitalAllowanceRepository.GetCapitalAllowance(assetId, companyId);
            if (value.Count() > 0)
            {

                foreach (var v in value)
                {
                    openingResidue += v.OpeningResidue;
                    addition += v.Addition;
                    initial += v.Initial;
                    annual += v.Annual;
                    total += v.Total;
                    closingResidue += v.ClosingResidue;
                    disposal += v.Disposal;
                }

                _capitalAllowanceRepository.SaveCapitaLAllowanceSummary(new CapitalAllowanceSummary
                {

                    OpeningResidue = openingResidue,
                    Addition = addition,
                    Initial = initial,
                    Annual = annual,
                    Total = total,
                    ClosingResidue = closingResidue,
                    Disposal = disposal,
                    AssetId = assetId,
                    CompanyId = companyId


                });
            }

        }

        public async Task DeleteCapitalAllowanceById(int capitalAllowanceId)
        {

            var itemToDelete = await _capitalAllowanceRepository.GetCapitalAllowanceById(capitalAllowanceId);
            var value = _capitalAllowanceRepository.DeleteCapitalAllowanceByAssetIdCompanyIdYearId(itemToDelete.CompanyId, int.Parse(itemToDelete.TaxYear), itemToDelete.AssetId);
            _capitalAllowanceRepository.DeleteCapitalAllowanceSummaryById(itemToDelete.AssetId, itemToDelete.CompanyId);
            SaveCapitalAllowanceSummary(itemToDelete.AssetId, itemToDelete.CompanyId);


        }

        public async Task DeleteOldCapitalAllowanceAndSummary(int companyId)
        {
            await _capitalAllowanceRepository.DeleteOldCapitalAllowanceAndSummary(companyId);
        }


        public async Task DeleteCapitalAllowanceAndSummary(int companyId)
        {
            await _capitalAllowanceRepository.DeleteCapitalAllowanceAndSummary(companyId);
        }
        /*  public async Task SaveOldCapitalAllowanceSummary(int companyId)
          {
                var values = await _capitalAllowanceRepository.GetCapitalAllowanceSummaryByCompanyId(companyId);
              var assetClasses = await _utilityRepository.GetAssetMappingAsync();
              foreach (var item in assetClasses)
              {
                  var values = await _capitalAllowanceRepository.GetCapitalAllowance(item.Id, companyId);

                  if (values.Count() > 0)
                  {
                      foreach (var value in values)
                      {
                          _capitalAllowanceRepository.SaveOldCapitaLAllowance(value, "");
                      }


                  }

              }


          }*/


        public async Task SaveRollFowardArchivedCapitalAllowance(int companyId)
        {


            var values = await _capitalAllowanceRepository.GetArchivedCapitalAllowanceByCompanyId(companyId);
            foreach (var item in values)
            {

                await _capitalAllowanceRepository.SaveOldArchivedCapitaLAllowance(item);

            }


        }
        public async Task SaveRollBackArchivedCapitalAllowance(int companyId)
        {


            var values = await _capitalAllowanceRepository.GetOldArchivedCapitalAllowanceByCompanyId(companyId);
            foreach (var item in values)
            {


                if (values.Count() > 0)
                {
                    foreach (var value in values)
                    {
                        _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(value, "");
                    }


                }

            }


        }

        public async Task SaveRollFowardCapitalAllowanceSummary(int companyId)
        {
            var value = await _capitalAllowanceRepository.GetCapitalAllowanceSummaryByCompanyId(companyId);
            if (value.Count() > 0)
            {
                foreach (var item in value)
                {
                    await _capitalAllowanceRepository.SaveOldCapitaLAllowanceSummary(item);
                }
            }
        }


        public async Task SaveRollBackCapitalAllowanceSummary(int companyId)
        {
            var value = await _capitalAllowanceRepository.GetOldCapitalAllowanceSummaryByCompanyId(companyId);
            if (value.Count() > 0)
            {
                foreach (var item in value)
                {
                    await _capitalAllowanceRepository.SaveCapitaLAllowanceSummary(item);
                }
            }
        }


        public async Task SaveRollFowardCapitalAllowance(int companyId)
        {

            var values = await _capitalAllowanceRepository.GetCapitalAllowanceByCompanyId(companyId);
            foreach (var item in values)
            {
                await _capitalAllowanceRepository.SaveOldCapitaLAllowance(item, "");
            }

        }

        public async Task SaveRollBackCapitalAllowance(int companyId)
        {

            var values = await _capitalAllowanceRepository.GetOldCapitalAllowanceByCompanyId(companyId);
            foreach (var item in values)
            {
                await _capitalAllowanceRepository.SaveCapitaLAllowance(item, item.Channel);

            }
        }




        public async Task CalculateAnnualCalculation(int companyId)
        {
            decimal annualValue = 0;
            decimal total = 0;
            decimal closingResidue = 0;
            var assetClasses = await _utilityRepository.GetAssetMappingAsync();

            //New Line
            var company = await _companyRepository.GetCompanyAsync(companyId);
            foreach (var item in assetClasses)
            {
                var values = await _capitalAllowanceRepository.GetCapitalAllowance(item.Id, companyId);
                var record = GetCapitalAllowance(values.ToList());
                if (record.capitalAllowances.Count > 0)
                {
                    foreach (var value in record.capitalAllowances)
                    {
                        if (value.Channel == Constants.FixedAsset)
                        {
                            var capitalAllowance = new CapitalAllowance
                            {
                                TaxYear = value.TaxYear,
                                OpeningResidue = decimal.Parse(value.ClosingResidue),
                                ClosingResidue = 0,
                                Addition = 0,
                                Disposal = 0,
                                Annual = 0,
                                Initial = 0,
                                Total = 0,
                                YearsToGo = 0,
                                CompanyId = companyId,
                                AssetId = value.AssetId,
                                CompanyCode = value.CompanyCode,
                                Channel = Constants.OpenOld,
                                NumberOfYearsAvailable = value.YearsToGo

                            };
                            await _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                            await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            await SaveCapitalAllowanceSummary(value.AssetId, companyId);


                        }

                        if (value.Channel == Constants.Closed)
                        {


                            var capitalAllowance = new CapitalAllowance
                            {
                                TaxYear = value.TaxYear,
                                OpeningResidue = decimal.Parse(value.ClosingResidue),
                                ClosingResidue = 0,
                                Addition = 0,
                                Disposal = 0,
                                Annual = 0,
                                Initial = 0,
                                Total = 0,
                                YearsToGo = 0,
                                CompanyId = companyId,
                                AssetId = value.AssetId,
                                CompanyCode = value.CompanyCode,
                                Channel = Constants.OpenOld,
                                NumberOfYearsAvailable = value.YearsToGo

                            };
                            await _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                            await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                            await SaveCapitalAllowanceSummary(value.AssetId, companyId);

                        }




                        if (value.Channel == Constants.OpenOld)
                        {


                            var annual = decimal.Parse(value.OpeningResidue) / value.NumberOfYearsAvailable;
                            annual = Math.Round(annual, 2);
                            var totalValue = annual;
                            var closingResidueValue = decimal.Parse(value.OpeningResidue) - totalValue;
                            var yearsAvailable = value.NumberOfYearsAvailable - 1;
                            if (yearsAvailable <= 0)
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = 10,
                                    ClosingResidue = 20,
                                    Addition = 0,
                                    Disposal = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Total = 0,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = value.AssetId,
                                    CompanyCode = value.CompanyCode,
                                    Channel = Constants.Zero,
                                    NumberOfYearsAvailable = 0

                                };

                                await _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                                await SaveCapitalAllowanceSummary(value.AssetId, companyId);
                            }
                            else
                            {
                                var capitalAllowance = new CapitalAllowance
                                {
                                    TaxYear = value.TaxYear,
                                    OpeningResidue = closingResidueValue,
                                    ClosingResidue = 0,
                                    Addition = 0,
                                    Disposal = 0,
                                    Annual = 0,
                                    Initial = 0,
                                    Total = 0,
                                    YearsToGo = 0,
                                    CompanyId = companyId,
                                    AssetId = value.AssetId,
                                    CompanyCode = value.CompanyCode,
                                    Channel = Constants.OpenOld,
                                    NumberOfYearsAvailable = yearsAvailable

                                };
                                await _capitalAllowanceRepository.SaveArchivedCapitaLAllowance(capitalAllowance, capitalAllowance.Channel);
                                await _capitalAllowanceRepository.UpdateCapitalAllowanceByFixedAssetOrBalancingAdjustemnt(capitalAllowance);
                                await SaveCapitalAllowanceSummary(value.AssetId, companyId);
                            }
                        }

                    }
                }


            }
            //New Line
            company.OpeningYear = company.OpeningYear.AddYears(1);
            company.ClosingYear = company.ClosingYear.AddYears(1);

            int tax = company.ClosingYear.AddYears(1).Year;
            int financialYear = company.ClosingYear.Year;

            //TODO: Lazy man work: create a new repo method to query single pernotification database object
            // var prenotification = await GetPreNotificationScopedService();
            // var single = prenotification.Where(p => p.CompanyId == companyId).FirstOrDefault();

            await _companyRepository.UpdateCompanyDate(company);
            await _utilityRepository.AddFinancialYearAsync(new FinancialYear { Name = $"{tax}", CompanyId = company.Id, OpeningDate = company.OpeningYear, ClosingDate = company.ClosingYear, FinancialDate = financialYear.ToString() });
            //await UpdatePreNotificationScopedService(new PreNotification { Id = single.Id, CompanyId = company.Id, OpeningDate = company.OpeningYear, ClosingDate = company.ClosingYear });
            var companyDetails = await _companyRepository.GetCompanyAsync(companyId);
            var currentYearId = await _utilityRepository.GetLastFinancialYearAsync(companyId);
            if (currentYearId != null)
            {
                await _utilityRepository.AddRollBackAsync(new RollBackYear
                {
                    CompanyId = companyId,
                    YearId = currentYearId.Id
                });
            }
            string text = $"This is to alert you that {companyDetails.CompanyName} annual calculation for the  end of financial year has been computed";
        }
    }
}