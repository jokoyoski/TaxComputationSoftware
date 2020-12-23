using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxComputationAPI.Helpers;
using TaxComputationAPI.Interfaces;
using TaxComputationSoftware.Dtos;
using TaxComputationSoftware.Interfaces;
using TaxComputationSoftware.Models;

namespace TaxComputationSoftware.Services
{
    public class IncomeTaxService : IIncomeTaxService
    {
        private readonly IIncomeTaxRepository _incomeTaxRepository;
        private readonly IProfitAndLossService _profitAndLossService;

        private readonly ITrialBalanceRepository _trialBalanceRepository;

        public IncomeTaxService(IIncomeTaxRepository incomeTaxRepository, IProfitAndLossService profitAndLossService, ITrialBalanceRepository trialBalanceRepository)
        {
            _incomeTaxRepository = incomeTaxRepository;
            _profitAndLossService = profitAndLossService;
            _trialBalanceRepository = trialBalanceRepository;

        }



     /*   public async Task<List<IncomeTaxDto>> GetIncomeTax(int companyId, int yearId)
        {
            decimal totalAllowable = 0;
            decimal totalDisallowable = 0;
            decimal profitAndLossPerAccount = 0;
            var incomeListDto = new List<IncomeTaxDto>();


            var profitOrLoss = await _profitAndLossService.GetProfitAndLossForIncomeTax(companyId, yearId);
            profitAndLossPerAccount = profitOrLoss;
            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Profits/Loss per accounts",
                ColumnOne = "",
                ColumnTwo = $"₦{Utilities.FormatAmount(profitOrLoss)}"
            });

            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "",
                ColumnOne = "",
                ColumnTwo = ""
            });


            incomeListDto.Add(new IncomeTaxDto
            {
                Description = "Add: Disallowable Expenses",
                ColumnOne = "",
                ColumnTwo = ""
            });

            var allowableDisAllowable = await _incomeTaxRepository.GetAllowableDisAllowableByCompanyIdYearIdAllowable(companyId, yearId, 0);
            int i = 0;
            foreach (var item in allowableDisAllowable)
            {
                i++;

                if (i == allowableDisAllowable.ToList().Count())
                {
                    if (item.SelectionId == 0)
                    {
                        totalDisallowable += item.Debit;
                        incomeListDto.Add(new IncomeTaxDto
                        {
                            Description = item.Item,
                            ColumnOne = $"₦{Utilities.FormatAmount(item.Debit)}",
                            ColumnTwo = $"₦{Utilities.FormatAmount(totalDisallowable)}",
                        });
                    }
                    else if (item.SelectionId == 1)
                    {
                        totalDisallowable += item.Credit;
                        incomeListDto.Add(new IncomeTaxDto
                        {
                            Description = item.Item,
                            ColumnOne = $"₦{Utilities.FormatAmount(item.Credit)}",
                            ColumnTwo = $"₦{Utilities.FormatAmount(totalDisallowable)}",
                        });
                    }
                }
                else
                {
                    if (item.SelectionId == 0)
                    {
                        totalDisallowable += item.Debit;
                        incomeListDto.Add(new IncomeTaxDto
                        {
                            Description = item.Item,
                            ColumnOne = "",
                            ColumnTwo = $"₦{Utilities.FormatAmount(item.Debit)}"
                        });
                    }
                    else if (item.SelectionId == 1)
                    {
                        totalDisallowable += item.Credit;
                        incomeListDto.Add(new IncomeTaxDto
                        {
                            Description = item.Item,
                            ColumnOne = "",
                            ColumnTwo = $"₦{Utilities.FormatAmount(item.Debit)}"
                        });
                    }
                }


                incomeListDto.Add(new IncomeTaxDto
                {
                    Description = "Allowable Income",
                    ColumnOne = "",
                    ColumnTwo = ""
                });


                foreach (var allowable in allowableDisAllowable)
                {
                    i++;

                    if (i == allowableDisAllowable.ToList().Count())
                    {
                        if (item.SelectionId == 1)
                        {
                            if (item.Debit >= 0)
                            {
                                totalAllowable += -item.Debit;
                            }else{
                                totalAllowable += item.Debit;
                            }

                            if (item.Debit >= 0)
                            {
                                incomeListDto.Add(new IncomeTaxDto
                                {
                                    Description = item.Item,
                                    ColumnOne = $"₦({Utilities.FormatAmount(item.Debit)})",
                                    ColumnTwo = $"₦({Utilities.FormatAmount(totalAllowable)})",
                                });

                            }
                            else
                            {
                                incomeListDto.Add(new IncomeTaxDto
                                {
                                    Description = item.Item,
                                    ColumnOne = $"₦{Utilities.FormatAmount(item.Debit)}",
                                    ColumnTwo = $"₦{Utilities.FormatAmount(totalAllowable)}",
                                });
                            }


                        }
                        else if (item.SelectionId == 1)
                        {

                            if (item.Credit >= 0)
                            {
                                totalAllowable += item.Credit;
                                incomeListDto.Add(new IncomeTaxDto
                                {
                                    Description = item.Item,
                                    ColumnOne = $"₦({Utilities.FormatAmount(item.Credit)})",
                                    ColumnTwo = $"₦({Utilities.FormatAmount(totalAllowable)})",
                                });
                            }
                            else
                            {
                                totalAllowable += item.Credit;
                                incomeListDto.Add(new IncomeTaxDto
                                {
                                    Description = item.Item,
                                    ColumnOne = $"₦{Utilities.FormatAmount(item.Credit)}",
                                    ColumnTwo = $"₦{Utilities.FormatAmount(totalAllowable)}",
                                });
                            }

                        }
                    }
                    else
                    {
                        if (item.SelectionId == 0)
                        {
                            if (item.Debit >= 0)
                            {
                                totalAllowable += -item.Debit;
                            }else{
                                totalAllowable += item.Debit;
                            }

                            incomeListDto.Add(new IncomeTaxDto
                            {
                                Description = item.Item,
                                ColumnOne = "",
                                ColumnTwo = $"₦{Utilities.FormatAmount(item.Debit)}"
                            });
                        }
                        else if (item.SelectionId == 1)
                        {

                             if (item.Debit >= 0)
                            {
                                totalAllowable += -item.Debit;
                            }else{
                                totalAllowable += item.Debit;
                            }

                            totalAllowable += item.Credit;
                            incomeListDto.Add(new IncomeTaxDto
                            {
                                Description = item.Item,
                                ColumnOne = "",
                                ColumnTwo = $"₦{Utilities.FormatAmount(item.Debit)}"
                            });
                        }
                    }






                }







            }


        }*/

