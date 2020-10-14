using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Models;

namespace TaxComputationAPI.Interfaces
{
    public interface IUtilitiesService
    {

        Task GetAssetClassAsync(AssetClass assetClass);
        Task AddAssetClassAsync(AssetClass assetClass);
        Task GetFinancialYearAsync(string name);
        Task AddFinancialYearAsync(string name);
    }
}
