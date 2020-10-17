using System.Threading.Tasks;
using TaxComputationAPI.Data;
using TaxComputationAPI.Interfaces;
using System.Linq;
using TaxComputationAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaxComputationAPI.Repositories
{
    public class TrialBalanceRepository : ITrialBalanceRepository
    {
        private readonly DataContext _dataContext;
        
        public TrialBalanceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task UpdateTrialBalance(int trialBalanceId, string mappedTo)
        {
            var record = _dataContext.TrialBalance.FirstOrDefault(x => x.Id == trialBalanceId);
            if (record != null)
            {
                record.IsCheck = true;
                record.MappedTo = mappedTo;
                _dataContext.SaveChanges();

            }
        }

        public async Task<TrackTrialBalance> GetTrackTrialBalance(int companyId, int yearId)
        {
            var response = _dataContext.TrackTrialBalance.Where(p => p.CompanyId == companyId && p.YearId == yearId).ToList().LastOrDefault();
            return response;
        }

        public async Task<List<TrialBalance>> GetTrialBalance(int trackId)
        {
            var response = _dataContext.TrialBalance.Where(predicate => predicate.TrackId == trackId).ToList();
            return response;
        }

        public async Task<TrackTrialBalance> AddTrackTrialBalance(TrackTrialBalance model)
        {
            var response = _dataContext.TrackTrialBalance.Add(model);
            _dataContext.SaveChanges();

            return response.Entity;
        }

        public async Task<TrialBalance> UploadTrialBalance(TrialBalance model)
        {
            var response = _dataContext.TrialBalance.Add(model);
            _dataContext.SaveChanges();

            return response.Entity;
        }

    }
}
