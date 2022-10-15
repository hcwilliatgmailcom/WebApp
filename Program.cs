using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDesignTimeServices, App.Models.MysqlEntityFrameworkDesignTimeServices>();

 

builder.Services.AddDbContext<App.Data.AppDbContext>(
        context => context.UseMySQL(builder.Configuration.GetConnectionString("MySql"))
    );

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
    pattern: "{controller=Entity}/{action=Index}/{id?}");

app.Run();
