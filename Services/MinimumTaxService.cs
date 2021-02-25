using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Model;
using TaxComputationSoftware.Models;
using TaxComputationSoftware.Respoonse;

namespace TaxComputationAPI.Services
{
    public class MinimumTaxService : IMinimumTaxService
    {
        private readonly IEmailService _emailService;
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ILogger<MinimumTaxService> _logger;
        private readonly IMinimumTaxRepository _minimumTaxRepository;
        private readonly IProfitAndLossRepository _profitAndLossRepository;

        public MinimumTaxService(IEmailService emailService, IUtilitiesRepository utilitiesRepository, 
                                ICompaniesRepository companiesRepository, ILogger<MinimumTaxService> logger, 
                                IMinimumTaxRepository minimumTaxRepository, IProfitAndLossRepository profitAndLossRepository)
        {
            _emailService = emailService;
            _utilitiesRepository = utilitiesRepository;
            _companiesRepository = companiesRepository;
            _logger = logger;
            _minimumTaxRepository = minimumTaxRepository;
            _profitAndLossRepository = profitAndLossRepository;
        }

        public async Task<MinimumTaxResponse> AddOldMinimumTax(AddMinimumTaxDto addMinimumTaxDto)
        {
            string errorMessage = string.Empty;

            var result = await _profitAndLossRepository.GetProfitAndLossRecordAsync(addMinimumTaxDto.CompanyId, addMinimumTaxDto.FinancialYearId);

            if(result == null)
            {
                return new MinimumTaxResponse
                {
                    ResponseCode = System.Net.HttpStatusCode.NotFound,
                    ResponseDescription = "Company doesnot have profit and loss data",
                    Code = "10"
                };
            
            }

            var grossProft = result.ProfitAndLoss;

            if (addMinimumTaxDto.CompanyId <= 0)
            {
                return new MinimumTaxResponse
                {
                    ResponseCode = System.Net.HttpStatusCode.BadGateway,
                    ResponseDescription = "CompanyId is invalid",
                    Code = "10"
                };
            }

            if (addMinimumTaxDto.FinancialYearId <= 0)
            {
                return new MinimumTaxResponse
                {
                    ResponseCode = System.Net.HttpStatusCode.BadGateway,
                    ResponseDescription = "Financial Year is invalid",
                    Code = "10"
                };
            }

            try
            {

                var company = await _companiesRepository.GetCompanyAsync(addMinimumTaxDto.CompanyId);

                if (company == null)
                {
                    return new MinimumTaxResponse
                    {
                        ResponseCode = System.Net.HttpStatusCode.NotFound,
                        ResponseDescription = $"No Company with Id: {addMinimumTaxDto.CompanyId}",
                        Code = "10"
                    };
                }

                var financialYear = await _utilitiesRepository.GetFinancialCompanyAsync(addMinimumTaxDto.CompanyId);

                if (financialYear == null || !financialYear.Any() || financialYear.FirstOrDefault(p => p.Id == addMinimumTaxDto.FinancialYearId) == null)
                {
                    return new MinimumTaxResponse
                    {
                        ResponseCode = System.Net.HttpStatusCode.NotFound,
                        ResponseDescription = $"Financial year provided does not exist for {company.CompanyName}",
                        Code = "10"
                    };
                }

                var saveMinimum = new MinimumTaxModel
                {
                    CompanyId = addMinimumTaxDto.CompanyId,
                    FinancialYearId = addMinimumTaxDto.FinancialYearId,
                    GrossProfit = grossProft,
                    NetAsset = addMinimumTaxDto.NetAsset,
                    ShareCapital = addMinimumTaxDto.ShareCapital,
                    TurnOver = addMinimumTaxDto.TurnOver,
                    DateCreated = DateTime.Now
                };

                var data = await CalculateOldMinimumTax(saveMinimum);

                if (!Decimal.TryParse(data.Values[5].Value2, out decimal total))
                {
                    return new MinimumTaxResponse
                    {
                        ResponseCode = System.Net.HttpStatusCode.InternalServerError,
                        ResponseDescription = $"Error while calculating minimum tax",
                        Code = "15"
                    };
                }

                saveMinimum.MinimumTaxPayable = total;

                var exit = await _minimumTaxRepository.GetMinimumCompanyIdYearId(saveMinimum.CompanyId, saveMinimum.FinancialYearId);

                if(exit == null)
                {
                    await _minimumTaxRepository.SaveMinimum(saveMinimum);
                }
                else
                {
                    await _minimumTaxRepository.UpdatedMinimum(exit);
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);

                return new MinimumTaxResponse
                {
                    ResponseCode = System.Net.HttpStatusCode.InternalServerError,
                    ResponseDescription = errorMessage,
                    Code = "11"
                };

            }

            return new MinimumTaxResponse
            {
                ResponseCode = System.Net.HttpStatusCode.OK,
                ResponseDescription = "SUCCESSFUL",
                Code = "00"
            };

        }

        public async Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYear(int companyId, int yearId)
        {
            var record = await _minimumTaxRepository.GetMinimumTaxByCompanyIdAndYearId(companyId, yearId);
            return record;
        }

        public async Task<MinimumTaxResponse> GetOldMinimumTax(int companyId, int financialYearId)
        {
            var record = await _minimumTaxRepository.GetMinimumCompanyIdYearId(companyId, financialYearId);

            if(record == null)
            {
                return new MinimumTaxResponse
                {
                    ResponseCode = System.Net.HttpStatusCode.NotFound,
                    ResponseDescription = $"Minimum tax not found",
                    Code = "10"
                };
            }

            var data = await CalculateOldMinimumTax(record);

            return data;
        }

