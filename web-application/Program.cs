using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using web_application.Data;
using web_application.Models;
using web_application.Seed;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<web_applicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("web_applicationContext") ?? throw new InvalidOperationException("Connection string 'web_applicationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    DbInitializer.Initialize(services);
}

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
