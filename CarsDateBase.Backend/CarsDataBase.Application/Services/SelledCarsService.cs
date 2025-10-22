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

        public async Task<SelledCarDto[]> GetSelledCars()
        {
            var selledCars = await _context.SelledCars.Include(s=>s.Car).Include(s=>s.Dealer).ToArrayAsync();
            return selledCars.Select(sc => {
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
                return new SelledCarDto(carDto,dealerDto);
            }).ToArray();
        }
    }
}
