using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDataBase.Application.Dtos
{
    public record SelledCarDto(CarDto Car, DealerDto Dealer);
   
}
