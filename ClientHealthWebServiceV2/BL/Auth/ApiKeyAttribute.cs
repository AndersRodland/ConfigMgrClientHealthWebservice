using ClientHealthWebServiceV2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ClientHealthWebServiceV2.BL.Auth
{
    [AttributeUsage(validOn: AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _configKey;
        private readonly ILogger _logger = new LoggerFactory().CreateLogger<ApiKeyAttribute>();
        private const string ApiKeyName = "ApiKey";

        public ApiKeyAttribute(string configKey)
        {
            _configKey = configKey;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogWarning("Trying this thing out...");
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Authorization not provided."
                };
                _logger.LogWarning("Authorization not provided for API call. {path}", context.HttpContext.Request.Path);
                return;
            }

            if (string.IsNullOrEmpty(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Authorization not provided."
                };
                _logger.LogWarning("Authorization not provided for API call. The key is empty.  {path}", context.HttpContext.Request.Path);
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            List<string> configuredApiKeys = appSettings.GetSection(_configKey).Get<string[]>().ToList();

            if (!(configuredApiKeys.Count != 0 && configuredApiKeys.Contains(extractedApiKey)))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Unauthorized client"
                };
                _logger.LogWarning("Incorrect API Key Provided for API call. {path}", context.HttpContext.Request.Path);
                return;
            }

            await next();
        }
    }
}