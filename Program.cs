using TS_Tool.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TS_Tool.Service.GetBetInfo;
using TS_Tool.Service.GetSWError;
using TS_Tool.Service.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<YY1GameProviderDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("FirstDatabaseConnection")));
builder.Services.AddDbContext<SecondDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SecondDatabaseConnection")));
builder.Services.AddDbContext<ThirdDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ThirdDatabaseConnection")));
builder.Services.AddScoped<IGetBetInfoService, GetBetInfoService>();
builder.Services.AddScoped<INewSystemGameProviderRepo, GetBetInfoRepository>();
builder.Services.AddScoped<IGetSWErrorService, GetSWErrorService>();
builder.Services.AddScoped<IGetSWErrorRepository, GetSWErrorRepository>();
builder.Services.AddScoped<IGetOSBetInfoByMixParlayBetRepository, GetOSBetInfoByMixParlayBetRepository>();
builder.Services.AddScoped<IGetOSBetInfoBySingleBetRepository, GetOSBetInfoBySingleBetRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
