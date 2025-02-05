using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
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
        EnumFinanceYear financeYear;
        public DashboardService(IRepository<Income> incomeRepo, IRepository<Expense> expenseRepo)
        {
            _incomeRepo = incomeRepo;
            _expenseRepo = expenseRepo;

            //TODO: This should be get it from user's setting instead hardcoded
            financeYear = EnumFinanceYear.Islamic;
        }

        public async Task<ResponseDTO<IncomeVsExpenseRes>> IncomeVsExpense(int accountId, int year)
        {
            var financeDateRange = FinanceYearHelper.GetFinanceYearRange(financeYear, year);
            var incomes = await _incomeRepo.GetAll()
                .Where(i => i.AccountId == accountId && i.IncomeOn >= financeDateRange.StartDate && i.IncomeOn <= financeDateRange.EndDate)
                .GroupBy(i => i.IncomeOn.Month)
                .Select(g => new MonthlyFinanceSummary
                {
                    Month = g.Key,
                    Amount = g.Sum(i => i.Amount)
                })
                .ToListAsync();

            var expenses = await _expenseRepo.GetAll()
                .Where(e => e.AccountId == accountId && e.ExpenseOn >= financeDateRange.StartDate && e.ExpenseOn <= financeDateRange.EndDate)
                .GroupBy(e => e.ExpenseOn.Month)
                .Select(g => new MonthlyFinanceSummary
                {
                    Month = g.Key,
                    Amount = g.Sum(e => e.Amount)
                })
                .ToListAsync();

            var response = new IncomeVsExpenseRes()
            {
                Income = incomes,
                Expense = expenses
            };

            // Ensure all months exist in both lists
            DashboardHelper.EnsureAllMonthsExist(response, res => res.Income, res => res.Expense);

            return new ResponseDTO<IncomeVsExpenseRes>(HttpStatusCode.OK, SharedResource.LabelApiDataRetrived, response);
        }

        public async Task<ResponseDTO<IncomeVsCharityRes>> IncomeVsCharity(int accountId, int year)
        {
            var financeDateRange = FinanceYearHelper.GetFinanceYearRange(financeYear, year);
            var incomes = await _incomeRepo.GetAll()
                .Where(i => i.AccountId == accountId && i.IncomeOn >= financeDateRange.StartDate && i.IncomeOn <= financeDateRange.EndDate)
                .GroupBy(i => i.IncomeOn.Month)
                .Select(g => new MonthlyFinanceSummary
                {
                    Month = g.Key,
                    Amount = g.Sum(i => i.Amount)
                })
                .ToListAsync();

            var charity = await _expenseRepo.GetAll()
                .Where(e => e.AccountId == accountId 
                && e.ExpenseOn >= financeDateRange.StartDate && e.ExpenseOn <= financeDateRange.EndDate
                && e.CategoryId == CategoryHelper.GetCharityCategoryId)
               .GroupBy(e => e.ExpenseOn.Month)
               .Select(g => new MonthlyFinanceSummary
               {
                   Month = g.Key,
                   Amount = g.Sum(e => e.Amount)
               })
               .ToListAsync();

            var response = new IncomeVsCharityRes()
            {
                Income = incomes,
                Charity = charity
            };

            // Ensure all months exist in both lists
            DashboardHelper.EnsureAllMonthsExist(response, res => res.Income, res => res.Charity);

            return new ResponseDTO<IncomeVsCharityRes>(HttpStatusCode.OK, SharedResource.LabelApiDataRetrived, response);
        }

        public async Task<ResponseDTO<List<WealthBreakdownRes>>> IncomeDistribution(int accountId, int year)
        {
            var financeDateRange = FinanceYearHelper.GetFinanceYearRange(financeYear, year);
            var incomes = await _incomeRepo.GetAll()
                .Where(i => i.AccountId == accountId && i.IncomeOn >= financeDateRange.StartDate && i.IncomeOn <= financeDateRange.EndDate)
                .GroupBy(e => new { e.CategoryId, e.Category.Name })
                .Select(g => new WealthBreakdownRes
                {
                    CategoryId = g.Key.CategoryId,
                    Category = g.Key.Name,
                    Amount = g.Sum(e => e.Amount)
                })
                .ToListAsync();
            return new ResponseDTO<List<WealthBreakdownRes>>(HttpStatusCode.OK, SharedResource.LabelApiDataRetrived, incomes);
        }

        public async Task<ResponseDTO<List<WealthBreakdownRes>>> ExpenseDistribution(int accountId, int year)
        {
            var financeDateRange = FinanceYearHelper.GetFinanceYearRange(financeYear, year);
            var expenses = await _expenseRepo.GetAll()
                .Where(e => e.AccountId == accountId && e.ExpenseOn >= financeDateRange.StartDate && e.ExpenseOn <= financeDateRange.EndDate)
                .GroupBy(e => new { e.CategoryId, e.Category.Name })
                .Select(g => new WealthBreakdownRes
                {
                    CategoryId = g.Key.CategoryId,
                    Category = g.Key.Name,
                    Amount = g.Sum(e => e.Amount)
                })
                .ToListAsync();

            return new ResponseDTO<List<WealthBreakdownRes>>(HttpStatusCode.OK, SharedResource.LabelApiDataRetrived, expenses);
        }
    }
}
