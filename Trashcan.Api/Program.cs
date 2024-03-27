using System.Globalization;
using Serilog;
using Trashcan.Application.DependensyInjection;
using Trashcan.DAL.DependensyInjection;
using Trashcan.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);
// CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
// CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.DefaultSections));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
