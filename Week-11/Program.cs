using Microsoft.EntityFrameworkCore;
using System;
using Week11.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//önce db context
builder.Services.AddDbContext<DepoDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ConnectionString"),
        new MySqlServerVersion(new Version(8, 0, 0))
));


builder.Services.AddScoped<VeriTabanýServis>();

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
