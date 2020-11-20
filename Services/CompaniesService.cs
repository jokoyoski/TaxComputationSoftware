using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;
        public CompaniesService(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;

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
            if (company==null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            
            
            await _companiesRepository.AddCompanyAsync(company);
        }

        public async Task<Company> GetCompanyByTinAsync(string tinNumber)
        {
            return await  _companiesRepository.GetCompanyByTinAsync(tinNumber);
        }



    }
}
