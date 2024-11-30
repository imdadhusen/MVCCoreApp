using HisabPro.DTO.Model;

namespace HisabPro.DTO.Request
{
    public class LoadDataRequest
    {
        public PageDataReq PageData { get; set; }
        public List<BaseFilterModel> Filters { get; set; }
    }
}
