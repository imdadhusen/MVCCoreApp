using HisabPro.DTO.Model;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface IDashboardService
    {
        public Task<ResponseDTO<IncomeVsExpenseRes>> IncomeVsExpense(int accountId, int year);
        public Task<ResponseDTO<IncomeVsCharityRes>> IncomeVsCharity(int accountId, int year);
        public Task<ResponseDTO<List<WealthBreakdownRes>>> IncomeDistribution(int accountId, int year);
        public Task<ResponseDTO<List<WealthBreakdownRes>>> ExpenseDistribution(int accountId, int year);
    }
}
