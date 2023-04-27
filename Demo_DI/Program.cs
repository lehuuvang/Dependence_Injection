using Domain.Enities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reponsitory.Student;
using Services.Student;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MvcContext>();
builder.Services.AddScoped<IStudentServices,StudentServices>();
builder.Services.AddScoped<IStudentReponsitory,StudentReponsitory>();
// add nofitication library
builder.Services.AddNotyf(config =>
{   config.DurationInSeconds = 8; 
    config.IsDismissable = true; 
    config.Position = NotyfPosition.TopRight;
    config.HasRippleEffect = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNotyf();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
