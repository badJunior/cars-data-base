using CarsDataBase.Application.DAL;
using CarsDataBase.Application.DAL.Seed;
using CarsDataBase.Application.Services;
using CarsDataBase.Logic;
using CarsDateBase.CarsDateBase.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CarsDataBaseDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
    .UseSeeding((context, _) =>
        {
            if (context.Set<Car>().Any<Car>())
                return;

            var loader = new JsonFileSeedLoader();
            var cars = loader.LoadCarsAsync().GetAwaiter().GetResult();
            context.Set<Car>().AddRange(cars);
            var dealers = loader.LoadDealersAsync().GetAwaiter().GetResult();
            context.Set<Dealer>().AddRange(dealers);
            context.SaveChanges();

        })
    .UseAsyncSeeding(async (context, _, cancellationToken) =>
    {
        if (context.Set<Car>().Any<Car>())
            return;

        var loader = new JsonFileSeedLoader();
        var cars = await loader.LoadCarsAsync();
        context.Set<Car>().AddRange(cars);
        var dealers = await loader.LoadDealersAsync();
        context.Set<Dealer>().AddRange(dealers);
        await context.SaveChangesAsync();

    })
);
builder.Services.AddCors((options) =>  options.AddDefaultPolicy((builder) =>  builder.WithOrigins(["http://localhost:8080", "http://localhost:80", "http://localhost:5173"]).AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddScoped<ISelledCarsService, SelledCarsService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();



app.RegisterSelledCarsRoutes();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CarsDataBaseDbContext>();
    dbContext.Database.Migrate();
}


app.Run();
