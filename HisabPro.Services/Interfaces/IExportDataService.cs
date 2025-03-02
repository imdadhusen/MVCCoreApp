using HisabPro.Constants;
using Microsoft.AspNetCore.Mvc;
using HisabPro.DTO.Model;

namespace HisabPro.Services.Interfaces
{
    public interface IExportDataService
    {
        FileContentResult Export<T>(List<T> data, string reportTitle, EnumExportType exportType, List<Column> columns);
    }
}
