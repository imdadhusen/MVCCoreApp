using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum EnumReportTitle
    {
        [EnumText(ResourceKey.ReportAccountsDetail)]
        AccountsDetail = 1,
        [EnumText(ResourceKey.ReportCategoryAndSubcategory)]
        CategoryAndSubcategory,
        [EnumText(ResourceKey.ReportExpense)]
        Expense,
        [EnumText(ResourceKey.ReportIncome)]
        Income,
        [EnumText(ResourceKey.ReportIncomeAndExpense)]
        IncomeAndExpense,
        [EnumText(ResourceKey.ReportUser)]
        User
    }
}
