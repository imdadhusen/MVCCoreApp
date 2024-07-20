using System.Net;
using System.Text.Json;

namespace HisabPro.Web.Middleware
{
    public class ExceptionHandler
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                Message = "An error occurred while processing your request.",
                Details = exception.Message,
                StackTrace = exception.StackTrace // Optional: You might not want to expose stack traces in production
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }

}
