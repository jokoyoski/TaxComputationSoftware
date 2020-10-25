using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Helpers.Response;
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

     


        public Task<List<FinancialYear>> GetFinancialYearAsync()
        {
            var year = _context.FinancialYear.ToListAsync();
            return year;
        }

        public async Task AddFinancialYearAsync(FinancialYear financialYear)
        {

            await _context.FinancialYear.AddAsync(financialYear);
            await _context.SaveChangesAsync();
        }



        public async Task<FinancialYear> GetFinancialYearAsync(int year)
        {
            var financialYear = _context.FinancialYear.FirstOrDefault(x => x.Name == year);
            return financialYear;
        }

        public async Task<List<AssetMapping>> GetAssetMappingAsync()
        {
            var mapping = _context.AssetMapping.ToList();
            return mapping;
        }

        public async Task<AssetMapping> GetAssetMappingAsync(string Name)
        {
            var assetMapping = _context.AssetMapping.FirstOrDefault(x => x.AssetName == Name);
            return assetMapping;
        }

        public async Task<AssetMapping> GetAssetMappingById(int Id)
        {
            var assetMapping = _context.AssetMapping.FirstOrDefault(x => x.Id == Id);
            return assetMapping;
        }

        public async Task AddAssetMappingAsync(AssetMapping assetMapping)
        {

            await _context.AssetMapping.AddAsync(assetMapping);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssetMappingAsync(AssetMapping assetMapping)
        {
            var result = _context.AssetMapping.FirstOrDefault(x => x.Id == assetMapping.Id);
            result.Annual = assetMapping.Annual;
            result.AssetName = assetMapping.AssetName;
            result.Initial = assetMapping.Initial;
            _context.SaveChanges();
        }

        public async Task DeleteAssetMappingAsync(AssetMapping assetMapping)
        {
            var result = _context.AssetMapping.FirstOrDefault(x => x.Id == assetMapping.Id);
            _context.Remove(result);
            _context.SaveChanges();
        }

      

       

       

      

       


       

        public decimal GetAmount(int moduleId, string additionalInfo)
        {

            decimal finalAmount = 0;
            var result = (from s in _context.TrialBalanceMapping
                          join b in _context.TrialBalance on s.TrialBalanceId equals b.Id
                          where s.ModuleId == moduleId && s.AdditionalInfo == additionalInfo
                          select new Amount
                          {
                              amount = b.Debit
                          }
            ).OrderBy(x => x.amount).ToList();
            foreach (var item in result)
            {
                finalAmount += item.amount;
            }

            return finalAmount;
        }

        public void AddTrialBalanceMapping(int trialBalanceId, int moduleId, string moduleCode, string additionalInfo)
        {
            var trialBalanceMapping = new TrialBalanceMapping
            {
                ModuleCode = moduleCode,
                AdditionalInfo = additionalInfo,
                ModuleId = moduleId,
                TrialBalanceId = trialBalanceId
            };
            _context.TrialBalanceMapping.Add(trialBalanceMapping);
             _context.SaveChanges();
        }

        public void DeleteTrialBalancingMapping(int trialBalanceId)
        {
            var item = _context.TrialBalanceMapping.FirstOrDefault(x => x.TrialBalanceId == trialBalanceId);
            _context.Remove(item);
             _context.SaveChanges();
        }
    }
}
