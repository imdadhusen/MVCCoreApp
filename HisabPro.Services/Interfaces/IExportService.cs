using Microsoft.AspNetCore.Mvc;
using HisabPro.DTO.Model;

namespace HisabPro.Services.Interfaces
{
    public interface IExportService
    {
        FileContentResult Export<T>(List<T> data, string reportTitle, string reportFileName, List<Column> columns, List<FilterDescriptionModel>? filterDescriptions, string AppliedSortField = "NA", string AppliedSortType = "NA");
    }
}
