using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using HumanResourcesApp.Application.Extensions;
using HumanResourcesApp.Application.IoC;
using HumanResourcesApp.Application.Models.VMs;
using HumanResourcesApp.Infrastructure.Context;
using HumanResourcesApp.MVC.Models.SeedDataFolder;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Loader;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HRDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("HrConnString"));
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
});

builder.Services.AddScoped<IValidator<UpdateManagerVM>, PhoneNumberExtension>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

SeedData.Seed(app); app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
