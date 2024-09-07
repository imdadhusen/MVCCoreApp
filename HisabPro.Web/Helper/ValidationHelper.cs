using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HisabPro.Web.Helper
{
    public static class ValidationHelper
    {
        public static (string, List<string>?) GetValidationErrors(ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                return ("", null);
            }
            else
            {
                return (
                    "Validation failed",
                    modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                );
            }
        }
    }
}
