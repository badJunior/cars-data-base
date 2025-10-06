using CarsDataBase.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDataBase.Application.DAL
{
    public class CarsDataBaseDbContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealer> Dealers { get; set; }

        public CarsDataBaseDbContext(DbContextOptions<CarsDataBaseDbContext> options):base(options) { }
    }
}
