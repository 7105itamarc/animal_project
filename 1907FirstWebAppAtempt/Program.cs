using _1907FirstWebAppAtempt;
using _1907FirstWebAppAtempt.Data;
using _1907FirstWebAppAtempt.Hubs;
using _1907FirstWebAppAtempt.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRepository, MyRepository>(); //Add Rep service 
builder.Services.AddSignalR();

string connnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<ZooContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connnectionString));

string AuthenticationConStr = builder.Configuration["ConnectionStrings:AuthenticationConStr"]!;

builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlite(AuthenticationConStr));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

if(app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/Index");
}

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
