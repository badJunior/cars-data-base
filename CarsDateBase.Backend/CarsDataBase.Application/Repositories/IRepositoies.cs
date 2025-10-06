using CarsDataBase.Logic;

namespace CarsDateBase.CarsDateBase.Application.Contracts.Repositories
{
    public interface IDealersRepository
    {
        Task<List<Dealer>> GetAll();
        Task<Dealer?> GetById(int id);
        Task<int> Add(Dealer dealer);
        Task<bool> Update(Dealer dealer);
        Task<bool> Delete(int id);
        Task<List<Car>> GetCarsByDealer(int dealerId);
    }

    public interface ICarsRepository
    {
        Task<List<Car>> GetAll();
        Task<Car?> GetById(int id);
        Task<int> Add(Car car);
        Task<bool> Update(Car car);
        Task<bool> Delete(int id);
    }

}
