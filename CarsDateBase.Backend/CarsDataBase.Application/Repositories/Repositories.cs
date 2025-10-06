namespace CarsDateBase.CarsDateBase.Application.Contracts.Repositories

{
   

    public class DealersRepository : IDealersRepository
    {
        private readonly AppDbContext _db;
        public DealersRepository(AppDbContext db) => _db = db;

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

    public class CarsRepository : ICarsRepository
    {
        private readonly AppDbContext _db;
        public CarsRepository(AppDbContext db) => _db = db;

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
