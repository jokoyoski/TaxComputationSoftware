using TaxComputationAPI.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaxComputationAPI.Models;
using TaxComputationAPI.Interfaces;

namespace TaxComputationAPI.Repositories
{
    public class BalancingAdjustmentRepository : IBalancingAdjustmentRepository
    {
        private readonly DataContext _context;

        public BalancingAdjustmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BalancingAdjustment>> GetBalancingAdjustment(int companyId, string year)
        {
            if(companyId <= 0) throw new ArgumentNullException(nameof(companyId));

            if(string.IsNullOrEmpty(year)) throw new ArgumentNullException(nameof(year));

            try
            {
                return await _context.BalancingAdjustment.Where(p => p.ComapnyId == companyId && p.Year == year).ToListAsync();
            }
            catch(Exception e)
            {
                throw new SystemException(e.Message);
            }

            
        }

        public async Task<List<BalancingAdjustmentYearBought>> GetBalancingAdjustmentYeatBought(int balancingAdjustmentId, int asssetId)
        {
            if(balancingAdjustmentId <= 0) throw new ArgumentNullException(nameof(balancingAdjustmentId));

            if(asssetId <= 0) throw new ArgumentNullException(nameof(asssetId));

            try
            {
                return await _context.BalancingAdjustmentYearBought.Where(p => p.AssestId == asssetId && p.BalancingAdjustmentId == balancingAdjustmentId).ToListAsync();
            }
            catch(Exception e)
            {
                throw new SystemException(e.Message);
            }
        }

        public async Task<BalancingAdjustment> SaveBalancingAdjustment(BalancingAdjustment balancingAdjustment)
        {
            if(balancingAdjustment == null) throw new ArgumentNullException(nameof(balancingAdjustment));

            try 
            {
                var result = _context.BalancingAdjustment.Add(balancingAdjustment);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {
                throw new SystemException(e.Message);
            }         
        }

        public async Task<BalancingAdjustmentYearBought> SaveBalancingAdjustmentYeatBought(BalancingAdjustmentYearBought balancingAdjustmentYearBought)
        {
            if(balancingAdjustmentYearBought == null) throw new ArgumentNullException(nameof(balancingAdjustmentYearBought));

            try
            {
                var result = _context.BalancingAdjustmentYearBought.Add(balancingAdjustmentYearBought);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {
                throw new SystemException(e.Message);
            }
        }
    }
}