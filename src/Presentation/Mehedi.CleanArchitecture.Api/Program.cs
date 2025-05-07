using System.Runtime.InteropServices;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;
using Serilog.Settings.Configuration;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
#if UseCaching
using Mehedi.CleanArchitecture.RedisCache.Infrastructure;
#endif

var builder = WebApplication.CreateBuilder(args);

// Get OS runtime
string os = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "Linux" : "Windows";

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var basePath = Directory.GetCurrentDirectory();

builder.Configuration.SetBasePath(basePath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Load base + env-specific config files dynamically
foreach (var file in Directory.GetFiles(basePath, $"appsettings.{environment}.*.json", SearchOption.TopDirectoryOnly))
{
    builder.Configuration.AddJsonFile(file, optional: true, reloadOnChange: true);
}

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration,
        new ConfigurationReaderOptions { SectionName = $"Serilog{os}" }) // Read settings from appsettings.json
    .CreateLogger();

// Add Serilog to the dependency injection container
builder.Host.UseSerilog();

// Compression
builder.Services.Configure<GzipCompressionProviderOptions>(compressionOptions => compressionOptions.Level = System.IO.Compression.CompressionLevel.Fastest);
builder.Services.AddResponseCompression(compressionOptions =>
{
    compressionOptions.EnableForHttps = true;
    compressionOptions.Providers.Add<GzipCompressionProvider>();
});

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

// Add dependencies from Application layer
builder.Services.AddApplications();
builder.Services.AddInfrastructureServices(builder.Configuration);
#if UseCaching
builder.Services.AddCacheInfrastructureServices(builder.Configuration);
#endif

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
