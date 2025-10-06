using CarsDateBase;
using CarsDateBase.CarsDateBase.Application;
using CarsDateBase.CarsDateBase.Application.Contracts.Repositories;
using CarsDateBase.CarsDateBase.Host;
using CarsDateBase.CarsDateBase.Logic;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IDealersRepository, DealersRepository>();
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<IDealersService, DealersService>();
builder.Services.AddScoped<ICarsService, CarsService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.RegisterDealersRoutes();
app.RegisterCarsRoutes();

app.Run();
