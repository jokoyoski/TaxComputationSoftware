﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Repositories
{
    public class UtilitiesRepository : IUtilitiesRepository
    {
        private readonly DataContext _context;
        public UtilitiesRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<Company> GetAssetClassAsync(string Name)
        {
            var asset = await _context.AssetClass.FirstOrDefaultAsync(x => x.Name == Name);
            return asset;
        }
        
        public async Task AddAssetClassAsync(AssetClass assetClass)
        {

            await _context.AssetClass.AddAsync(assetClass);
            await _context.SaveChangesAsync();
        }

        public async Task<Company> GetFinancialYearAsync(string Name)
        {
            var asset = await _context.AssetClass.FirstOrDefaultAsync(x => x.Name == Name);
            return asset;
        }

        public async Task AddFinancialYearAsync(FinancialYear financialYear)
        {

            await _context.FinancialYear.AddAsync(financialYear);
            await _context.SaveChangesAsync();
        }
    }
}
