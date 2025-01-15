using HisabPro.DTO.Model;
using HisabPro.DTO.Response;
using HisabPro.Services.Interfaces;
using System.Net;

namespace HisabPro.Services.Implements
{
    public class DashboardService : IDashboardService
    {
        async Task<ResponseDTO<IncomeVsExpenseRes>> IDashboardService.IncomeVsExpense(int accountId)
        {
            await Task.Delay(5000);
            var response = new ResponseDTO<IncomeVsExpenseRes>(HttpStatusCode.OK, "", new IncomeVsExpenseRes());
            return response;
        }

        async Task<ResponseDTO<InvestmentGrowthRes>> IDashboardService.InvestmentGrowth(int accountId)
        {
            await Task.Delay(2500);
            var response = new ResponseDTO<InvestmentGrowthRes>(HttpStatusCode.OK, "", new InvestmentGrowthRes());
            return response;
        }

        async Task<ResponseDTO<IncomeDistributionRes>> IDashboardService.IncomeDistribution(int accountId)
        {
            await Task.Delay(1000);
            var response = new ResponseDTO<IncomeDistributionRes>(HttpStatusCode.OK, "", new IncomeDistributionRes());
            return response;
        }

        async Task<ResponseDTO<ExpenseDistributionRes>> IDashboardService.ExpenseDistribution(int accountId)
        {
            await Task.Delay(3500);
            var response = new ResponseDTO<ExpenseDistributionRes>(HttpStatusCode.OK, "", new ExpenseDistributionRes());
            return response;
        }
    }
}
