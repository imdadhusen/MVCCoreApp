namespace HisabPro.DTO.Response
{
    public class IncomeVsCharityRes
    {
        public List<IncomeCharity> Income { get; set; }
        public List<IncomeCharity> Charity { get; set; }
    }

    public class IncomeCharity
    {
        public string Month { get; set; }
        public int Amount { get; set; }
    }
}
