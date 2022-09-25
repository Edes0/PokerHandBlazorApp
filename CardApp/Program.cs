using CardApp.Data;
using CardApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.ConfigureDataAccessManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlDataAccess();
builder.Services.ConfigureSqlDbContext(builder.Configuration);

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


//TODO: S�tt in kort i tomt index.
//TODO: S�tt services p� r�tt st�lle ifr�n CardGame.page
//TODO: Kan trycka swap �ven om man inte v�ljer ett kort att byta bort