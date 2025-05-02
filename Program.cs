using DotNetSqlApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine(">>> DefaultConnection: " + builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation(">>> DefaultConnection: {ConnectionString}", builder.Configuration.GetConnectionString("DefaultConnection"));
app.Urls.Add("http://+:80");
app.MapControllers();
app.Run();
