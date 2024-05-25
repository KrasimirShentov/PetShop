using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;
using PetShop.Petshop.Repositories.Repositories;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.services.Services;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

var services = builder.Services;
var configuration = builder.Configuration;

var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOption>();
var key = Encoding.ASCII.GetBytes(tokenOptions.Secret);

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.AuthenticatorIssuer,
            ValidAudience = tokenOptions.AuthenticatorTokenProvider,
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
    });


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
