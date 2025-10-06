using CarsDataBase.Logic;

namespace CarsDataBase.Application.DAL.Repositories
{

    public interface ICarsRepository
    {
        Task<List<Car>> GetAll();
        Task<Car?> GetById(int id);
        Task<int> Add(Car car);
        Task<bool> Update(Car car);
        Task<bool> Delete(int id);
    }

}
