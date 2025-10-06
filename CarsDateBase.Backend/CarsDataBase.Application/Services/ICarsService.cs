using CarsDataBase.Application.Dtos;

namespace CarsDataBase.Application.Services
{

    public interface ICarsService
    {
        Task<List<CarDto>> GetCars();
        Task<CarDto?> GetCarById(int id);
        Task<int> AddCar(NewCarDto dto);
        Task<bool> UpdateCar(int id, UpdateCarDto dto);
        Task<bool> DeleteCar(int id);
    }

}
