using Duende.IdentityServer.Services;
using MicroNetSix.Services.Identity;
using MicroNetSix.Services.Identity.DbContexts;
using MicroNetSix.Services.Identity.Initializer;
using MicroNetSix.Services.Identity.Models;
using MicroNetSix.Services.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IDbInitializer, DbInitializer>();


var asd =builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryIdentityResources(SD.IdentityResources)
    .AddInMemoryApiScopes(SD.ApiScopes)
    .AddInMemoryClients(SD.Clients).AddProfileService<ProfileService>()
    .AddAspNetIdentity<ApplicationUser>()
    .AddDeveloperSigningCredential();

asd.AddDeveloperSigningCredential();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddControllersWithViews();
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
SeedDatabase();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}

//var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

//using (var scope = scopeFactory.CreateScope())
//{
//    var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
//    dbInitializer.Initialize();
//}