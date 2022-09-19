using AutoMapper;
using CardApp.Data;
using Contracts;
using DataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<IDataAccessManager, DataAccessManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddDbContext<SqlDbContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDbConnection")));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
