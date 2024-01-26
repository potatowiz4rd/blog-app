using FA.JustBlog.Core;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;
using FA.JustBlog.Repository.Repositories;
using FA.JustBlog.Service.category;
using FA.JustBlog.Service.post;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add Context
builder.Services.AddDbContext<JustBlogContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("JustBlogContext")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


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

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapAreaControllerRoute(
//        areaName: "Admin",
//        name: "Admin",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});

app.MapControllerRoute(
    name: "Post",
    pattern: "{controller=Post}/{year}/{month}/{title}",
    defaults: new
    {
        controller = "Post",
        action = "Detail",
        year = @"\d{4}",
        month = @"\d{2}",
    }
    );
app.MapControllerRoute(
    name: "Categories",
    pattern: "{controller=Categories}/{name}",
    defaults: new
    {
        controller = "Categories",
        action = "Index",
    }
    );

app.MapControllerRoute(
    name: "Tag",
    pattern: "{controller=Tag}/{name}",
    defaults: new
    {
        controller = "Tag",
        action = "Index",
    }
    );

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        areaName: "Admin",
        name: "Admin",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
