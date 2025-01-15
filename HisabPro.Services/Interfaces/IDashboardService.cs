using HisabPro.DTO.Model;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<ResponseDTO<IncomeVsExpenseRes>> IncomeVsExpense(int accountId);
        Task<ResponseDTO<InvestmentGrowthRes>> InvestmentGrowth(int accountId);
        Task<ResponseDTO<IncomeDistributionRes>> IncomeDistribution(int accountId);
        Task<ResponseDTO<ExpenseDistributionRes>> ExpenseDistribution(int accountId);
    }
}
