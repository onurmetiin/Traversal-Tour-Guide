using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using OfficeOpenXml;
using Serilog;
using TraversalCoreProject.Models;
using OfficeOpenXml;

var builder = WebApplication.CreateBuilder(args);

//burasını sonradan ekledik
builder.Services.AddDbContext<Context>();
//burasını sonradan ekledik
builder.Services
    .AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>()
    .AddEntityFrameworkStores<Context>();

//burasını sonradan ekledik
builder.Services.AddLogging(x=>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();

    //burasını sonradan ekledik
    var path = Directory.GetCurrentDirectory();
    x.AddFile($"{path}\\Logs\\Log1.txt");
});


//burası sonradan eklendi (Controller tarafında sürekli manageri newlememek için I..Service i verdik onun için burası)
CustomizeExtension.ContainerDependency(builder.Services);
//builder.Services.ContainerDependency();

// Add services to the container.
builder.Services.AddControllersWithViews();

//burasını sonradan ekledik
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    config.Filters.Add(new AuthorizeFilter(policy));

    //builder.Services.AddMvc();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();



//burasını sonradan ekledik
app.UseAuthentication();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute
    (
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute
    (
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});




//EXCEL için eklendi
// EPPlus lisans ayarı
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


// Middleware ayarları
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

