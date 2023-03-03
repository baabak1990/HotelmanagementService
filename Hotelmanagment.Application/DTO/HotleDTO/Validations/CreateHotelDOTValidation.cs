using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotelmanagment.Application.DTO.HotleDTO.Validations
{
    public class CreateHotelDOTValidation:AbstractValidator<CreateHotelDTo>
    {
        public CreateHotelDOTValidation()
        {
            Include(new IHotelDtoValidation());
        }
    }
}
