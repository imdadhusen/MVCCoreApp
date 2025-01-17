using AutoMapper;
using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Helper;
using HisabPro.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HisabPro.Services.Implements
{
    public class DashboardService : IDashboardService
    {
        private readonly IRepository<Income> _incomeRepo;
        private readonly IRepository<Expense> _expenseRepo;
        private readonly IMapper _mapper;
        EnumFinanceYear financeYear;
        private const string monthFormat = "MMMM";
        public DashboardService(IRepository<Income> incomeRepo, IRepository<Expense> expenseRepo, IMapper mapper)
        {
            _incomeRepo = incomeRepo;
            _expenseRepo = expenseRepo;
            _mapper = mapper;

            //TODO: This should be get it from user's setting instead hardcoded
            financeYear = EnumFinanceYear.Islamic;
        }

        async Task<ResponseDTO<IncomeVsExpenseRes>> IDashboardService.IncomeVsExpense(int accountId, int year)
        {
            var financeDateRange = FinanceYearHelper.GetFinanceYearRange(financeYear, year);
            var incomes = await _incomeRepo.GetAll().Where(i => i.AccountId == accountId && i.IncomeOn >= financeDateRange.StartDate && i.IncomeOn <= financeDateRange.EndDate)
                .GroupBy(i => i.IncomeOn.Month)
                .Select(g => new MonthlyFinanceSummary
                {
                    Month = g.Key,
                    Amount = g.Sum(i => i.Amount)
                })
                //.OrderBy(g => g.MonthNumber)
                .ToListAsync();

            var expenses = await _expenseRepo.GetAll().Where(e => e.AccountId == accountId && e.ExpenseOn >= financeDateRange.StartDate && e.ExpenseOn <= financeDateRange.EndDate)
                .GroupBy(e => e.ExpenseOn.Month)
                .Select(g => new MonthlyFinanceSummary
                {
                    Month = g.Key,
                    Amount = g.Sum(e => e.Amount)
                })
                //.OrderBy(g => g.MonthNumber)
                .ToListAsync();

            var response = new IncomeVsExpenseRes()
            {
                Incomes = incomes,
                Expense = expenses
            };

            // Ensure all months exist in both lists
            DashboardHelper.EnsureAllMonthsExist(response);

            return new ResponseDTO<IncomeVsExpenseRes>(HttpStatusCode.OK, AppConst.ApiMessage.DataRetrived, response);
        }

        async Task<ResponseDTO<InvestmentGrowthRes>> IDashboardService.InvestmentGrowth(int accountId, int year)
        {
            await Task.Delay(2500);
            var response = new ResponseDTO<InvestmentGrowthRes>(HttpStatusCode.OK, AppConst.ApiMessage.DataRetrived, new InvestmentGrowthRes());
            return response;
        }

        async Task<ResponseDTO<IncomeDistributionRes>> IDashboardService.IncomeDistribution(int accountId, int year)
        {
            await Task.Delay(1000);
            var response = new ResponseDTO<IncomeDistributionRes>(HttpStatusCode.OK, AppConst.ApiMessage.DataRetrived, new IncomeDistributionRes());
            return response;
        }

        async Task<ResponseDTO<ExpenseDistributionRes>> IDashboardService.ExpenseDistribution(int accountId, int year)
        {
            await Task.Delay(3500);
            var response = new ResponseDTO<ExpenseDistributionRes>(HttpStatusCode.OK, AppConst.ApiMessage.DataRetrived, new ExpenseDistributionRes());
            return response;
        }
    }
}
