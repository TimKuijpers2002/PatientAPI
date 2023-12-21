using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatientAPI.Data;
using PatientAPI.Services;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<PatientDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

app.UseMetricServer();
app.UseHttpMetrics();

ApplyMigrations(app);

app.MapGrpcService<PatientService>();
app.MapGet("/", () => "health check");

app.Run();

static void ApplyMigrations(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<PatientDbContext>();
    db.Database.Migrate();
}