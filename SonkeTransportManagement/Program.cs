using Microsoft.EntityFrameworkCore;
using SonkeTransportManagement.Context;
using SonkeTransportManagement.Sevices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SonkeTransportManagement.Models.RequesterRequest>();
builder.Services.AddScoped<SonkeTransportManagement.Models.User>();
builder.Services.AddScoped<SonkeTransportManagement.Models.Roles>();
builder.Services.AddScoped<SonkeTransportManagement.Context.ApplicationContext>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddSession();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
