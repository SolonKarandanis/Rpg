global using rpg.Models;
global using rpg.Services.CharacterService;
global using rpg.Dtos.Character;
global using rpg.Dtos.Skill;
global using rpg.Dtos.Weapon;
global using rpg.Dtos.Backpack;
global using rpg.Dtos.Faction;
global using rpg.Dtos.User;
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
builder.Services.AddScoped<ICharacterService,CharacterService>();

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
