using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotelmanagment.Application.DTO.UserDTO.Validation
{
    public class LoginDToValidation:AbstractValidator<LoginDTO>
    {
        public LoginDToValidation()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} can`t be Empty")
                .NotNull().WithMessage("{PropertyName} can`t be Null")
                .EmailAddress().WithMessage("{PropertyName} Should be Like somename@somename.somedomin")
                .MaximumLength(200).WithMessage("{PropertyName} can`t has more than {comparisonValue}");

            RuleFor(u => u.Password)
                .MinimumLength(8).WithMessage("{PropertyName} Can`t Be Less than {comparisonValue} letter").NotEmpty()
                .WithMessage("{PropertyName} can`t be Empty")
                .NotNull().WithMessage("{PropertyName} can`t be Null");
        }
    }
}
