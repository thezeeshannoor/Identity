using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("db"));

});
//builder.Services.Configure <List<Theme>>(builder.Configuration.GetSection("Theme"));
//builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.AccessDeniedPath = "/Account/Login";
    option.LoginPath = "/Account/Login";
    option.LogoutPath = "/Account/Login";
    option.Cookie.Name = "Identity";
    option.ExpireTimeSpan=TimeSpan.FromDays(30);
    option.SlidingExpiration = true;
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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
