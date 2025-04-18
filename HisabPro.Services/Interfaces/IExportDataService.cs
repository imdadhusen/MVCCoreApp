﻿using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Services.Interfaces
{
    public interface IExportDataService
    {
        FileContentResult Export<T>(List<T> data, EnumReportTitle reportTitle, ExportReq reqExport, List<Column> columns);
    }
}
