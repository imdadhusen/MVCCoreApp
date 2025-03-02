﻿using HisabPro.Constants;

namespace HisabPro.DTO.Request
{
    public class ExportReq : LoadDataRequest
    {
        public EnumExportType ExportType { get; set; }
        public string? FileName { get; set; }
    }
}
