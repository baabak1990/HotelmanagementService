using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotelmanagment.Application.DTO.CountyDTO.Validations
{
    public class CountryDToValidation : AbstractValidator<CountryDTO>
    {
        public CountryDToValidation()
        {
            Include(new ICountryDtoValidation());
        }
    }
}
