using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDataBase.Application.Dtos
{
    public record FiltersDataDto(string[] Makes, string[] Models, string[] Colors, string[] Dealers);
}
