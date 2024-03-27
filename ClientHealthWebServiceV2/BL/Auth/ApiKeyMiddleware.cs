using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ClientHealthWebServiceV2.BL.Auth
{
    //public class ApiKeyMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private const string ApiKeyName = "ApiKey";
    //    public ApiKeyMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }
    //    public async Task InvokeAsync(HttpContext context)
    //    {
    //        if (!context.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
    //        {
    //            context.Response.StatusCode = 401;
    //            await context.Response.WriteAsync("Authorization not provided.");
    //            return;
    //        }

    //        var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

    //        var apiKey = appSettings.GetValue<string>(ApiKeyName);

    //        if (!apiKey.Equals(extractedApiKey))
    //        {
    //            context.Response.StatusCode = 401;
    //            await context.Response.WriteAsync("Unauthorized client.");
    //            return;
    //        }

    //        await _next(context);
    //    }
    //}


}