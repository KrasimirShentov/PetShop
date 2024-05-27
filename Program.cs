using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;
using PetShop.Petshop.Repositories.Repositories;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.services.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Retrieve services and configuration
var services = builder.Services;
var configuration = builder.Configuration;

var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOption>();
var key = Encoding.ASCII.GetBytes(tokenOptions.Secret);

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.AuthenticatorIssuer,
        ValidAudience = tokenOptions.AuthenticatorTokenProvider,
        ClockSkew = TimeSpan.Zero
    };
});

services.Configure<TokenOption>(configuration.GetSection("TokenOptions"));

services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<PetshopDB>()
    .AddDefaultTokenProviders();

services.AddDbContext<PetshopDB>(options =>
{
    var connectionString = configuration.GetConnectionString("Petshop");
    options.UseNpgsql(connectionString);
});

services.AddTransient<IEmployeeReposity, EmployeeRepository>();
services.AddTransient<IPetRepository, PetRepository>();
services.AddTransient<IEmployeeService, EmployeeService>();
services.AddTransient<IPetService, PetService>();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
