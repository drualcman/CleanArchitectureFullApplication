using CleanArchitectureFullApplication.Main.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Dto.GetOrdersByDate
{
    public class GetOrdersByDateDtoValidator : AbstractValidator<GetOrdersByDateDto>,
        Main.Validators.IValidator<GetOrdersByDateDto>
    {
        public GetOrdersByDateDtoValidator()
        {
            RuleFor(d => d.OrderDate)
                .GreaterThan(DateTime.MinValue).WithMessage("Debe proporcionar la fecha a consultar.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Debe proporcionar una fecha menor o igual a la fecha actual");
        }

        ValidationResult Main.Validators.IValidator<GetOrdersByDateDto>.Validate(GetOrdersByDateDto instance)
        {
            FluentValidation.Results.ValidationResult result = Validate(instance);
            return new ValidationResult(result?.Errors
                .Select(e => new ValidationFailure(e.PropertyName, e.ErrorMessage)));
        }
    }
}
