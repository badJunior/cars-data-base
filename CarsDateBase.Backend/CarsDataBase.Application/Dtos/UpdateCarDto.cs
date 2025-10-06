namespace CarsDataBase.Application.Dtos
{

    public record UpdateCarDto(
        string? Firm,
        string? Model,
        int? Year,
        int? Power,
        string? Color,
        int? Price,
        int? DealerId
    );

}
