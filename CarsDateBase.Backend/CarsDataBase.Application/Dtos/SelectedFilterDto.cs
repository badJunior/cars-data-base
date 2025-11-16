using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDataBase.Application.Dtos
{
    public record SelectedFilterDto(string? Color, string? Dealer, string? Make, string? Model, int? MinPrice, int? MaxPrice, int? MinYear, int? MaxYear);
   
}
