using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Model;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IDeferredTaxRepository _deferredTaxRepository;
        private readonly IIncomeTaxRepository _incomeTaxTaxRepository;

        public CompaniesService(ICompaniesRepository companiesRepository, IIncomeTaxRepository incomeTaxTaxRepository, IUtilitiesRepository utilitiesRepository, IDeferredTaxRepository deferredTaxRepository, INotificationRepository notificationRepository)
        {
            _companiesRepository = companiesRepository;
            _utilitiesRepository = utilitiesRepository;
            _notificationRepository = notificationRepository;
            _deferredTaxRepository = deferredTaxRepository;
            _incomeTaxTaxRepository = incomeTaxTaxRepository;
        }

        public async Task<PagedList<Company>> GetCompaniesAsync(PaginationParams pagination)
        {
            return await _companiesRepository.GetCompaniesAsync(pagination);
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            return await _companiesRepository.GetCompanyAsync(id);
        }

        public async Task UpdateCompanyAsync(Company company)
        {

            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            if(company.Id > 0)
            {
                company.ClosingYear = company.OpeningYear.AddYears(1).AddDays(-1);
                
                await _companiesRepository.UpdateCompany(company);
            } 

        }

        public async Task AddCompanyAsync(Company company)
        {

            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            company.OpeningYear = company.ClosingYear.AddYears(-1).AddDays(1);

            await _companiesRepository.AddCompanyAsync(company);

            var companyDetails = await GetCompanyByTinAsync(company.TinNumber);

            var closing = companyDetails.ClosingYear;
            var opening = companyDetails.OpeningYear;
            var tax = closing.AddYears(1);

            int i = -9;

            while(i <= 0)
            {
                var previousOpening = opening.AddYears(i);
                var previousClosing = closing.AddYears(i);
                var previousTax = tax.AddYears(i);
                var previousFinancial = previousClosing.Year;

                await _utilitiesRepository.AddFinancialYearAsync(new FinancialYear { Name = previousTax.Year.ToString(), OpeningDate = previousOpening, ClosingDate = previousClosing, FinancialDate = previousFinancial.ToString(), CompanyId = companyDetails.Id });

                i++;
            }

            
            var companyFinancialYearList = await _utilitiesRepository.GetFinancialCompanyAsync(companyDetails.Id);

            _deferredTaxRepository.CreateDeferredTaxBroughtFoward(companyDetails.Id, company.DeferredTaxBroughtFoward, companyFinancialYearList[8].Id);
            _incomeTaxTaxRepository.CreateBalanceBroughtFoward(new BroughtFoward
            {
                UnRelievedCf = company.UnRelievedCf,
                LossCf = company.LossCf,
                CompanyId = companyDetails.Id,
                YearId = companyFinancialYearList[8].Id,
            });

            _notificationRepository.InsertPreNotification(new PreNotification{ CompanyId = companyDetails.Id, OpeningDate = opening, ClosingDate= closing});
         }
     
        public async Task<Company> GetCompanyByTinAsync(string tinNumber)
        {
            return await _companiesRepository.GetCompanyByTinAsync(tinNumber);
        }

        public async Task<object> GetCompanyInfoByFinancialYear(int companyId, int financialYearId)
        {
            return await _companiesRepository.GetCompanyInfoByFinancialYear(companyId, financialYearId);
        }

        public async  Task DeleteCompany(int Id)
        {
          _companiesRepository.DeleteCompany(Id);
        }
    }
}
