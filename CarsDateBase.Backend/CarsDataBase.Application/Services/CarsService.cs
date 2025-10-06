using CarsDataBase.Application.DAL.Repositories;
using CarsDataBase.Application.Dtos;
using CarsDataBase.Logic;

namespace CarsDataBase.Application.Services
{

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