        public async Task SaveAllowableDisAllowable(CreateIncomeTaxDto incomeTax)
        {

            foreach (var item in incomeTax.IncomeList)
            {
                var allowableDisAllowable = new AllowableDisAllowable();
                allowableDisAllowable.SelectionId = GetSelectionType(item);
                allowableDisAllowable.YearId = incomeTax.YearId;
                allowableDisAllowable.TrialBalanceId = item.TrialBalanceId;
                allowableDisAllowable.CompanyId = incomeTax.CompanyId;
                if (incomeTax.TypeId == 1)
                {
                    allowableDisAllowable.IsAllowable = true;
                }
                else
                {
                    allowableDisAllowable.IsAllowable = false;
                }
                if (incomeTax.TypeId == 1)
                {
                    string trialBalanceValue = $"MAPPED TO [INCOME TAX] Allowable Income";
                    await _trialBalanceRepository.UpdateTrialBalance(item.TrialBalanceId, trialBalanceValue, false);
                }
                else
                {
                    string trialBalanceValue = $"MAPPED TO [INCOME TAX] DisAllowable Income";
                    await _trialBalanceRepository.UpdateTrialBalance(item.TrialBalanceId, trialBalanceValue, false);
                }
                await _incomeTaxRepository.CreateAllowableDisAllowable(allowableDisAllowable);

            }

         /*   _incomeTaxRepository.CreateBalanceBroughtFoward(new BroughtFoward
            {
                IsStarted = false,
                LossBf = incomeTax.LossBroughtFoward,
                UnRelievedBf = incomeTax.UnrelievedCapitalAllowanceBroughtFoward
            });*/


        }



        public async Task DeleteAllowableDisAllowable(int allowableDisAllowableId)
        {

            var itemToDelete = await _incomeTaxRepository.GetAllowableDisAllowableById(allowableDisAllowableId);

            _incomeTaxRepository.DeleteAllowableDisAllowableById(allowableDisAllowableId);

            await _trialBalanceRepository.UpdateTrialBalance(itemToDelete.TrialBalanceId, null, true);  //fice

        }



        public async Task<BroughtFoward> GetBroughtFoward(int companyId)
        {

            return await _incomeTaxRepository.GetBroughtFowardByCompanyId(companyId);

        }






        public int GetSelectionType(IncomeListDto incomeTax)
        {


            if (!incomeTax.IsDebit && !incomeTax.IsBoth && incomeTax.IsCredit)
            {
                return 1;
            }

            if (incomeTax.IsDebit && !incomeTax.IsBoth && !incomeTax.IsCredit)
            {
                return 0;
            }

            return 0;

        }

    }
}