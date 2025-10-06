using CarsDataBase.Application.DAL;
using CarsDataBase.Application.DAL.Repositories;
using CarsDataBase.Application.Services;
using CarsDateBase.CarsDateBase.Host;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CarsDataBaseDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));


builder.Services.AddScoped<IDealersRepository, DealersRepository>();
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<IDealersService, DealersService>();
builder.Services.AddScoped<ICarsService, CarsService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();



app.RegisterDealersRoutes();
app.RegisterCarsRoutes();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CarsDataBaseDbContext>();
    dbContext.Database.Migrate(); 
}
app.Run();
