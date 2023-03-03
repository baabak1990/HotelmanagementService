using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotelmanagment.Application.DTO.HotleDTO.Validations
{
    public class HotelDTOValidation:AbstractValidator<HotelDTo>
    {
        public HotelDTOValidation()
        {
            Include(new IHotelDtoValidation());

            RuleFor(h => h.Id)
                .GreaterThan(0).WithMessage("{PropertyName} Should be Greater Than {ComparisonValue}")
                .NotEmpty().WithMessage("{PropertyName} Can`t Be Empty")
                .NotNull().WithMessage("{PropertyName} Can`t Be Null");
        }
    }
}
