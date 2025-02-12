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
}
