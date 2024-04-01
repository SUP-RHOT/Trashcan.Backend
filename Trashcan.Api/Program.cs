using System.Globalization;
using Serilog;
using Trashcan.Api;
using Trashcan.Application.DependensyInjection;
using Trashcan.DAL.DependensyInjection;
using Trashcan.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddSwagger(builder);
builder.Services.AddAuthenticationAndAuthorization(builder);
builder.Services.AddMailConfiguration(builder);

builder.Services.AddCors();
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

app.UseCors();

app.MapControllers();

app.Run();
