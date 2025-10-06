using CarsDataBase.Application.DAL;
using CarsDataBase.Logic;
using Microsoft.EntityFrameworkCore;

namespace CarsDataBase.Application.DAL.Repositories

{

    public class CarsRepository : ICarsRepository
    {
        private readonly CarsDataBaseDbContext _db;
        public CarsRepository(CarsDataBaseDbContext db) => _db = db;

        public async Task<List<Car>> GetAll() => await _db.Cars.AsNoTracking().ToListAsync();

        public async Task<Car?> GetById(int id) => await _db.Cars.FindAsync(id);

        public async Task<int> Add(Car car)
        {
            _db.Cars.Add(car);
            await _db.SaveChangesAsync();
            return car.Id;
        }

        public async Task<bool> Update(Car car)
        {
            var exists = await _db.Cars.AnyAsync(c => c.Id == car.Id);
            if (!exists) return false;

            _db.Cars.Update(car);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var car = await _db.Cars.FindAsync(id);
            if (car == null) return false;

            _db.Cars.Remove(car);
            await _db.SaveChangesAsync();
            return true;
        }
    }

}
