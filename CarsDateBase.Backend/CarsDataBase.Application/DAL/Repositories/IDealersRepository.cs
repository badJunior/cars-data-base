using CarsDataBase.Logic;

namespace CarsDataBase.Application.DAL.Repositories
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

}
