using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Response
{
    public class ExpenseRes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = DataFormat.Grid.Date)]
        public DateTime ExpenseOn { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }

        public string Account { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public bool IsBulkImported { get; set; }
    }
}
