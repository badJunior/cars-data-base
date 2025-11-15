using CarsDataBase.Application.Dtos;
using CarsDataBase.Application.Services;

namespace CarsDateBase.CarsDateBase.Host
{
    public static class RoutesExtensions
    {
      

        public static void RegisterSelledCarsRoutes(this WebApplication app)
        {
           var group = app.MapGroup("/selled-cars");
           group.MapGet("", async (ISelledCarsService service) =>
           {
               var selledCars = await service.GetSelledCars();
               return Results.Ok(new GetSelledCarsResponse(selledCars));

           });
            group.MapPost("", async (GenerateSelledCarsRequest request, ISelledCarsService service) =>
            {
                await service.GenerateSelledCars(request.CarsCount);
                return Results.Ok();
            });
        }

        public static void RegisterFiltersRoutes(this WebApplication app)
        {
            var group = app.MapGroup("/filters");
            group.MapGet("", async (ISelledCarsService service) =>
            {
                var filtersData = await service.GetFilters();
                return Results.Ok(new GetFiltersResponse(filtersData.Makes,filtersData.Models, filtersData.Colors, filtersData.Dealers));

            });
            
        }
    }


    public record GetFiltersResponse(string[] Makes, string[] Models, string[] Colors, string[] Dealers);
    public record GetSelledCarsResponse(SelledCarDto[] SelledCars); 

    public record GenerateSelledCarsRequest(int CarsCount);
    
}
