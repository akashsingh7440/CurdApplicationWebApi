using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CurdApplicationWebApi.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiRootLogging
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiRootLogging> _logger;
        public ApiRootLogging(RequestDelegate next, ILogger<ApiRootLogging> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var requestPath  = httpContext.Request.Path.Value;

            var value = rootLoggingKeyValue.GetValueOrDefault(requestPath);
            
            RootLooging(value);
   
            return _next(httpContext);
        }

        private void RootLooging(string value)
        {
            _logger.LogInformation($"Route Logging....{value}");
        }
        Dictionary<string, string> rootLoggingKeyValue = new Dictionary<string, string>()
        {
            {"/api/CrudApplication/AddInformation","AddInformation" },
            {"/api/CrudApplication/GetAllInformation","GetAllInformation" },
            {"/api/CrudApplication/GetInformationById","GetInformationById" },
            {"/api/CrudApplication/UpdateInformation","UpdateInformation" },
            {"/api/CrudApplication/DeleteInformationById","DeleteInformationById" },
            {"/api/CrudApplication/GetAllDeleteUserInformation","GetAllDeleteUserInformation" },
            {"/api/CrudApplication/DeleteAllDeactivatedInformation","DeleteAllDeactivatedInformation" }

        };
    }
    
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiRootLoggingExtensions
    {
        public static IApplicationBuilder UseApiRootLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiRootLogging>();
        }
    }
}
