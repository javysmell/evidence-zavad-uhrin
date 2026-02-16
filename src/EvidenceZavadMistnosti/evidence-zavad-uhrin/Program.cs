using Microsoft.AspNetCore.Authentication.Cookies;
using evidence_zavad_uhrin.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. èást - builder sracky

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
    //    options.LoginPath = "/Account/Login"; //home bude jina stranka pak
    //    options.LogoutPath = "Account/Logout"; // tahle stranka se pak udela
    //    options.AccessDeniedPath = "/Account/Denied"; //taky

        options.Cookie.HttpOnly = true;
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
app.UseRouting();

// 2. èást - zapnutí autentizace
app.UseAuthentication(); // kdo jsme
app.UseAuthorization(); // èím jsme (jaké role?)

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
