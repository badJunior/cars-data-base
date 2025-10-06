using CarsDataBase.Logic;
using Microsoft.EntityFrameworkCore;

namespace CarsDataBase.Application.DAL.Repositories

{
    public class DealersRepository : IDealersRepository
    {
        private readonly CarsDataBaseDbContext _db;
        public DealersRepository(CarsDataBaseDbContext db) => _db = db;

        public async Task<List<Dealer>> GetAll() => await _db.Dealers.AsNoTracking().ToListAsync();

        public async Task<Dealer?> GetById(int id) =>
            await _db.Dealers.Include(d => d.Cars).FirstOrDefaultAsync(d => d.Id == id);

        public async Task<int> Add(Dealer dealer)
        {
            _db.Dealers.Add(dealer);
            await _db.SaveChangesAsync();
            return dealer.Id;
        }

        public async Task<bool> Update(Dealer dealer)
        {
            var exists = await _db.Dealers.AnyAsync(d => d.Id == dealer.Id);
            if (!exists) return false;

            _db.Dealers.Update(dealer);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var dealer = await _db.Dealers.FindAsync(id);
            if (dealer == null) return false;

            _db.Dealers.Remove(dealer);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Car>> GetCarsByDealer(int dealerId) =>
            await _db.Cars.Where(c => c.DealerId == dealerId).ToListAsync();
    }

}
