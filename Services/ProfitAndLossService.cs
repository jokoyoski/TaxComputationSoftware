using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Dtos;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationAPI.Models;
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
        ///////

        private async Task<ProfitAndLoss> GetProfitAndLoss(int yearId)
        {
            decimal revenueCreditTotal = 0;
            decimal revenueDebitTotal = 0;
            decimal costofSalesCreditTotal = 0;
            decimal costOfSalesDebitTotal = 0;
            decimal otherOperatingIncomeCreditTotal = 0;
            decimal otherOperatingIncomeDebitTotal = 0;
            decimal operatingExpensesCreditTotal = 0;
            decimal operatingExpensesDebitTotal = 0;
            decimal otherOperatingTypeCreditTotal = 0;
            decimal otherOperatingTypeDebitTotal = 0;



            var items = await _profitAndLossRepository.GetProfitsAndLossByType("Revenue");
            if (items.Count > 0)
            {
                foreach (var item in items)
                {

                    var value = await _profitAndLossRepository.GetProfitsAndlossByTrialBalanceId(item.TrialBalanceId, yearId);
                    if (item.Pick == "C")
                    {
                        revenueCreditTotal += value.Value;
                    }
                    else
                    {
                        revenueDebitTotal += value.Value;
                    }


                }
            }


            items = await _profitAndLossRepository.GetProfitsAndLossByType("CostOfSales");
            if (items.Count > 0)
            {
                foreach (var item in items)
                {

                    var value = await _profitAndLossRepository.GetProfitsAndlossByTrialBalanceId(item.TrialBalanceId, yearId);
                    if (item.Pick == "C")
                    {
                        costofSalesCreditTotal += value.Value;
                    }
                    else
                    {
                        costOfSalesDebitTotal += value.Value;
                    }


                }
            }



            items = await _profitAndLossRepository.GetProfitsAndLossByType("OtherOperatingIncome");
            if (items.Count > 0)
            {
                foreach (var item in items)
                {

                    var value = await _profitAndLossRepository.GetProfitsAndlossByTrialBalanceId(item.TrialBalanceId, yearId);
                    if (item.Pick == "C")
                    {
                        otherOperatingIncomeCreditTotal += value.Value;
                    }
                    else
                    {
                        otherOperatingIncomeDebitTotal += value.Value;
                    }


                }

            }

            items = await _profitAndLossRepository.GetProfitsAndLossByType("OperatingExpenses");
            if (items.Count > 0)
            {
                foreach (var item in items)
                {

                    var value = await _profitAndLossRepository.GetProfitsAndlossByTrialBalanceId(item.TrialBalanceId, yearId);
                    if (item.Pick == "C")
                    {
                        operatingExpensesCreditTotal += value.Value;
                    }
                    else
                    {
                        operatingExpensesDebitTotal += value.Value;
                    }


                }
            }


            items = await _profitAndLossRepository.GetProfitsAndLossByType("OtherOperatingType");
            if (items.Count > 0)
            {
                foreach (var item in items)
                {

                    var value = await _profitAndLossRepository.GetProfitsAndlossByTrialBalanceId(item.TrialBalanceId, yearId);
                    if (item.Pick == "C")
                    {
                        otherOperatingTypeCreditTotal += value.Value;
                    }
                    else
                    {
                        otherOperatingTypeDebitTotal += value.Value;
                    }


                }
            }


            var revenueTotal = revenueCreditTotal - revenueDebitTotal;
            var costOfSalesTotal = costOfSalesDebitTotal - costofSalesCreditTotal;
            var otherOperatingIncomeTotal = otherOperatingIncomeCreditTotal - otherOperatingIncomeDebitTotal;
            var operatingexpensesTotal = operatingExpensesDebitTotal - otherOperatingIncomeCreditTotal;
            var otherOperatingTypeTotal = otherOperatingIncomeCreditTotal - otherOperatingIncomeDebitTotal;

            return new ProfitAndLoss
            {
                Revenue = revenueTotal.ToString(),
                CostOfSales = costOfSalesTotal.ToString(),
                OtherOperatingIncome = otherOperatingIncomeTotal.ToString(),
                OperatingExpenses = operatingexpensesTotal.ToString(),
                OtherOperatingGainOrLoss = otherOperatingTypeTotal.ToString(),


            };





        }

        public async Task SaveProfitsAndLoss(CreateProfitAndLoss profits)
        {
            int i = 0;
            int profitAndLossId = profits.ProfitAndLossId;

            foreach (var selection in profits.TrialBalanceList)
            {

                string trialBalanceValue = MappedTo(profitAndLossId, GetSelectedType(selection));
                await _trialBalanceRepository.UpdateTrialBalance(selection.TrialBalanceId, trialBalanceValue, false);
                i++;
            }

            foreach (var selection in profits.TrialBalanceList)
            {

                var value = ConstructProfitAndLoss(selection, profits.ProfitAndLossId, profits.YearId);
                await _profitAndLossRepository.CreateProfitsAndLoss(value);
            }



        }




        private TaxComputationSoftware.Dtos.ProfitsAndLoss ConstructProfitAndLoss(TrialBalanceValue trial, int profitAndLossId, int yearId)
        {
            var value = new TaxComputationSoftware.Dtos.ProfitsAndLoss();
            value.TypeValue = GetType(profitAndLossId);
            value.Year = yearId;
            value.Pick = (GetSelectedType(trial));
            value.TrialBalanceId = trial.TrialBalanceId;
            return value;
        }

        private string GetSelectedType(TrialBalanceValue trial)
        {

            if (trial.IsDebit && !trial.IsCredit && !trial.IsBoth)
            {
                return "D";
            }
            if (!trial.IsDebit && trial.IsCredit && !trial.IsBoth)
            {
                return "C";
            }
            return null;

        }

        ////



        public async Task SaveProfitAndLoss(CreateProfitAndLoss createProfitAndLoss)
        {

            decimal debitValue = 0;
            decimal creditValue = 0;
            decimal totalValue = 0;
            List<string> items = new List<string>();
            int profitAndLossId = createProfitAndLoss.ProfitAndLossId;
            foreach (var item in createProfitAndLoss.TrialBalanceList)
            {
                var value = await GetValue(item);
                if (value.IsDebit)
                {
                    items.Add("Debit");
                    debitValue += value.value;
                }
                else
                {
                    items.Add("Credit");
                    creditValue += value.value;
                }
            }
            int i = 0;
            foreach (var selection in createProfitAndLoss.TrialBalanceList)
            {

                string trialBalanceValue = MappedTo(profitAndLossId, items[i]);
                await _trialBalanceRepository.UpdateTrialBalance(selection.TrialBalanceId, trialBalanceValue, false);
                i++;
            }
            if (createProfitAndLoss.ProfitAndLossId == 1)
            {
                totalValue = creditValue - debitValue;
            }
            else if (createProfitAndLoss.ProfitAndLossId == 2)
            {
                totalValue = debitValue - creditValue;
            }
            else if (createProfitAndLoss.ProfitAndLossId == 3)
            {
                totalValue = creditValue - debitValue;
            }
            else if (createProfitAndLoss.ProfitAndLossId == 4)
            {
                totalValue = debitValue - creditValue;
            }
            else if (createProfitAndLoss.ProfitAndLossId == 5)
            {
                totalValue = creditValue - debitValue;
            }

            var profitAndLoss = ComputeProfitAndLoss(totalValue, createProfitAndLoss.CompanyId, createProfitAndLoss.YearId, createProfitAndLoss.ProfitAndLossId);

            await _profitAndLossRepository.UpdateProfitAndLoss(profitAndLoss);
        }





        private async Task<ProfitAndLossValue> GetValue(TrialBalanceValue trialBalanceValue)
        {
            var profitValue = new ProfitAndLossValue();
            var value = await _trialBalanceRepository.GetTrialBalanceById(trialBalanceValue.TrialBalanceId);

            if (!trialBalanceValue.IsDebit && !trialBalanceValue.IsBoth && trialBalanceValue.IsCredit)
            {
                profitValue.value = value.Credit;
                profitValue.IsDebit = false;
                return profitValue;
            }

            if (trialBalanceValue.IsDebit && !trialBalanceValue.IsBoth && !trialBalanceValue.IsCredit)
            {
                profitValue.value = value.Debit;
                profitValue.IsDebit = true;
                return profitValue;
            }


            return null;
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
            //  var record = await _profitAndLossRepository.GetProfitAndLossByCompanyIdAndYearId(companyId, yearId);
            var record = await GetProfitAndLoss(yearId);
            if (record == null)
            {
                return records;
            }
            revenue.Category = "Revenue";
            revenue.Total = $"₦{Utilities.FormatAmount(record.Revenue)}";


            records.Add(revenue);
            costofsales.Category = "Cost Of Sales";
            if (Utilities.GetDecimal(record.CostOfSales) < 0)
            {
                costofsales.Total = $"₦{Utilities.FormatAmount(record.CostOfSales)}";
            }
            else
            {
                costofsales.Total = $"₦({Utilities.FormatAmount(record.CostOfSales)})";
            }
            records.Add(costofsales);

            if (Utilities.GetDecimal(record.Revenue) > Utilities.GetDecimal(record.CostOfSales))
            {

                gross.Category = "Gross Profit";
                decimal profit = decimal.Parse(record.Revenue) - decimal.Parse(record.CostOfSales);
                gross.Total = $"₦{Utilities.FormatAmount(profit)}";
                records.Add(gross);

            }
            else
            {
                gross.Category = "Gross Loss";
                decimal loss = Utilities.GetDecimal(record.Revenue) - Utilities.GetDecimal(record.CostOfSales);
                gross.Total = $"₦{Utilities.FormatAmount(loss)}";
                records.Add(gross);
            }
            total = Utilities.GetDecimal(record.Revenue) - Utilities.GetDecimal(record.CostOfSales);
            otheroperatingincome.Category = "Other Operating Income";
            otheroperatingincome.Total = $"₦{Utilities.FormatAmount(record.OtherOperatingIncome)}";
            records.Add(otheroperatingincome);
            total += Utilities.GetDecimal(record.OtherOperatingIncome);


            if (Utilities.GetDecimal(record.OtherOperatingGainOrLoss) < 0)
            {
                otheroperatinggainorloss.Category = "Other Operating Loss";
                otheroperatinggainorloss.Total = $"₦{Utilities.FormatAmount(record.OtherOperatingGainOrLoss)}";
                total = total - Utilities.GetDecimal(record.OtherOperatingGainOrLoss);
            }
            else
            {
                otheroperatinggainorloss.Category = "Other Operating Gain";
                otheroperatinggainorloss.Total = $"₦{Utilities.FormatAmount(record.OtherOperatingGainOrLoss)}";
                total = total + Utilities.GetDecimal(record.OtherOperatingGainOrLoss);
            }
            records.Add(otheroperatinggainorloss);
            operatingexpenses.Category = "Operating Expenses";
            operatingexpenses.Total = $"₦{Utilities.FormatAmount(record.OperatingExpenses)}";
            records.Add(operatingexpenses);
            total = total - Utilities.GetDecimal(record.OperatingExpenses);
            if (total < 0)
            {
                profitorlossbeforetax.Total = $"₦{Utilities.FormatAmount(total)}";
                profitorlossbeforetax.Category = "Loss Before Taxation";

            }
            else
            {
                profitorlossbeforetax.Total = $"₦{Utilities.FormatAmount(total)}";
                profitorlossbeforetax.Category = "Profit Before Taxation";

            }
            records.Add(profitorlossbeforetax);
            return records;
        }

        public async Task<MinimumTaxObject> GetMinimumTax(int companyId, int yearId)
        {
            decimal total = 0;
            string revenueValue = "";
            string otherIncomeValue = "";

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
                return null;
            }
            revenue.Category = "Revenue";
            revenue.Total = $"₦{Utilities.FormatAmount(record.Revenue)}";
            revenueValue = record.Revenue;

            records.Add(revenue);
            costofsales.Category = "Cost Of Sales";
            if (Utilities.GetDecimal(record.CostOfSales) < 0)
            {
                costofsales.Total = $"₦{Utilities.FormatAmount(record.CostOfSales)}";
            }
            else
            {
                costofsales.Total = $"₦({Utilities.FormatAmount(record.CostOfSales)})";
            }
            records.Add(costofsales);

            if (Utilities.GetDecimal(record.Revenue) > Utilities.GetDecimal(record.CostOfSales))
            {

                gross.Category = "Gross Profit";
                decimal profit = decimal.Parse(record.Revenue) - decimal.Parse(record.CostOfSales);
                gross.Total = $"₦{Utilities.FormatAmount(profit)}";
                records.Add(gross);

            }
            else
            {
                gross.Category = "Gross Loss";
                decimal loss = Utilities.GetDecimal(record.Revenue) - Utilities.GetDecimal(record.CostOfSales);
                gross.Total = $"₦{Utilities.FormatAmount(loss)}";
                records.Add(gross);
            }
            total = Utilities.GetDecimal(record.Revenue) - Utilities.GetDecimal(record.CostOfSales);
            otheroperatingincome.Category = "Other Operating Income";
            otheroperatingincome.Total = $"₦{Utilities.FormatAmount(record.OtherOperatingIncome)}";
            otherIncomeValue = record.OtherOperatingIncome;
            records.Add(otheroperatingincome);
            total += Utilities.GetDecimal(record.OtherOperatingIncome);

            return new MinimumTaxObject
            {
                Revenue = revenueValue,
                OtherIncome = otherIncomeValue,
            };
        }


        public async Task<string> GetITLevy(int companyId, int yearId)
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
                return null;
            }
            revenue.Category = "Revenue";
            revenue.Total = $"₦{Utilities.FormatAmount(record.Revenue)}";


            records.Add(revenue);
            costofsales.Category = "Cost Of Sales";
            if (Utilities.GetDecimal(record.CostOfSales) < 0)
            {
                costofsales.Total = $"₦{Utilities.FormatAmount(record.CostOfSales)}";
            }
            else
            {
                costofsales.Total = $"₦({Utilities.FormatAmount(record.CostOfSales)})";
            }
            records.Add(costofsales);

            if (Utilities.GetDecimal(record.Revenue) > Utilities.GetDecimal(record.CostOfSales))
            {

                gross.Category = "Gross Profit";
                decimal profit = decimal.Parse(record.Revenue) - decimal.Parse(record.CostOfSales);
                gross.Total = $"₦{Utilities.FormatAmount(profit)}";
                records.Add(gross);

            }
            else
            {
                gross.Category = "Gross Loss";
                decimal loss = Utilities.GetDecimal(record.Revenue) - Utilities.GetDecimal(record.CostOfSales);
                gross.Total = $"₦{Utilities.FormatAmount(loss)}";
                records.Add(gross);
            }
            total = Utilities.GetDecimal(record.Revenue) - Utilities.GetDecimal(record.CostOfSales);
            otheroperatingincome.Category = "Other Operating Income";
            otheroperatingincome.Total = $"₦{Utilities.FormatAmount(record.OtherOperatingIncome)}";
            records.Add(otheroperatingincome);
            total += Utilities.GetDecimal(record.OtherOperatingIncome);


            if (Utilities.GetDecimal(record.OtherOperatingGainOrLoss) < 0)
            {
                otheroperatinggainorloss.Category = "Other Operating Loss";
                otheroperatinggainorloss.Total = $"₦{Utilities.FormatAmount(record.OtherOperatingGainOrLoss)}";
                total = total - Utilities.GetDecimal(record.OtherOperatingGainOrLoss);
            }
            else
            {
                otheroperatinggainorloss.Category = "Other Operating Gain";
                otheroperatinggainorloss.Total = $"₦{Utilities.FormatAmount(record.OtherOperatingGainOrLoss)}";
                total = total + Utilities.GetDecimal(record.OtherOperatingGainOrLoss);
            }
            records.Add(otheroperatinggainorloss);
            operatingexpenses.Category = "Operating Expenses";
            operatingexpenses.Total = $"₦{Utilities.FormatAmount(record.OperatingExpenses)}";
            records.Add(operatingexpenses);
            total = total - Utilities.GetDecimal(record.OperatingExpenses);
            if (total < 0)
            {
                profitorlossbeforetax.Total = $"₦{Utilities.FormatAmount(total)}";
                profitorlossbeforetax.Category = "Loss Before Taxation";

            }
            else
            {


                profitorlossbeforetax.Total = $"₦{Utilities.FormatAmount(total)}";
                profitorlossbeforetax.Category = "Profit Before Taxation";
                return total.ToString();

            }
            return null;
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


        private string MappedTo(int profitAndLossId, string item)
        {

            if (profitAndLossId == 1)
            {
                return $"Mapped To [Profit and Loss] (Revenue) {item}";
            }

            if (profitAndLossId == 2)
            {
                return $"Mapped To [Profit and Loss] (Cost Of Sales) {item}";
            }

            if (profitAndLossId == 3)
            {
                return $"Mapped To [Profit and Loss] (Other Operating Income) {item}";
            }


            if (profitAndLossId == 4)
            {
                return $"Mapped To [Profit and Loss] (Operating Expenses) {item}";
            }


            if (profitAndLossId == 5)
            {
                return $"Mapped To [Profit and Loss] (Other Operating Type) {item}";
            }


            return null;

        }



        private string GetType(int profitAndLossId)
        {

            if (profitAndLossId == 1)
            {
                return "Revenue";
            }

            if (profitAndLossId == 2)
            {
                return "CostOfSales";
            }

            if (profitAndLossId == 3)
            {
                return "OtherOperatingIncome";
            }

            if (profitAndLossId == 4)
            {
                return "OperatingExpenses";
            }

            if (profitAndLossId == 4)
            {
                return "OtherOperatingType";
            }

            return null;
        }



    }
}
