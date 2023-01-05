using BussinesEmployee.BL.Interface;
using BussinesEmployee.BL.Repositry;
using BussinesEmployee.DAL.Database;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BussinesEmployee.BL.Mapper;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Identity;
using BussinesEmployee.Resource.Account.Account_Login;
using System.Reflection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization() 
    .AddNewtonsoftJson(ops => { ops.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

builder.Services.AddDbContextPool<DbContainer>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDatabaseConnection")));

builder.Services.AddAutoMapper(a => a.AddProfile(new DomainProfile()));
// an instance for each user
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();

builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<IDistrictRepo, DistrictRepo>();
builder.Services.AddScoped<IDataRepo,DataRepo>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DbContainer>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

builder.Services.AddAuthentication()
    .AddGoogle(o =>
    {
        o.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        o.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });

var supportedCultures = new[]
{
    new CultureInfo("ar-EG"),
    new CultureInfo("en-US")
};




var app = builder.Build();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture=new RequestCulture("en-US"),
    SupportedUICultures = supportedCultures,
    RequestCultureProviders=new List<IRequestCultureProvider>()
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider()
    }
}); 







// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();



