using HisabPro.DTO.Model;

public static class DashboardHelper
{
    public static void EnsureAllMonthsExist<T>(
        T response,
        Func<T, List<MonthlyFinanceSummary>> getPrimaryList,
        Func<T, List<MonthlyFinanceSummary>> getSecondaryList)
    {
        // Access the primary and secondary lists using the provided delegates
        var primaryList = getPrimaryList(response);
        var secondaryList = getSecondaryList(response);

        // Determine the maximum month number
        int maxMonth = Math.Max(
            primaryList.Any() ? primaryList.Max(x => x.Month) : 0,
            secondaryList.Any() ? secondaryList.Max(x => x.Month) : 0
        );

        // Add missing months with zero amount, preserving existing values
        AddMissingMonths(primaryList, maxMonth);
        AddMissingMonths(secondaryList, maxMonth);
    }

    private static void AddMissingMonths(List<MonthlyFinanceSummary> list, int maxMonth)
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

        // Sort the list by month
        list.Sort((a, b) => a.Month.CompareTo(b.Month));
    }
}
