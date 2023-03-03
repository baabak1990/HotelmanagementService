using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotelmanagment.Application.DTO.CountyDTO.Validations
{
    public class CreateCountryDTOValidations:AbstractValidator<CreateCountryDTO>
    {
        public CreateCountryDTOValidations()
        {
            Include(new ICountryDtoValidation());
        }
    }
}
