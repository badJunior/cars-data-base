using CarsDataBase.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarsDataBase.Application.DAL.Seed
{
    public class JsonFileSeedLoader : ISeedLoader
    {
        public async Task<Car[]> LoadCarsAsync()
        {
            var cars = await JsonSerializer.DeserializeAsync<CarsList>(
                File.OpenRead("DAL/Seed/cars.json"),new JsonSerializerOptions
                ()
                { PropertyNameCaseInsensitive = true });

            if (cars == null || cars.Cars == null) 
            { 
                throw new InvalidOperationException("Failed to load cars from JSON file.");

            }
         return cars.Cars.Select(c => new Car
            {
                Firm = c.Firm,
                Model = c.Model,
                Year = c.Year,
                Power = c.Power,
                Color = c.Color,
                Price = c.Price
            }).ToArray();
        }

        public async Task<Dealer[]> LoadDealersAsync()
        {
            var dealers = await JsonSerializer.DeserializeAsync<DealerItem[]>(
                File.OpenRead("DAL/Seed/dealers.json"),new JsonSerializerOptions
                ()
                {PropertyNameCaseInsensitive = true });
            if(dealers == null)
            {
                throw new InvalidOperationException("Failed to load dealers from JSON file.");
            }

            return dealers.Select(d => new Dealer
            {
                Name = d.Name,
                City = d.City,
                Address = d.Address,
                Area = d.Area,
                Rating = d.Rating
            }).ToArray();
        }
    }
}
