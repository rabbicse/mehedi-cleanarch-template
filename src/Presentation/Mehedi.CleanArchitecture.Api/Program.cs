using System.Runtime.InteropServices;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;
using Serilog.Settings.Configuration;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Get OS runtime
string os = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "Linux" : "Windows";

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
