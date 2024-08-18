using _1907FirstWebAppAtempt;
using _1907FirstWebAppAtempt.Data;
using _1907FirstWebAppAtempt.Hubs;
using _1907FirstWebAppAtempt.Repositories;
<<<<<<< HEAD
using Microsoft.AspNetCore.Identity;
=======
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
>>>>>>> 26281e4ca54093c2eef448ab8311b83ba2c3019b
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRepository, MyRepository>(); //Add Rep service 
builder.Services.AddSignalR();

string connnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<ZooContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connnectionString));

<<<<<<< HEAD
string AuthenticationConStr = builder.Configuration["ConnectionStrings:AuthenticationConStr"]!;

builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlite(AuthenticationConStr));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.AddControllersWithViews();
=======
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ZooContext>();

//builder.Services.AddControllersWithViews();
>>>>>>> 26281e4ca54093c2eef448ab8311b83ba2c3019b
var app = builder.Build();

if(app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/Index");
}

<<<<<<< HEAD
=======
app.UseAuthentication();
>>>>>>> 26281e4ca54093c2eef448ab8311b83ba2c3019b
app.UseStaticFiles();

using(var scope = app.Services.CreateScope())
{
    var ZooDB = scope.ServiceProvider.GetRequiredService<ZooContext>();
    ZooDB.Database.EnsureDeleted();
    ZooDB.Database.EnsureCreated();

    var AuthenticationCtx = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    //AuthenticationCtx.Database.EnsureDeleted();
    AuthenticationCtx.Database.EnsureCreated();
}

app.MapHub<ChatHub>("/ChatHub");

app.UseAuthentication();

app.MapControllerRoute("default", "{controller=Main}/{action=HomePage}/{id=1}");

app.UseAuthorization();

//app.UseRouting();
app.Run();
