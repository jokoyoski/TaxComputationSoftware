using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Services
{
    public class UtilitiesService : IUtilitiesService
    {
        private readonly IUtilitiesRepository _utilitiesRepository;
        public UtilitiesService(IUtilitiesRepository utilitiesRepository)
        {
            _utilitiesRepository = utilitiesRepository;

        }

        

        public  Task<List<AssetClass>> GetAssetClassAsync()
        {
            return  _utilitiesRepository.GetAssetClassAsync();
        }

        public async Task AddAssetClassAsync(AssetClass assetClass)
        {
            if (assetClass == null)
            {
                throw new ArgumentNullException(nameof(assetClass));
            }


            await _utilitiesRepository.AddAssetClassAsync(assetClass);
        }

        public async Task<List<FinancialYear>> GetFinancialYearAsync()
        {
            return await _utilitiesRepository.GetFinancialYearAsync();
        }

        public async Task AddFinancialYearAsync(FinancialYear financialYear)
        {
            if (financialYear == null)
            {
                throw new ArgumentNullException(nameof(financialYear));
            }


            await _utilitiesRepository.AddFinancialYearAsync(financialYear);
        }

        public async Task<AssetClass> GetAssetClassAsync(string Name)
        {
            return  await _utilitiesRepository.GetAssetClassAsync(Name);
        }

        public async Task<FinancialYear> GetFinancialYearAsync(int Name)
        {
            return  await _utilitiesRepository.GetFinancialYearAsync(Name);
        }
        public Task<List<AssetMapping>> GetAssetMappingAsync()
        {
            return _utilitiesRepository.GetAssetMappingAsync();
        }
        public async Task<AssetMapping> GetAssetMappingById(int Id)
        {
            return await _utilitiesRepository.GetAssetMappingById(Id);
        }
        public async Task<AssetMapping> GetAssetMappingAsync(string Name)
        {
            return await _utilitiesRepository.GetAssetMappingAsync(Name);
        }
        public async Task AddAssetMappingAsync(AssetMapping assetMapping)
        {
            if (assetMapping == null)
            {
                throw new ArgumentNullException(nameof(assetMapping));
            }

            await _utilitiesRepository.AddAssetMappingAsync(assetMapping);
        }

        public async Task UpdateAssetMappingAsync(AssetMapping assetMapping)
        {
            if (assetMapping == null)
            {
                throw new ArgumentNullException(nameof(assetMapping));
            }

            await _utilitiesRepository.UpdateAssetMappingAsync(assetMapping);
        }

        public async Task DeleteAssetMappingAsync(AssetMapping assetMapping)
        {
            if (assetMapping == null)
            {
                throw new ArgumentNullException(nameof(assetMapping));
            }

            await _utilitiesRepository.DeleteAssetMappingAsync(assetMapping);
        }

        public Task<List<ItemsMapping>> GetItemsMappingAsync()
        {
            return _utilitiesRepository.GetItemsMappingAsync();
        }
        public async Task<ItemsMapping> GetItemsMappingById(int Id)
        {
            return await _utilitiesRepository.GetItemsMappingById(Id);
        }
        public async Task<ItemsMapping> GetItemsMappingByMappedCode(string MappedCode)
        {
            return await _utilitiesRepository.GetItemsMappingByMappedCode(MappedCode);
        }
        public async Task AddItemsMappingAsync(ItemsMapping itemsMapping)
        {
            if (itemsMapping == null)
            {
                throw new ArgumentNullException(nameof(itemsMapping));
            }

            await _utilitiesRepository.AddItemsMappingAsync(itemsMapping);
        }

        public async Task UpdateItemsMappingAsync(ItemsMapping itemsMapping)
        {
            if (itemsMapping == null)
            {
                throw new ArgumentNullException(nameof(itemsMapping));
            }

            await _utilitiesRepository.UpdateItemsMappingAsync(itemsMapping);
        }

        public async Task DeleteItemsMappingAsync(ItemsMapping itemsMapping)
        {
            if (itemsMapping == null)
            {
                throw new ArgumentNullException(nameof(itemsMapping));
            }

            await _utilitiesRepository.DeleteItemsMappingAsync(itemsMapping);
        }
    }
}
