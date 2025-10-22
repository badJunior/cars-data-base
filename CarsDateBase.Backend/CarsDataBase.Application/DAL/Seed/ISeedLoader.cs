using CarsDataBase.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDataBase.Application.DAL.Seed
{
    internal interface ISeedLoader
    {
        Task<Dealer[]> LoadDealersAsync();
        Task<Car[]> LoadCarsAsync();
    }
}
