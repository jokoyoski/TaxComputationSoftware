using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
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

       
       
      
       

        
       

        public async Task<List<ModuleTypeDto>> GetModuleMappingbyCode(string code)
        {
            List<ModuleTypeDto> moduleTypes= new List<ModuleTypeDto>();
            if(code=="fixedasset"){
               var values =await _utilitiesRepository.GetAssetMappingAsync();
               foreach(var item in values){
                moduleTypes.Add(new ModuleTypeDto{
                    Id=item.Id,
                    Name=item.AssetName
                });
               }
            }

            return moduleTypes;
        }
    }
}
