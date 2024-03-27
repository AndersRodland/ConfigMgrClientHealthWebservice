using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClientHealthWebServiceV2.BL.Auth
{
    public class ApiKeyAuthorizationAttribute : TypeFilterAttribute
    {
        public ApiKeyAuthorizationAttribute(string keyName) : base(typeof(ApiKeyAuthorizationFilter))
        {
            Arguments = new object[] { keyName };
        }
    }
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        private readonly ILogger<ApiKeyAuthorizationFilter> _logger;
        private readonly string _keyname;

        public ApiKeyAuthorizationFilter(ILogger<ApiKeyAuthorizationFilter> logger, string keyName)
        {
            _logger = logger;
            _keyname = keyName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var configuredApiKeys = appSettings.GetSection(_keyname).Get<string[]>().ToList();


            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
            {
                var failedPath = context.HttpContext.Request.Path.ToString();
                var remoteHost = context.HttpContext.Connection.RemoteIpAddress?.ToString();
                _logger.LogWarning("Authorization header missing API key for Path: [{failedPath}]  Remote host:  [{remoteHost}]", failedPath, remoteHost);
                context.Result = new UnauthorizedResult();
                return;
            }

            if (configuredApiKeys.Count == 0 || !configuredApiKeys.Contains(extractedApiKey))
            {
                var failedPath = context.HttpContext.Request.Path;
                var remoteHost = context.HttpContext.Connection.RemoteIpAddress?.ToString();
                _logger.LogWarning("Unauthorized access with API key provided by client to Path: [{failedPath}]  Remote host:  [{remoteHost}]", failedPath, remoteHost);
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
