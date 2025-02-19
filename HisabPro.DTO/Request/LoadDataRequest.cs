using HisabPro.DTO.Model;

namespace HisabPro.DTO.Request
{
    public class LoadDataRequest
    {
        public PageDataReq PageData { get; set; }
        public FilterViewModel? Filter { get; set; }
    }
}
