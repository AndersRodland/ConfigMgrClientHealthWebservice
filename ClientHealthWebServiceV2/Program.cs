using ClientHealthWebServiceV2.BL.Auth;
using ClientHealthWebServiceV2.BL.ClientActions;
using ClientHealthWebServiceV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();
var useSwagger = builder.Configuration.GetValue<bool>("EnableSwagger");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
if (useSwagger)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Client Health API",
            Description = ""
        }
        );
    });
}

builder.Services.AddScoped<IClientActions, ClientActions>();
logger.Warning("Starting Up the shield");

string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ClientDBContext>(options => options.UseSqlServer(ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() && useSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

/// API Key Middleware:  https://codingsonata.com/secure-asp-net-core-web-api-using-api-key-authentication/
//app.UseMiddleware<ApiKeyMiddleware>();

app.Run();
