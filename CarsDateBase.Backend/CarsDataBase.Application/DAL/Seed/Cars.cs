using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDataBase.Application.DAL.Seed
{
    internal class CarsList
    {
        public CarItem[] Cars { get; set; }
    }

    internal class CarItem
    {
        public string Firm { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
