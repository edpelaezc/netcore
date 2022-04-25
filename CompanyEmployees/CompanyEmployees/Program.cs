using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// logging service
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// add services
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// app pipeline
if (app.Environment.IsDevelopment())
	app.UseDeveloperExceptionPage();
else
	app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
	ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
