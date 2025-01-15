using HisabPro.Constants;

namespace HisabPro.DTO.Response
{
    public class IncomeVsExpenseRes
    {
        public string Month { get; set; }
        public int Amount { get; set; }
        public EnumCategoryType Type { get; set; }
    }
}
