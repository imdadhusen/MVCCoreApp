using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Response
{
    public class IncomeResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = DataFormat.Grid.Date)]
        public DateTime IncomeOn { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public string Account { get; set; }
        public bool IsBulkImported { get; set; }
    }
}
