using HisabPro.DTO.Model;

namespace HisabPro.DTO.Response
{
    public class IncomeVsExpenseRes
    {
        public List<MonthlyFinanceSummary> Income { get; set; }
        public List<MonthlyFinanceSummary> Expense { get; set; }
    }
}
