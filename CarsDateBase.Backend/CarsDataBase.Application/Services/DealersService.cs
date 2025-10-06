using CarsDataBase.Application.DAL.Repositories;
using CarsDataBase.Application.Dtos;
using CarsDataBase.Logic;

namespace CarsDataBase.Application.Services
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

}
