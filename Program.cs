global using rpg.Models;
global using rpg.Services.Characters;
global using rpg.Services.Auth;
global using rpg.Services.Users;
global using rpg.Data.Repositories.Users;
global using rpg.Data.Repositories.Weapons;
global using rpg.Data.Repositories.Characters;
global using rpg.Dtos.Characters;
global using rpg.Dtos.Skills;
global using rpg.Dtos.Weapons;
global using rpg.Dtos.Backpacks;
global using rpg.Dtos.Factions;
global using rpg.Dtos.Users;
global using rpg.Dtos.Web;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
using rpg;
using rpg.Data;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// Repositories
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddScoped<IWeaponRepository,WeaponRepository>();

//Services
builder.Services.AddScoped<ICharacterService,CharacterService>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IUsersService,UsersService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
