namespace HisabPro.DTO.Model
{
    public class TaxSlabDetail
    {
        public string SlabRange { get; set; }         // e.g., ₹3,00,001 – ₹6,00,000
        public decimal Rate { get; set; }             // e.g., 5 (%)
        public decimal TaxableAmount { get; set; }    // e.g., ₹3,00,000
        public decimal TaxForSlab { get; set; }       // e.g., ₹15,000
    }
}
