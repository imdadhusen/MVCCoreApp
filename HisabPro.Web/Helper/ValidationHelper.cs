using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HisabPro.Web.Helper
{
    public static class ValidationHelper
    {
        public static List<string> GetValidationErrors(ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
        }
    }
}
