using HisabPro.DTO.Model;

namespace HisabPro.DTO.Response
{
    public class IncomeVsCharityRes
    {
        public List<MonthlyFinanceSummary> Income { get; set; }
        public List<MonthlyFinanceSummary> Charity { get; set; }
    }
}