        public async Task<MinimumTaxPercentageValue> GetMinimumTaxPercentageCompanyIdYearId(int companyId, int yearId)
        {
            return await _minimumTaxRepository.GetMinimumTaxPercentageCompanyIdYearId(companyId, yearId);
        }

        public async Task<MinimumTaxPercentageValue> SaveMinimumPercentage(MinimumTaxPercentageValue minimumTaxDto)
        {
            return await _minimumTaxRepository.SaveMinimumPercentage(minimumTaxDto);
        }

        private async Task<MinimumTaxResponse> CalculateOldMinimumTax(MinimumTaxModel addMinimumTaxDto)
        {

            decimal _0_5_of_Gross_Profit = (decimal)((0.5 / 100) * ((double)addMinimumTaxDto.GrossProfit));

            decimal _0_5_of_Net_Assets = (decimal)((0.5 / 100) * ((double)addMinimumTaxDto.NetAsset));

            decimal _0_25_of_Share_Capital = (decimal)((0.25 / 100) * ((double)addMinimumTaxDto.ShareCapital));

            decimal _0_25_of_Turnover = (decimal)((0.25 / 100) * ((double)addMinimumTaxDto.TurnOver));

            decimal _0_125_Turnover_Execess_500000 = 0;

            decimal _maxTaxValue = 0;

            _maxTaxValue = (_0_5_of_Gross_Profit < _0_5_of_Net_Assets) ? (_0_5_of_Net_Assets < _0_25_of_Share_Capital) ? _0_25_of_Share_Capital : _0_5_of_Net_Assets : _0_5_of_Gross_Profit;

            if (addMinimumTaxDto.GrossProfit > addMinimumTaxDto.TurnOver) _0_125_Turnover_Execess_500000 = (decimal)((0.125 / 100) * ((double)(addMinimumTaxDto.GrossProfit - addMinimumTaxDto.TurnOver)));

            decimal _minimumTaxPayable = _maxTaxValue + _0_125_Turnover_Execess_500000;

            var data = new List<MinimumTaxDisplay>();

            //First Row
            var singleDate = new MinimumTaxDisplay();
            singleDate.Name = $"0.5% of Gross Profit {addMinimumTaxDto.GrossProfit.ToString().ValueMoneyFormatter("NGN", true)}";
            singleDate.Value1 = $"{Math.Round(_0_5_of_Gross_Profit).ToString().ValueMoneyFormatter("NGN", false)}";
            singleDate.Value2 = $"{0}";
            data.Add(singleDate);

            //Second Row
            singleDate = new MinimumTaxDisplay();
            singleDate.Name = $"0.5% of Net Assets {addMinimumTaxDto.NetAsset.ToString().ValueMoneyFormatter("NGN", true)}";
            singleDate.Value1 = $"{Math.Round(_0_5_of_Net_Assets).ToString().ValueMoneyFormatter("NGN", false)}";
            singleDate.Value2 = $"{Math.Round(_maxTaxValue).ToString().ValueMoneyFormatter("NGN", false)}";
            data.Add(singleDate);

            //Third Row
            singleDate = new MinimumTaxDisplay();
            singleDate.Name = $"0.25% of Paid-up Share Capital {addMinimumTaxDto.ShareCapital.ToString().ValueMoneyFormatter("NGN", true)}";
            singleDate.Value1 = $"{Math.Round(_0_25_of_Share_Capital).ToString().ValueMoneyFormatter("NGN", false)}";
            singleDate.Value2 = $"{0}";
            data.Add(singleDate);

            //Fourth Row
            singleDate = new MinimumTaxDisplay();
            singleDate.Name = $"0.25% of Turnover of {addMinimumTaxDto.TurnOver.ToString().ValueMoneyFormatter("NGN", true)}";
            singleDate.Value1 = $"{Math.Round(_0_25_of_Turnover).ToString().ValueMoneyFormatter("NGN", false)}";
            singleDate.Value2 = $"{0}";
            data.Add(singleDate);

            //Fifth Row
            singleDate = new MinimumTaxDisplay();
            singleDate.Name = $"0.125% of Turnover in excess of {addMinimumTaxDto.TurnOver.ToString().ValueMoneyFormatter("NGN", true)} 0.125% of =N= ({addMinimumTaxDto.GrossProfit} - {addMinimumTaxDto.TurnOver}) 0.125% of {(addMinimumTaxDto.GrossProfit - addMinimumTaxDto.TurnOver).ToString().ValueMoneyFormatter("NGN", true)}";
            singleDate.Value1 = $"{0}";
            singleDate.Value2 = $"{Math.Round(_0_125_Turnover_Execess_500000).ToString().ValueMoneyFormatter("NGN", false)}";
            data.Add(singleDate);

            //Sixth Row
            singleDate = new MinimumTaxDisplay();
            singleDate.Name = $"Minimum Tax Payable";
            singleDate.Value1 = $"{0}";
            singleDate.Value2 = $"{Math.Round(_minimumTaxPayable).ToString().ValueMoneyFormatter("NGN", false)}";
            data.Add(singleDate);

            return new MinimumTaxResponse
            {
                ResponseCode = System.Net.HttpStatusCode.OK,
                ResponseDescription = "SUCCESSFUL",
                Code = "00",
                Values = data
            };
        }
    }
}
