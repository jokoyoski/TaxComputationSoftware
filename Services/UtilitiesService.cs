using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Repositories;

namespace TaxComputationAPI.Services
{
    public class UtilitiesService : IUtilitiesService
    {
        private readonly IUtilitiesRepository _utilitiesRepository;
        private readonly ITrialBalanceRepository _trialBalanceRepository;

        private readonly IFixedAssetService _fixedAssetService;
        private readonly IProfitAndLossRepository _profitAndLossRepository;
        public UtilitiesService( ITrialBalanceRepository trialBalanceRepository,IUtilitiesRepository utilitiesRepository ,IFixedAssetService fixedAssetService, IProfitAndLossRepository profitAndLossRepository)
        {
            _utilitiesRepository = utilitiesRepository;
            _trialBalanceRepository = trialBalanceRepository;
            _fixedAssetService = fixedAssetService;
            _profitAndLossRepository = profitAndLossRepository;
           
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
            return await _utilitiesRepository.GetFinancialYearAsync(Name);
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

        public async Task DeleteAssetMappingAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            await _utilitiesRepository.DeleteAssetMappingAsync(id);
        }



        public async Task UnmapValue(int trialBalanceId)
        {
            var value = await _trialBalanceRepository.GetTrialBalanceById(trialBalanceId);

            var module = Utilities.AreaMapped(value.MappedTo);

            if (module == "FIXED ASSET")
            {
                await _trialBalanceRepository.UpdateTrialBalance(trialBalanceId, null, true);  //fice
                await _utilitiesRepository.DeleteTrialBalancingMapping(trialBalanceId);
            }
            else if (module == "Profit and Loss")
            {
                _profitAndLossRepository.DeleteProfitsAndLossById(trialBalanceId);
                await _trialBalanceRepository.UpdateTrialBalance(trialBalanceId, null, true);  //fice
            }
            else if (module == "INCOME TAX")
            {
                var itemToDelete = await _utilitiesRepository.GetAllowableDisAllowableByTrialBalanceId(trialBalanceId);

                _utilitiesRepository.DeleteAllowableDisAllowableById(itemToDelete.Id);

                await _trialBalanceRepository.UpdateTrialBalance(itemToDelete.TrialBalanceId, null, true);  //fice
            }
             else if (module == "DEFERRED TAX")
            {
    
                _utilitiesRepository.DeleteFairGainByTrialBalanceId(trialBalanceId);

                await _trialBalanceRepository.UpdateTrialBalance(trialBalanceId, null, true);  //fice
            }


        }





        public async Task<List<ModuleTypeDto>> GetModuleMappingbyCode(string code)
        {
            List<ModuleTypeDto> moduleTypes = new List<ModuleTypeDto>();
            if (code == "fixedasset")
            {
                var values = await _utilitiesRepository.GetAssetMappingAsync();
                foreach (var item in values)
                {
                    moduleTypes.Add(new ModuleTypeDto
                    {
                        Id = item.Id,
                        Name = item.AssetName
                    });
                }
            }
            else if (code == "profitandloss")
            {
                moduleTypes.Add(new ModuleTypeDto
                {
                    Id = 1,
                    Name = "Revenue"
                });

                moduleTypes.Add(new ModuleTypeDto
                {
                    Id = 2,
                    Name = "Cost Of Sales"
                });

                moduleTypes.Add(new ModuleTypeDto
                {
                    Id = 3,
                    Name = "Other Operating Income"
                });

                moduleTypes.Add(new ModuleTypeDto
                {
                    Id = 4,
                    Name = "Operating Expenses"
                });

                moduleTypes.Add(new ModuleTypeDto
                {
                    Id = 5,
                    Name = "Other Operating Type"
                });
            }

            return moduleTypes;
        }
    }
}
