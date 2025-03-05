using Microsoft.AspNetCore.Mvc;
using HisabPro.DTO.Model;

namespace HisabPro.Services.Interfaces
{
    public interface IExportService
    {
        FileContentResult Export<T>(List<T> data, string reportTitle, List<Column> columns, string AppliedSortField = "NA", string AppliedSortType = "NA", int AppliedFilterCount = 0);
    }
}
