namespace HisabPro.DTO.Model
{
    public class TaxResultModel
    {
        public decimal AnnualIncome { get; set; }

        public decimal StandardDeduction { get; set; } = 50000;

        public decimal TaxableIncome => AnnualIncome - StandardDeduction;

        public decimal TaxAmount { get; set; }

        public string ResultMessage { get; set; }

        public List<TaxSlabDetail> SlabBreakdown { get; set; } = new();
    }

}
