using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationSoftware.Services
{
    public class AnnualService : IAnnualService
    {
        private readonly IUtilitiesService _utilityService;
        private readonly ICapitalAllowanceService _capitalAllowanceService;
        public AnnualService(IUtilitiesService utilityService, ICapitalAllowanceService capitalAllowanceService)
        {
            _utilityService = utilityService;
            _capitalAllowanceService = capitalAllowanceService;
        }

        public async Task UnlockCapitalAllowance(int companyId)
        {
            var assetClasses = await _utilityService.GetAssetMappingAsync();
            foreach (var item in assetClasses)
            {
                var values = await _capitalAllowanceService.GetCapitalAllowance(item.Id, companyId);

                foreach(var value in values.capitalAllowances){
                  
                  _capitalAllowanceService.UpdateCapitalAllowanceForChannel(value.Channel,value.Id);
                  _capitalAllowanceService.UpdateArchivedCapitalAllowanceForChannel(value.Channel,value.CompanyId,value.TaxYear,item.Id);
                }

            }
        }

    }
}