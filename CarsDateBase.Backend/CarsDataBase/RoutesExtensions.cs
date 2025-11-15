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

            group.MapGet("{id}", async (int id,ISelledCarsService service) =>
            {
                var selledCar = await service.GetSelledCarById(id);
                if (selledCar != null)
                    return Results.Ok(new GetSelledCarByIdResponse(selledCar));
                else return Results.NotFound();

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

        public static void RegisterFilteredSelledCarsRoutes(this WebApplication app)
        {
            var group = app.MapGroup("/filtered-selled-cars");
            
            group.MapPost("", async (GetFilteredCarsRequest request, ISelledCarsService service) =>
            {var filter = request.SelectedFilter;
                var selledCars = await service.GetFilteredSelledCars(new CarsDataBase.Application.Dtos.SelectedFilterDto(filter.Color,filter.Dealer,filter.Make,filter.Model));
                return Results.Ok(new GetFilteredCarsResponse(selledCars));
               
            });
        }

    }


    public record GetFiltersResponse(string[] Makes, string[] Models, string[] Colors, string[] Dealers);
    public record GetSelledCarsResponse(SelledCarDto[] SelledCars); 

    public record GenerateSelledCarsRequest(int CarsCount);

    public record GetFilteredCarsRequest(SelectedFilterDto SelectedFilter);
    
    public record SelectedFilterDto(string? Color, string? Dealer, string? Make, string? Model);

    public record GetFilteredCarsResponse(SelledCarDto[] FilteredCars);

    public record GetSelledCarByIdResponse(SelledCarDto SelledCar);
}
