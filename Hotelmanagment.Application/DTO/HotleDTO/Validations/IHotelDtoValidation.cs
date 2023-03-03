using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotelmanagment.Application.DTO.HotleDTO.Validations
{
    public class IHotelDtoValidation : AbstractValidator<IHotelDTo>
    {
        public IHotelDtoValidation()
        {
            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("{PropertyName} Can`t be Empty")
                .NotNull().WithMessage("{PropertyName} Can`t be Empty")
                .MaximumLength(350).WithMessage("{ PropertyName} Can`t be more than {comparisonValue}");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} Can`t be Empty")
                .NotNull().WithMessage("{PropertyName} Can`t be Empty")
                .MaximumLength(50).WithMessage("{ PropertyName} Can`t be more than {comparisonValue}");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} Can`t be Empty")
                .NotNull().WithMessage("{PropertyName} Can`t be Empty")
                .MaximumLength(11).WithMessage("{ PropertyName} Can`t be more than {comparisonValue}")
                .Matches("^(\\+98|0)?9\\d{9}$")
                .WithMessage("{ PropertyName} Should Obey the rule of Ir Mobile Numbers");

            RuleFor(c => c.Rate)
                .GreaterThan(0).WithMessage("{PropertyName} Should be greater Than {ComparisonValue}")
                .LessThan(6).WithMessage("{PropertyName} Should be Lesser Than {ComparisonValue}");

            RuleFor(c => c.CountryId)
                .NotNull().WithMessage("{PropertyName} Can`t be Null")
                .NotEmpty().WithMessage("{PropertyName} Can`t be Empty")
                .GreaterThan(0).WithMessage("{PropertyName} Should be Greater Than {comparisonValue}");

        }
    }
}
