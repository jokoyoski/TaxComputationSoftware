using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<List<AssetClass>> GetAssetClassAsync()
        {
            var asset = _context.AssetClass.ToList();
            return asset;
        }

        public async Task AddAssetClassAsync(AssetClass assetClass)
        {

            await _context.AssetClass.AddAsync(assetClass);
            await _context.SaveChangesAsync();
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

        public async Task<AssetClass> GetAssetClassAsync(string Name)
        {
            var assetClass = _context.AssetClass.FirstOrDefault(x => x.Name == Name);
            return assetClass;
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
            var result= _context.AssetMapping.FirstOrDefault(x=>x.Id==assetMapping.Id);
            result.Annual=assetMapping.Annual;
            result.AssetName=assetMapping.AssetName;
            result.Initial=assetMapping.Initial;
             _context.SaveChanges();
        }

        public async Task DeleteAssetMappingAsync(AssetMapping assetMapping)
        {
            var result = _context.AssetMapping.FirstOrDefault(x => x.Id == assetMapping.Id);
            _context.Remove(result);
            _context.SaveChanges();
        }

        public async Task<List<ItemsMapping>> GetItemsMappingAsync()
        {
            var mapping = _context.ItemsMapping.ToList();
            return mapping;
        }

        public async Task<ItemsMapping> GetItemsMappingByMappedCode(string MappedCode)
        {
            var itemsMapping = _context.ItemsMapping.FirstOrDefault(x => x.MappedCode == MappedCode);
            return itemsMapping;
        }

        public async Task<ItemsMapping> GetItemsMappingById(int Id)
        {
            var itemsMapping = _context.ItemsMapping.FirstOrDefault(x => x.Id == Id);
            return itemsMapping;
        }

        public async Task AddItemsMappingAsync(ItemsMapping itemsMapping)
        {

            await _context.ItemsMapping.AddAsync(itemsMapping);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemsMappingAsync(ItemsMapping itemsMapping)
        {
            var result = _context.ItemsMapping.FirstOrDefault(x => x.Id == itemsMapping.Id);
            result.MappedCode = itemsMapping.MappedCode;
            result.ItemValue = itemsMapping.ItemValue;
            _context.SaveChanges();
        }

        public async Task DeleteItemsMappingAsync(ItemsMapping itemMapping)
        {
            var result = _context.ItemsMapping.FirstOrDefault(x => x.Id == itemMapping.Id);
            _context.Remove(result);
            _context.SaveChanges();
        }
    }
}
