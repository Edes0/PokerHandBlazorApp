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
builder.Services.AddSingleton<IServiceManager, ServiceManager>();
builder.Services.AddSingleton<IDataAccessManager, DataAccessManager>();
//builder.Services.AddTransient<IMapper>(); Behöver jag ha automapper i denna projektet? Att ha en mapping profile i varje projekt i presenation lagret är tydligen det bästa
//builder.Services.AddSingleton<IHandData, HandData>(); BEHÖVER?


builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDbConnection")));


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
