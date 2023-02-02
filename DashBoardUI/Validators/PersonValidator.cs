using FluentValidation;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardUI.Validators
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Length ({TotalLength}) of {PropertyName}  Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName}  Contains invalid characters");

            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Length ({TotalLength}) of {PropertyName}  Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName}  Contains invalid characters");
        }

        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
