using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotelmanagment.Application.DTO.CountyDTO.Validations
{
    public class ICountryDtoValidation:AbstractValidator<ICountryDTO>
    {
        public ICountryDtoValidation()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("{PropertyName}  can`t be Null ")
                .NotEmpty().WithMessage("{PropertyName}  can`t be Empty ")
                .MaximumLength(50).WithMessage("{PropertyName} Can`t has More than {ComparisonValues} Letters");

            RuleFor(c => c.ShortName)
                .NotNull().WithMessage("{PropertyName}  can`t be Null ")
                .NotEmpty().WithMessage("{PropertyName}  can`t be Empty ")
                .MaximumLength(5).WithMessage("{PropertyName} Can`t has More than {ComparisonValues} Letters");
        }
    }
}
