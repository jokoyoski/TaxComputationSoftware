using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Services
{
    public class ProfitAndLossService : IProfitAndLossService
    {
        private readonly IProfitAndLossRepository _profitAndLossRepository;
    }
}
