namespace CarsDataBase.Application.Dtos
{
    public record UpdateDealerDto(
        string? Name,
        string? City,
        string? Address,
        string? Area,
        double? Rating
    );

}
