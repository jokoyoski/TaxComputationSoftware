using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Manager;

namespace TaxComputationAPI.Repositories
{
    public class ProfitAndLossRepository : IProfitAndLossRepository
    {
        private readonly DatabaseManager _databaseManager;
        public ProfitAndLossRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }
    }
}
