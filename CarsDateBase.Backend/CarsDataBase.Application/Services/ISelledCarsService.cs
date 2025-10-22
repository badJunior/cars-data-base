using CarsDataBase.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDataBase.Application.Services
{
    public interface ISelledCarsService
    {
        Task GenerateSelledCars(int carsCount);
        Task<SelledCarDto[]> GetSelledCars();
    }
}
