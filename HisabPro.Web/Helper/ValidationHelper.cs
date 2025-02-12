using HisabPro.Constants;
using HisabPro.Constants.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HisabPro.Web.Helper
{
    public static class ValidationHelper
    {
        //private static readonly ISharedViewLocalizer _localizer;

        //public ValidationHelper(ISharedViewLocalizer localizer) {
        //    _localizer = localizer;
        //}

        public static (string, List<string>?) GetValidationErrors(ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                return ("", null);
            }
            else
            {
                return (
                    ResourceKey.LabelApiValidationFailed,
                    modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                );
            }
        }
    }
}
