using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Dtos;
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

        public MinimumTaxService(IEmailService emailService, IUtilitiesRepository utilitiesRepository, ICompaniesRepository companiesRepository, ILogger<MinimumTaxService> logger, IMinimumTaxRepository minimumTaxRepository)
        {
            _emailService = emailService;
            _utilitiesRepository = utilitiesRepository;
            _companiesRepository = companiesRepository;
            _logger = logger;
            _minimumTaxRepository = minimumTaxRepository;
        } 

        public async Task<MinimumTaxResponse> AddMinimumTax(AddMinimumTaxDto addMinimumTaxDto)
        {
            string errorMessage = string.Empty;

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

                if(company == null)
                {
                    return new MinimumTaxResponse
                    {
                        ResponseCode = System.Net.HttpStatusCode.NotFound,
                        ResponseDescription = $"No Company with Id: {addMinimumTaxDto.CompanyId}",
                        Code = "10"
                    };
                }

                var financialYear = await _utilitiesRepository.GetFinancialCompanyAsync(addMinimumTaxDto.CompanyId);

                if(financialYear == null || !financialYear.Any() || financialYear.Any(p => p.Id != addMinimumTaxDto.FinancialYearId))
                {
                    return new MinimumTaxResponse
                    {
                        ResponseCode = System.Net.HttpStatusCode.NotFound,
                        ResponseDescription = $"Financial year provided does no exist for {company.CompanyName}",
                        Code = "10"
                    };
                }

                decimal _0_5_of_Gross_Profit = (decimal)((0.5 / 100) * ((double)addMinimumTaxDto.GrossProft));

                decimal _0_5_of_Net_Assets = (decimal)((0.5 / 100) * ((double)addMinimumTaxDto.NetAsset));

                decimal _0_25_of_Share_Capital = (decimal)((0.25 / 100) * ((double)addMinimumTaxDto.ShareCapital));

                decimal _0_25_of_Turnover = (decimal)((0.25 / 100) * ((double)addMinimumTaxDto.TurnOver));

                decimal _0_125_Turnover_Execess_500000 = 0;

                decimal _maxTaxValue = 0;

                _maxTaxValue = (_0_5_of_Gross_Profit < _0_5_of_Net_Assets) ? (_0_5_of_Net_Assets < _0_25_of_Share_Capital) ?_0_25_of_Share_Capital :_0_5_of_Net_Assets : _0_5_of_Gross_Profit ;

                if (addMinimumTaxDto.GrossProft > addMinimumTaxDto.TurnOver) _0_125_Turnover_Execess_500000 = (decimal)((0.125 / 100) * ((double)(addMinimumTaxDto.GrossProft - addMinimumTaxDto.TurnOver)));

                decimal _minimumTaxPayable = _maxTaxValue + _0_125_Turnover_Execess_500000;

                var data = new List<MinimumTaxDisplay>();

                //First Row
                var singleDate = new MinimumTaxDisplay();
                singleDate.Name = $"0.5% of Gross Profit {addMinimumTaxDto.GrossProft}";
                singleDate.Value1 = $"{_0_5_of_Gross_Profit}";
                singleDate.Value2 = $"{_maxTaxValue}";
                data.Add(singleDate);

                //Second Row
                singleDate = new MinimumTaxDisplay();
                singleDate.Name = $"0.5% of Gross Profit {addMinimumTaxDto.NetAsset}";
                singleDate.Value1 = $"{_0_5_of_Net_Assets}";
                singleDate.Value2 = $"{_maxTaxValue}";
                data.Add(singleDate);

                //Third Row
                singleDate = new MinimumTaxDisplay();
                singleDate.Name = $"0.5% of Gross Profit {addMinimumTaxDto.ShareCapital}";
                singleDate.Value1 = $"{_0_25_of_Share_Capital}";
                singleDate.Value2 = $"{_maxTaxValue}";
                data.Add(singleDate);

                //Fourth Row
                singleDate = new MinimumTaxDisplay();
                singleDate.Name = $"0.5% of Gross Profit {addMinimumTaxDto.TurnOver}";
                singleDate.Value1 = $"{_0_25_of_Turnover}";
                singleDate.Value2 = $"{0}";
                data.Add(singleDate);

                //Fifth Row
                singleDate = new MinimumTaxDisplay();
                singleDate.Name = $"0.125% of Turnover in excess of {addMinimumTaxDto.TurnOver} /n 0.125% of ({addMinimumTaxDto.GrossProft} - {addMinimumTaxDto.TurnOver}) /n 0.125% of ({(decimal)(addMinimumTaxDto.GrossProft - addMinimumTaxDto.TurnOver)})";
                singleDate.Value1 = $"{0}";
                singleDate.Value2 = $"{_0_125_Turnover_Execess_500000}";
                data.Add(singleDate);

                //Sixth Row
                singleDate = new MinimumTaxDisplay();
                singleDate.Name = $"Minimum Tax Payable";
                singleDate.Value1 = $"{0}";
                singleDate.Value2 = $"{_minimumTaxPayable}";
                data.Add(singleDate);

                //Todo: Persist Values
                var saveMinimum = new MinimumTaxModel 
                {
                    CompanyId = addMinimumTaxDto.CompanyId,
                    FinancialYearId = addMinimumTaxDto.FinancialYearId,
                    GrossProft = addMinimumTaxDto.GrossProft,
                    NetAsset = addMinimumTaxDto.NetAsset,
                    ShareCapital = addMinimumTaxDto.ShareCapital,
                    TurnOver = addMinimumTaxDto.TurnOver,
                    MinimumTaxPayable = _minimumTaxPayable,
                    DateCreated = DateTime.Now
                };
                
                await _minimumTaxRepository.SaveMinimum(saveMinimum);
                
                return new MinimumTaxResponse
                {
                    ResponseCode = System.Net.HttpStatusCode.OK,
                    ResponseDescription = "SUCCESSFUL",
                    Code = "00",
                    Values = data
                };
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError(e.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, e.Message);
            }

            return new MinimumTaxResponse
            {
                ResponseCode = System.Net.HttpStatusCode.InternalServerError,
                ResponseDescription = errorMessage,
                Code = "11"
            };

        }

        public async Task<MinimumTaxViewDto> GetMinimumTaxByCompanyIdAndYear(int companyId, int yearId)
        {
            var record = await _minimumTaxRepository.GetMinimumTaxByCompanyIdAndYearId(companyId, yearId);
            return record;
        }

        public Task<MinimumTaxPercentageValue> GetMinimumTaxPercentageCompanyIdYearId(int companyId, int yearId)
        {
             return this._minimumTaxRepository.GetMinimumTaxPercentageCompanyIdYearId(companyId,yearId);
        }

        public Task<MinimumTaxPercentageValue> SaveMinimumPercentage(MinimumTaxPercentageValue minimumTaxDto)
        {
             return  _minimumTaxRepository.SaveMinimumPercentage(minimumTaxDto);
        } 
    }
}
