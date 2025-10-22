namespace CarsDataBase.Application.Dtos
{
    public record CarDto(
    int Id,
    string Firm,
    string Model,
    int Year,
    int Power,
    string? Color,
    decimal Price
    
);

}
