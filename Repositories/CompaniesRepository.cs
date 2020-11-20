using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly DataContext _context;
        public CompaniesRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            var company = await _context.Company.FirstOrDefaultAsync(x => x.Id == id);
            return company;
        }

        public async Task<Company> GetCompanyByTinAsync(string tinNumber)
        {
            var company = await _context.Company.FirstOrDefaultAsync(x => x.TinNumber == tinNumber);
            return company;
        }

      
        public async Task AddCompanyAsync(Company company) {

            await _context.Company.AddAsync(company);
            await _context.SaveChangesAsync();
        }
        public async Task<PagedList<Company>> GetCompaniesAsync(PaginationParams pagination)
        {
            var companies = _context.Company.AsQueryable();
            return await PagedList<Company>.CreateAsync(companies, pagination.PageNumber, pagination.PageSIze);
        }
    }
}
