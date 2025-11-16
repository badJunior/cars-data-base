using CarsDataBase.Application.DAL;
using CarsDataBase.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDataBase.Application.Services
{
    public class SelledCarsService : ISelledCarsService
    {
        private readonly CarsDataBaseDbContext _context;
        public SelledCarsService(CarsDataBaseDbContext context)
        {
            _context = context;
        }
        public async Task GenerateSelledCars(int carsCount)
        {
            _context.SelledCars.RemoveRange(await _context.SelledCars.ToArrayAsync());
            await  _context.SaveChangesAsync();
            var countCar = await _context.Cars.CountAsync();
            var countDealer = await _context.Dealers.CountAsync();
            var random = new Random();
            for (int i = 0; i < carsCount; i++)
            {
                var carId = random.Next(1, countCar + 1);
                var dealerId = random.Next(1, countDealer + 1);
                var car = await _context.Cars.FindAsync(carId);
                var dealer = await _context.Dealers.FindAsync(dealerId);
                var selledCar = new Logic.SelledCar
                {
                    Car = car,
                    Dealer = dealer
                };
                _context.SelledCars.Add(selledCar);

            }
         await  _context.SaveChangesAsync();
        }

        public async Task<SelledCarDto[]> GetFilteredSelledCars(SelectedFilterDto selectedFilter)
        {
            var selledCarsQuery = _context.SelledCars.Include(s => s.Car).Include(s => s.Dealer).AsQueryable();
            selledCarsQuery = selectedFilter.Color != null
                ? selledCarsQuery.Where(sc => sc.Car.Color == selectedFilter.Color)
                : selledCarsQuery;
            selledCarsQuery = selectedFilter.Dealer != null 
                ? selledCarsQuery.Where(sc => sc.Dealer.Name == selectedFilter.Dealer) 
                : selledCarsQuery;
            selledCarsQuery = selectedFilter.Make != null
                ? selledCarsQuery.Where(sc => sc.Car.Firm == selectedFilter.Make)
                : selledCarsQuery;
            selledCarsQuery = selectedFilter.Model != null
                ? selledCarsQuery.Where(sc => sc.Car.Model == selectedFilter.Model)
                : selledCarsQuery;
            selledCarsQuery = selectedFilter.MinPrice != null
                ? selledCarsQuery.Where(sc => sc.Car.Price >= selectedFilter.MinPrice)
                : selledCarsQuery;
            selledCarsQuery = selectedFilter.MaxPrice != null
                ? selledCarsQuery.Where(sc => sc.Car.Price <= selectedFilter.MaxPrice)
                : selledCarsQuery;
            selledCarsQuery = selectedFilter.MinYear != null
                ? selledCarsQuery.Where(sc => sc.Car.Year >= selectedFilter.MinYear)
                : selledCarsQuery;
           selledCarsQuery = selectedFilter.MaxYear != null
                ? selledCarsQuery.Where(sc => sc.Car.Year <= selectedFilter.MaxYear)
                : selledCarsQuery;


            var selledCars = await selledCarsQuery.ToArrayAsync();
            return selledCars.Select(sc => {
                var id = sc.Id;
                var carDto = new CarDto(
                    sc.Car.Id,
                    sc.Car.Firm,
                    sc.Car.Model,
                    sc.Car.Year,
                    sc.Car.Power,
                    sc.Car.Color,
                    sc.Car.Price
                    );
                var dealerDto = new DealerDto(
                    sc.Dealer.Id,
                    sc.Dealer.Name,
                    sc.Dealer.City,
                    sc.Dealer.Address,
                    sc.Dealer.Area,
                    sc.Dealer.Rating
                    );
                return new SelledCarDto(id, carDto, dealerDto);
            }).ToArray();
        }

        public async Task<FiltersDataDto> GetFilters()
        {
            var makes = await _context.Cars.Select(c => c.Firm).Distinct().ToArrayAsync();
            var models = await _context.Cars.Select(c => c.Model).Distinct().ToArrayAsync();
            var colors = await _context.Cars.Select(c => c.Color).Distinct().ToArrayAsync();
            var dealers = await _context.Dealers.Select(d => d.Name).Distinct().ToArrayAsync();
            var dto = new FiltersDataDto(makes, models, colors, dealers);
            return dto;
        }

        public async Task<SelledCarDto?> GetSelledCarById(int id)
        {
            var selledCar = await _context.SelledCars.Include(s => s.Car).Include(s => s.Dealer).FirstOrDefaultAsync(s => s.Id == id);
            if (selledCar == null)
            {
                return  null;
            }
            return new SelledCarDto(
                selledCar.Id,
                new CarDto(
                    selledCar.Car.Id,
                    selledCar.Car.Firm,
                    selledCar.Car.Model,
                    selledCar.Car.Year,
                    selledCar.Car.Power,
                    selledCar.Car.Color,
                    selledCar.Car.Price
                    ),
                new DealerDto(
                    selledCar.Dealer.Id,
                    selledCar.Dealer.Name,
                    selledCar.Dealer.City,
                    selledCar.Dealer.Address,
                    selledCar.Dealer.Area,
                    selledCar.Dealer.Rating
                    )
                );
        }

        public async Task<SelledCarDto[]> GetSelledCars()
        {
            var selledCars = await _context.SelledCars.Include(s=>s.Car).Include(s=>s.Dealer).ToArrayAsync();
            return selledCars.Select(sc => {
                var id = sc.Id;
                var carDto= new CarDto(
                    sc.Car.Id,
                    sc.Car.Firm,
                    sc.Car.Model,
                    sc.Car.Year,
                    sc.Car.Power,
                    sc.Car.Color,
                    sc.Car.Price
                    );
                var dealerDto = new DealerDto(
                    sc.Dealer.Id,
                    sc.Dealer.Name,
                    sc.Dealer.City,
                    sc.Dealer.Address,
                    sc.Dealer.Area,
                    sc.Dealer.Rating
                    );
                return new SelledCarDto(id,carDto,dealerDto);
            }).ToArray();
        }
    }
}
