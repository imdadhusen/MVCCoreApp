using HisabPro.DTO.Model;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<ResponseDTO<IncomeVsExpenseRes>> IncomeVsExpense(int accountId, int year);
        Task<ResponseDTO<InvestmentGrowthRes>> InvestmentGrowth(int accountId, int year);
        Task<ResponseDTO<IncomeDistributionRes>> IncomeDistribution(int accountId, int year);
        Task<ResponseDTO<ExpenseDistributionRes>> ExpenseDistribution(int accountId, int year);
    }
}
