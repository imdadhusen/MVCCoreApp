using HisabPro.Constants.Resources;
using HisabPro.Constants;

namespace HisabPro.DTO.Request
{
    public class SetLanguageReq
    {
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        public string Culture { get; set; }
        [LocalizedRequired(ResourceKey.ValidationRequired)]
        public string ReturnUrl { get; set; }
    }
}
