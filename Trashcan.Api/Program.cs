using System.Collections.Immutable;
using Serilog;
using Trashcan.Application.DependensyInjection;
using Trashcan.DAL.DependensyInjection;
using Trashcan.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.DefaultSections));
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddApplication();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

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
