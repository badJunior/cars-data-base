using CarsDateBase.CarsDateBase.Application.Contracts;
using CarsDateBase.CarsDateBase.Application.Contracts.Repositories;

namespace CarsDateBase.CarsDateBase.Host
{
    public static class RoutesExtensions
    {
        public static void RegisterDealersRoutes(this WebApplication app)
        {
            var dealersGroup = app.MapGroup("/dealers");

            // Получить всех дилеров
            dealersGroup.MapGet("", async (IDealersService service) =>
            {
                var dealers = await service.GetDealers();
                return Results.Ok(dealers);
            });

            // Получить дилера по Id
            dealersGroup.MapGet("{dealerId:int}", async (int dealerId, IDealersService service) =>
            {
                var dealer = await service.GetDealerById(dealerId);
                return dealer is null ? Results.NotFound() : Results.Ok(dealer);
            });

            // Создать нового дилера
            dealersGroup.MapPost("", async (NewDealerDto newDealer, IDealersService service) =>
            {
                var dealerId = await service.AddDealer(newDealer);
                return Results.Created($"/dealers/{dealerId}", new { id = dealerId });
            });

            // Обновить существующего дилера
            dealersGroup.MapPatch("{dealerId:int}", async (int dealerId, UpdateDealerDto updatedDealer, IDealersService service) =>
            {
                var success = await service.UpdateDealer(dealerId, updatedDealer);
                return success ? Results.Ok() : Results.NotFound();
            });

            // Удалить дилера
            dealersGroup.MapDelete("{dealerId:int}", async (int dealerId, IDealersService service) =>
            {
                var success = await service.DeleteDealer(dealerId);
                return success ? Results.NoContent() : Results.NotFound();
            });

            // Получить машины конкретного дилера
            dealersGroup.MapGet("{dealerId:int}/cars", async (int dealerId, IDealersService service) =>
            {
                var cars = await service.GetDealerCars(dealerId);
                return cars is null ? Results.NotFound() : Results.Ok(cars);
            });
        }
        public static void RegisterCarsRoutes(this WebApplication app)
        {
            var carsGroup = app.MapGroup("/cars");

            // Получить все машины
            carsGroup.MapGet("", async (ICarsService service) =>
            {
                var cars = await service.GetCars();
                return Results.Ok(cars);
            });

            // Получить машину по Id
            carsGroup.MapGet("{carId:int}", async (int carId, ICarsService service) =>
            {
                var car = await service.GetCarById(carId);
                return car is null ? Results.NotFound() : Results.Ok(car);
            });

            // Создать машину
            carsGroup.MapPost("", async (NewCarDto newCar, ICarsService service) =>
            {
                var carId = await service.AddCar(newCar);
                return Results.Created($"/cars/{carId}", new { id = carId });
            });

            // Обновить машину
            carsGroup.MapPatch("{carId:int}", async (int carId, UpdateCarDto updatedCar, ICarsService service) =>
            {
                var success = await service.UpdateCar(carId, updatedCar);
                return success ? Results.Ok() : Results.NotFound();
            });

            // Удалить машину
            carsGroup.MapDelete("{carId:int}", async (int carId, ICarsService service) =>
            {
                var success = await service.DeleteCar(carId);
                return success ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
