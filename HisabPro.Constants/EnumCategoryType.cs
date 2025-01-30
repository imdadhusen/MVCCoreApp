using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum EnumCategoryType
    {
        [EnumText(typeof(SharedResource), nameof(SharedResource.LabelExpense))]
        Expense = 1,
        [EnumText(typeof(SharedResource), nameof(SharedResource.LabelIncome))]
        Income = 2
    }
}
