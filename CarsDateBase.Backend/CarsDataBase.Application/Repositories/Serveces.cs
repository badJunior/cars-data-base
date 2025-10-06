using CarsDataBase.Application.Dtos;

namespace CarsDateBase.CarsDateBase.Application.Contracts.Repositories
{
    public class DealersService : IDealersService
    {
        private readonly IDealersRepository _repo;
        public DealersService(IDealersRepository repo) => _repo = repo;

        public async Task<List<DealerDto>> GetDealers()
        {
            var dealers = await _repo.GetAll();
            return dealers.Select(d => new DealerDto(
                d.Id, d.Name, d.City, d.Address, d.Area, d.Rating,
                d.Cars?.Select(c => new CarDto(c.Id, c.Firm, c.Model, c.Year, c.Power, c.Color, c.Price, c.DealerId, d.Name)).ToList()
            )).ToList();
        }

        public async Task<DealerDto?> GetDealerById(int id)
        {
            var dealer = await _repo.GetById(id);
            if (dealer == null) return null;

            return new DealerDto(
                dealer.Id, dealer.Name, dealer.City, dealer.Address, dealer.Area, dealer.Rating,
                dealer.Cars?.Select(c => new CarDto(c.Id, c.Firm, c.Model, c.Year, c.Power, c.Color, c.Price, c.DealerId, dealer.Name)).ToList()
            );
        }

        public async Task<int> AddDealer(NewDealerDto dto)
        {
            var dealer = new Dealer
            {
                Name = dto.Name,
                City = dto.City,
                Address = dto.Address,
                Area = dto.Area,
                Rating = dto.Rating
            };

            return await _repo.Add(dealer);
        }

        public async Task<bool> UpdateDealer(int id, UpdateDealerDto dto)
        {
            var dealer = await _repo.GetById(id);
            if (dealer == null) return false;

            if (dto.Name != null) dealer.Name = dto.Name;
            if (dto.City != null) dealer.City = dto.City;
            if (dto.Address != null) dealer.Address = dto.Address;
            if (dto.Area != null) dealer.Area = dto.Area;
            if (dto.Rating.HasValue) dealer.Rating = dto.Rating.Value;

            return await _repo.Update(dealer);
        }

        public async Task<bool> DeleteDealer(int id) => await _repo.Delete(id);

        public async Task<List<CarDto>?> GetDealerCars(int dealerId)
        {
            var cars = await _repo.GetCarsByDealer(dealerId);
            if (cars == null) return null;

            return cars.Select(c => new CarDto(c.Id, c.Firm, c.Model, c.Year, c.Power, c.Color, c.Price, c.DealerId, null)).ToList();
        }
    }

    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _repo;
        public CarsService(ICarsRepository repo) => _repo = repo;

        public async Task<List<CarDto>> GetCars()
        {
            var cars = await _repo.GetAll();
            return cars.Select(c => new CarDto(c.Id, c.Firm, c.Model, c.Year, c.Power, c.Color, c.Price, c.DealerId, null)).ToList();
        }

        public async Task<CarDto?> GetCarById(int id)
        {
            var car = await _repo.GetById(id);
            if (car == null) return null;

            return new CarDto(car.Id, car.Firm, car.Model, car.Year, car.Power, car.Color, car.Price, car.DealerId, null);
        }

        public async Task<int> AddCar(NewCarDto dto)
        {
            var car = new Car
            {
                Firm = dto.Firm,
                Model = dto.Model,
                Year = dto.Year,
                Power = dto.Power,
                Color = dto.Color,
                Price = dto.Price,
                DealerId = dto.DealerId
            };

            return await _repo.Add(car);
        }

        public async Task<bool> UpdateCar(int id, UpdateCarDto dto)
        {
            var car = await _repo.GetById(id);
            if (car == null) return false;

            if (dto.Firm != null) car.Firm = dto.Firm;
            if (dto.Model != null) car.Model = dto.Model;
            if (dto.Year.HasValue) car.Year = dto.Year.Value;
            if (dto.Power.HasValue) car.Power = dto.Power.Value;
            if (dto.Color != null) car.Color = dto.Color;
            if (dto.Price.HasValue) car.Price = dto.Price.Value;
            if (dto.DealerId.HasValue) car.DealerId = dto.DealerId.Value;

            return await _repo.Update(car);
        }

        public async Task<bool> DeleteCar(int id) => await _repo.Delete(id);
    }

}
