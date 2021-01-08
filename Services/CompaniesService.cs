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

        public async Task AddCompanyAsync(Company company)
        {

            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            await _companiesRepository.AddCompanyAsync(company);

            var companyDetails = await GetCompanyByTinAsync(company.TinNumber);

            var opening = companyDetails.OpeningYear;
            var closing = companyDetails.OpeningYear.AddDays(364);

            var previousOpening = opening.AddYears(-1);
            var previousClosing = closing.AddYears(-1);
            await _utilitiesRepository.AddFinancialYearAsync(new FinancialYear { Name = $"{previousOpening.ToString("dddd, dd MMMM yyyy")} - {previousClosing.ToString("dddd, dd MMMM yyyy")}", OpeningDate = previousOpening, ClosingDate = previousClosing, CompanyId = companyDetails.Id });

            var companyFinancialYearList = await _utilitiesRepository.GetFinancialCompanyAsync(companyDetails.Id);

            _deferredTaxRepository.CreateDeferredTaxBroughtFoward(companyDetails.Id, company.DeferredTaxBroughtFoward, companyFinancialYearList[0].Id);
            _incomeTaxTaxRepository.CreateBalanceBroughtFoward(new BroughtFoward
            {
                UnRelievedCf = company.UnRelievedCf,
                LossCf = company.LossCf,
                CompanyId = companyDetails.Id,
                YearId = companyFinancialYearList[0].Id,
            });

            _notificationRepository.InsertPreNotification(new PreNotification{ CompanyId = companyDetails.Id, OpeningDate = opening, ClosingDate= closing});

            _utilitiesRepository.AddFinancialYearAsync(new FinancialYear { Name = $"{opening.ToString("dddd, dd MMMM yyyy")} - {closing.ToString("dddd, dd MMMM yyyy")}", OpeningDate = opening, ClosingDate = closing, CompanyId = companyDetails.Id});
        }

        public async Task<Company> GetCompanyByTinAsync(string tinNumber)
        {
            return await _companiesRepository.GetCompanyByTinAsync(tinNumber);
        }



    }
}
