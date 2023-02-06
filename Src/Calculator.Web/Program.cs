using Calculator.Domain.Contracts;
using Calculator.Service.Calculator;
using Calculator.Web.Middleware;
using Calculator.Web.Models.Calculator;
using Calculator.Web.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
builder.Services.AddTransient<IValidator<CalculatorViewModel>, CalculatorViewModelValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Index}/{id?}");

app.Run();
