using _1.DATA.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(_1.DATA.IRepositories.IAllRepositories<>), typeof(_1.DATA.Repositories.AllRepositories<>));
builder.Services.AddDbContext<CuahangDbContext>(c => c.UseSqlServer("Server=HDGNGUYENTIEN\\SQLEXPRESS;Database=DATN_UD08_Database;Trusted_Connection=True;"));

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
