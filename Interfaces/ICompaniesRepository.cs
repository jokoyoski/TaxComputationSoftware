﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface ICompaniesRepository
    {
        Task<Company> GetCompanyAsync(int id);
        Task<Company> GetCompanyByTinAsync(string tinNumber);
        Task<PagedList<Company>> GetCompaniesAsync(PaginationParams pagination);
        Task AddCompanyAsync(Company company);
       Task UpdateCompanyDate(Company company);

        Task UpdateCompany(Company company);

        Task<object> GetCompanyInfoByFinancialYear(int companyId, int financialYearId);

        Task DeleteCompany(int Id);
    
    }
}
