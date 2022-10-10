using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IDesignTimeServices, WebApp.Models.MysqlEntityFrameworkDesignTimeServices>();

builder.Services.AddDbContext<WebApp.Data.d03adb48Context>(
        context => context.UseMySQL("server=hcwilli.at;database=d03adb48;user=d03adb48;password=k8J3CMGz7sL68rJW")
    );

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
    pattern: "{controller=Home}/{action=Home}/{name?}/{id?}");

app.Run();
