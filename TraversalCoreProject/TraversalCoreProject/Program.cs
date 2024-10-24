using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalCoreProject.Models;

var builder = WebApplication.CreateBuilder(args);

//burasını sonradan ekledik
builder.Services.AddDbContext<Context>();
//burasını sonradan ekledik
builder.Services
    .AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>()
    .AddEntityFrameworkStores<Context>();

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

app.Run();

