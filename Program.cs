using Microsoft.EntityFrameworkCore;
using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;
using PetShop.Petshop.Repositories.Repositories;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<PetshopDB>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Petshop");
    options.UseNpgsql(connectionString);
});

builder.Services.AddTransient<IEmployeeReposity, EmployeeRepository>();
builder.Services.AddTransient<IPetRepository, PetRepository>();

builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IPetService, PetService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//MY NIGHTMARE!!!
app.MapControllers();

app.Run();
