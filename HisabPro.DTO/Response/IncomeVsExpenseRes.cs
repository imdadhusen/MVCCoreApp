namespace HisabPro.DTO.Response
{
    public class IncomeVsExpenseRes
    {
        public List<MonthlyFinanceSummary> Incomes { get; set; }
        public List<MonthlyFinanceSummary> Expense { get; set; }
    }

    public class MonthlyFinanceSummary
    {
        public int Month { get; set; }
        public double Amount { get; set; }
    }
}
