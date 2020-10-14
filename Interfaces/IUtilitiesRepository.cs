using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUtilitiesRepository
    {
        Task<AssetClass> GetAssetClassAsync(string name);
        Task AddAssetClassAsync(AssetClass assetClass);
        Task<FinancialYear> GetFinancialYearAsync(string name);
        Task AddFinancialYearAsync(FinancialYear financialClass);
    }
}
