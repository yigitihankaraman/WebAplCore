using Microsoft.EntityFrameworkCore;
using TodoEFCore.Models;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = "Server=YIGITHOME\\SQLEXPRESS;Database=SampleDB;Trusted_Connection=True;TrustServerCertificate=true;";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<SampleDBContext>();
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
