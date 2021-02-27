using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface ICompaniesService
    {
        Task<Company> GetCompanyAsync(int id);

         Task<Company> GetCompanyByTinAsync(string companyTin);

        Task AddCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task<PagedList<Company>> GetCompaniesAsync(PaginationParams pagination);

        Task<object> GetCompanyInfoByFinancialYear(int companyId, int financialYearId);
        Task DeleteCompany(int Id);
    
    }
}
