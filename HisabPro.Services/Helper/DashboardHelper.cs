using HisabPro.DTO.Response;

namespace HisabPro.Services.Helper
{
    public static class DashboardHelper
    {
        public static void EnsureAllMonthsExist(IncomeVsExpenseRes response)
        {
            // Determine the maximum month number
            int maxMonth = Math.Max(
                response.Incomes.Any() ? response.Incomes.Max(x => x.Month) : 0,
                response.Expense.Any() ? response.Expense.Max(x => x.Month) : 0
            );

            // Add missing months with zero amount
            response.Incomes = AddMissingMonths(response.Incomes, maxMonth);
            response.Expense = AddMissingMonths(response.Expense, maxMonth);
        }

        private static List<MonthlyFinanceSummary> AddMissingMonths(List<MonthlyFinanceSummary> list, int maxMonth)
        {
            // Create a hash set of existing months for quick lookup
            var existingMonths = new HashSet<int>(list.Select(x => x.Month));

            // Add missing months
            for (int month = 1; month <= maxMonth; month++)
            {
                if (!existingMonths.Contains(month))
                {
                    list.Add(new MonthlyFinanceSummary { Month = month, Amount = 0 });
                }
            }

            // Sort the list by month before returning
            return list.OrderBy(x => x.Month).ToList();
        }
    }
}
