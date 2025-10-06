using CarsDataBase.Application.Dtos;

namespace CarsDateBase.CarsDateBase.Application.Contracts.Repositories
{
    public interface IDealersService
    {
        Task<List<DealerDto>> GetDealers();
        Task<DealerDto?> GetDealerById(int id);
        Task<int> AddDealer(NewDealerDto dto);
        Task<bool> UpdateDealer(int id, UpdateDealerDto dto);
        Task<bool> DeleteDealer(int id);
        Task<List<CarDto>?> GetDealerCars(int dealerId);
    }

    public interface ICarsService
    {
        Task<List<CarDto>> GetCars();
        Task<CarDto?> GetCarById(int id);
        Task<int> AddCar(NewCarDto dto);
        Task<bool> UpdateCar(int id, UpdateCarDto dto);
        Task<bool> DeleteCar(int id);
    }

}
