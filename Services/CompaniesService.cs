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

        public CompaniesService(ICompaniesRepository companiesRepository, IUtilitiesRepository utilitiesRepository, INotificationRepository notificationRepository)
        {
            _companiesRepository = companiesRepository;
            _utilitiesRepository = utilitiesRepository;
            _notificationRepository = notificationRepository;
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

            _utilitiesRepository.AddCompanyCode(new CompanyCode
            {
                Code = Utilities.RandomString(),
                NextExecution = company.ClosingYear,
                CompanyId = companyDetails.Id

            });

            _notificationRepository.InsertPreNotification(new PreNotification{ CompanyId = companyDetails.Id, OpeningDate = companyDetails.OpeningYear });
        }

        public async Task<Company> GetCompanyByTinAsync(string tinNumber)
        {
            return await _companiesRepository.GetCompanyByTinAsync(tinNumber);
        }



    }
}
