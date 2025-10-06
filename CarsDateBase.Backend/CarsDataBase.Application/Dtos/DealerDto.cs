namespace CarsDataBase.Application.Dtos
{
    public record DealerDto(
      int Id,
      string Name,
      string? City,
      string? Address,
      string? Area,
      double Rating,
      List<CarDto>? Cars
  );

}
