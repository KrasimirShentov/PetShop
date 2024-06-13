using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<TokenOptions>(configuration.GetSection("TokenOptions"));

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
services.AddTransient<IUserRepository, UserRepository>();

services.AddTransient<IEmployeeService, EmployeeService>();
services.AddTransient<IPetService, PetService>();
services.AddTransient<IUserService, UserService>();

services.AddControllers();
services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["TokenOptions:Audience"],
            ValidIssuer = configuration["TokenOptions:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(configuration["TokenOptions:Key"]))
        };
    });

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                Array.Empty<string>()
            }
        });
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();