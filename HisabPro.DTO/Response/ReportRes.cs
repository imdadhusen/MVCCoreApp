﻿using HisabPro.Constants;
using System.ComponentModel.DataAnnotations;

namespace HisabPro.DTO.Response
{
    public class ReportRes
    {
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = DataFormat.Grid.Date)]
        public DateTime TransactionOn { get; set; } //Income or Expense transaction date (IncomeOn or ExpenseOn)
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public double Amount { get; set; }
        public string Account { get; set; }
        public string Type { get; set; } // 1:Expense or 2:Income, used for display in grid
        public int TypeId { get; set; } // 1 or 2, used for filter

        public string? Note { get; set; }
    }
}
