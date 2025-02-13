using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum EnumCategoryType
    {
        [EnumText(ResourceKey.LabelExpense)]
        Expense = 1,
        [EnumText(ResourceKey.LabelIncome)]
        Income = 2
    }

    public class EnumCategoryTypeLocalization
    {
        public static string Expense { get; set; }
        public static string Income { get; set; }

        public static string Get(int roleValue)
        {
            if (roleValue == 1)
                return Expense;
            return Income;
        }
    }
}
