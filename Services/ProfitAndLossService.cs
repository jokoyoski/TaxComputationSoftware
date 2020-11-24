﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Services
{
    public class ProfitAndLossService : IProfitAndLossService
    {
        private readonly IProfitAndLossRepository _profitAndLossRepository;
        private readonly ITrialBalanceRepository _trialBalanceRepository;
        private readonly IUtilitiesRepository _utilitiesRepository;

        public ProfitAndLossService(IProfitAndLossRepository profitAndLossRepository, ITrialBalanceRepository trialBalanceRepository)
        {


            _trialBalanceRepository = trialBalanceRepository;
            _profitAndLossRepository = profitAndLossRepository;
        }



        public async Task SaveProfitAndLoss(CreateProfitAndLoss createProfitAndLoss)
        {

            decimal value = 0;

            foreach (var item in createProfitAndLoss.TrialBalanceList)
            {
                value += await GetValue(item);
            }

            foreach (var selection in createProfitAndLoss.TrialBalanceList)
            {
                string trialBalanceValue = "Mapped to Profit and Loss";
                await _trialBalanceRepository.UpdateTrialBalance(selection.TrialBalanceId, trialBalanceValue, false);

            }

            var profitAndLoss = ComputeProfitAndLoss(value, createProfitAndLoss.CompanyId, createProfitAndLoss.YearId, createProfitAndLoss.ProfitAndLossId);

            await _profitAndLossRepository.UpdateProfitAndLoss(profitAndLoss);
        }





        private async Task<decimal> GetValue(TrialBalanceValue trialBalanceValue)
        {
            var value = await _trialBalanceRepository.GetTrialBalanceById(trialBalanceValue.TrialBalanceId);

            if (!trialBalanceValue.IsDebit && !trialBalanceValue.IsBoth && trialBalanceValue.IsCredit)
            {
                return value.Credit;
            }

            if (trialBalanceValue.IsDebit && !trialBalanceValue.IsBoth && !trialBalanceValue.IsCredit)
            {
                return value.Debit;
            }

            if (trialBalanceValue.IsDebit && trialBalanceValue.IsBoth && trialBalanceValue.IsCredit)
            {

                return value.Credit - value.Debit;
            }
            return 0;
        }


        public async Task<List<ProfitAndLossViewDto>> GetProfitAndLossByCompanyIdAndYear(int companyId, int yearId)
        {


            decimal total = 0;
            ProfitAndLossViewDto revenue = new ProfitAndLossViewDto();
            ProfitAndLossViewDto costofsales = new ProfitAndLossViewDto();
            ProfitAndLossViewDto gross = new ProfitAndLossViewDto();
            ProfitAndLossViewDto otheroperatingincome = new ProfitAndLossViewDto();
            ProfitAndLossViewDto otheroperatinggainorloss = new ProfitAndLossViewDto();
            ProfitAndLossViewDto operatingexpenses = new ProfitAndLossViewDto();
            ProfitAndLossViewDto profitorlossbeforetax = new ProfitAndLossViewDto();
            List<ProfitAndLossViewDto> records = new List<ProfitAndLossViewDto>();
            var record = await _profitAndLossRepository.GetProfitAndLossByCompanyIdAndYearId(companyId, yearId);
            if (record == null)
            {
                return records;
            }
            revenue.Category = "Revenue";
            revenue.Total = $"{Utilities.FormatAmount(record.Revenue)}";


            records.Add(revenue);
            costofsales.Category = "Cost Of Sales";
            if (Utilities.GetDecimal(record.CostOfSales) < 0)
            {
                costofsales.Total = $"{Utilities.FormatAmount(record.CostOfSales)}";
            }
            else
            {
                costofsales.Total = $"({Utilities.FormatAmount(record.CostOfSales)})";
            }
            records.Add(costofsales);

            if (Utilities.GetDecimal(record.Revenue) > Utilities.GetDecimal(record.CostOfSales))
            {

                gross.Category = "Gross Profit";
                decimal profit = decimal.Parse(record.Revenue) - decimal.Parse(record.CostOfSales);
                gross.Total = $"({Utilities.FormatAmount(profit)})";
                records.Add(gross);

            }
            else
            {
                gross.Category = "Gross Loss";
                decimal loss = Utilities.GetDecimal(record.Revenue) - Utilities.GetDecimal(record.CostOfSales);
                gross.Total = $"{Utilities.FormatAmount(loss)}";
                records.Add(gross);
            }
            total = Utilities.GetDecimal(record.Revenue) - Utilities.GetDecimal(record.CostOfSales);
            otheroperatingincome.Category = "Other Operating Income";
            otheroperatingincome.Total = $"{Utilities.FormatAmount(record.OtherOperatingIncome)}";
            records.Add(otheroperatingincome);
            total += Utilities.GetDecimal(record.OtherOperatingIncome);


            if (Utilities.GetDecimal(record.OtherOperatingGainOrLoss) < 0)
            {
                otheroperatinggainorloss.Category = "Other Operating Loss";
                otheroperatinggainorloss.Total = $"{Utilities.FormatAmount(record.OtherOperatingGainOrLoss)}";
                total = total - Utilities.GetDecimal(record.OtherOperatingGainOrLoss);
            }
            else
            {
                otheroperatinggainorloss.Category = "Other Operating Gain";
                otheroperatinggainorloss.Total = $"{Utilities.FormatAmount(record.OtherOperatingGainOrLoss)}";
                total = total + Utilities.GetDecimal(record.OtherOperatingGainOrLoss);
            }
            records.Add(otheroperatinggainorloss);
            operatingexpenses.Category = "Operating Expenses";
            operatingexpenses.Total = $"{Utilities.FormatAmount(record.OperatingExpenses)}";
            records.Add(operatingexpenses);
            total = total - Utilities.GetDecimal(record.OperatingExpenses);
            if (total < 0)
            {
                profitorlossbeforetax.Total = $"{Utilities.FormatAmount(total)}";
                profitorlossbeforetax.Category = "Loss Before Taxation";

            }
            else
            {
                profitorlossbeforetax.Total = $"{Utilities.FormatAmount(total)}";
                profitorlossbeforetax.Category = "Gain Before Taxation";

            }
            records.Add(profitorlossbeforetax);
            return records;
        }



        public AddProfitAndLoss ComputeProfitAndLoss(decimal amount, int companyId, int yearId, int profitandlossid)
        {
            if (profitandlossid == 1)
            {
                var profitandLoss = new AddProfitAndLoss
                {

                    Amount = amount,
                    CompanyId = companyId,
                    YearId = yearId,
                    Type = "Revenue"

                };
                return profitandLoss;
            }

            if (profitandlossid == 2)
            {
                var profitandLoss = new AddProfitAndLoss
                {

                    Amount = amount,
                    CompanyId = companyId,
                    YearId = yearId,
                    Type = "CostOfSales"

                };
                return profitandLoss;
            }

            if (profitandlossid == 3)
            {
                var profitandLoss = new AddProfitAndLoss
                {

                    Amount = amount,
                    CompanyId = companyId,
                    YearId = yearId,
                    Type = "OtherOperatingIncome"

                };
                return profitandLoss;
            }

            if (profitandlossid == 4)
            {
                var profitandLoss = new AddProfitAndLoss
                {

                    Amount = amount,
                    CompanyId = companyId,
                    YearId = yearId,
                    Type = "OperatingExpenses"

                };
                return profitandLoss;
            }
            if (profitandlossid == 5)
            {
                var profitandLoss = new AddProfitAndLoss
                {

                    Amount = amount,
                    CompanyId = companyId,
                    YearId = yearId,
                    Type = "OtherOperatingGainOrLoss"

                };
                return profitandLoss;
            }

            return null;
        }

    }
}