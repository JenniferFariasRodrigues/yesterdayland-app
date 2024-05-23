using Microsoft.EntityFrameworkCore;
using YesterdaylandAPI.Controllers;
using YesterdaylandAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the data base
builder.Services.AddDbContext<YesterdaylandContext>(options =>
    options.UseSqlServer("DefaultConnection"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
