using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatientAPI.Data;
using PatientAPI.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<PatientDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Replace placeholders with actual secrets
ReplaceConfigurationPlaceholder(builder.Configuration, "ConnectionStrings:DefaultConnection", "SQL_SERVER");
ReplaceConfigurationPlaceholder(builder.Configuration, "ConnectionStrings:DefaultConnection", "SQL_DATABASE");
ReplaceConfigurationPlaceholder(builder.Configuration, "ConnectionStrings:DefaultConnection", "SQL_USER");
ReplaceConfigurationPlaceholder(builder.Configuration, "ConnectionStrings:DefaultConnection", "SQL_PASSWORD");

builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

app.MapGrpcService<PatientService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

static void ReplaceConfigurationPlaceholder(IConfiguration configuration, string key, string secretName)
{
    // Replace placeholder with the actual secret value
    var secretValue = Environment.GetEnvironmentVariable(secretName);
    if (!string.IsNullOrEmpty(secretValue))
    {
        configuration[key] = secretValue;
    }
}