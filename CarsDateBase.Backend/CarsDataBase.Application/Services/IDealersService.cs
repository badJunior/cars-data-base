using CarsDataBase.Application.Dtos;

namespace CarsDataBase.Application.Services
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

}
