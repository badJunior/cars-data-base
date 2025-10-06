namespace CarsDataBase.Application.Dtos
{
    public record NewDealerDto(
        string Name,
        string? City,
        string? Address,
        string? Area,
        double Rating
    );

}
