using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;
using PetShop.Petshop.Repositories.Repositories;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.services.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

var configuration = builder.Configuration;

var services = builder.Services;

var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOption>();
var key = Encoding.ASCII.GetBytes(tokenOptions.Secret);

services.Configure<TokenOption>(configuration.GetSection("TokenOptions"));

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenOptions.Secret)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = tokenOptions.AuthenticatorIssuer,
        ValidAudience = tokenOptions.AuthenticatorTokenProvider,
        ClockSkew = TimeSpan.Zero
    };
});

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

services.AddHttpContextAccessor();

services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "PetShop API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter your JWT token in the format: Bearer {your token}",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    options.DocumentFilter<HideEndpointsFilter>();
});

services.AddControllers();
services.AddEndpointsApiExplorer();

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
