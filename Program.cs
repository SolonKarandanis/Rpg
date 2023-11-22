global using rpg.Models;
global using rpg.Services.Characters;
global using rpg.Services.Auth;
global using rpg.Services.Users;
global using rpg.Services.Weapons;
global using rpg.Services.Skills;
global using Rpg.Services.Fights;
global using rpg.Data.Repositories.Users;
global using rpg.Data.Repositories.Weapons;
global using rpg.Data.Repositories.Characters;
global using rpg.Data.Repositories.Skills;
global using rpg.Dtos.Characters;
global using rpg.Dtos.Skills;
global using rpg.Dtos.Weapons;
global using rpg.Dtos.Backpacks;
global using rpg.Dtos.Factions;
global using rpg.Dtos.Users;
global using rpg.Dtos.Web;
global using rpg.Dtos.Fights;
global using rpg.Dtos.Skills;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Rpg.Utils;
using rpg;
using rpg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using rpg.Identity;
using Serilog;









var builder = WebApplication.CreateBuilder(args);

// Build a config object, using env vars and JSON providers.
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddDbContextPool<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>{
    x.TokenValidationParameters = new TokenValidationParameters{
        ValidIssuer = config["JwtSettings::Issuer"],
        ValidAudience = config["JwtSettings::Audience"],
        ValidateIssuer= true,
        ValidateAudience= true,
        ValidateLifetime= true,
        ValidateIssuerSigningKey= true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!))
    };
});

builder.Services.AddAuthorization(options => 
{
    options.AddPolicy(IdentityData.AdminUserPolicyName, p=> 
        p.RequireClaim(IdentityData.AdminUserClaimName,"true"));
});

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});
// Repositories
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICharacterRepository,CharacterRepository>();
builder.Services.AddScoped<IWeaponRepository,WeaponRepository>();
builder.Services.AddScoped<ISkillRepository,SkillRepository>();

//Services
builder.Services.AddScoped<ICharacterService,CharacterService>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IUsersService,UsersService>();
builder.Services.AddScoped<IWeaponService,WeaponService>();
builder.Services.AddScoped<ISkillService,SkillService>();
builder.Services.AddScoped<IFightService,FightService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseApiVersioning();

app.UseAuthorization();

app.MapControllers();

app.Run();
