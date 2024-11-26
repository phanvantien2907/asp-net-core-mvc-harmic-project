using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// confifg dbcontext
builder.Services.AddDbContext<HarmicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();



// xác thực admin
builder.Services.AddAuthentication("AdminScheme").AddCookie("AdminScheme", options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Admin/dang-nhap";
    options.AccessDeniedPath = "/AccessDenied";
    options.ReturnUrlParameter = "returnURL";
});

// config session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100); // Thời gian hết hạn session
    options.Cookie.HttpOnly = true; // Bảo mật cookie session
    options.Cookie.IsEssential = true; // Bắt buộc cookie
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

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// admin
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// route cho login admin
app.MapControllerRoute(
    name: "AdminLogin",
    pattern: "Admin/dang-nhap",
    defaults: new { controller = "Login", action = "Index", area = "Admin" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
