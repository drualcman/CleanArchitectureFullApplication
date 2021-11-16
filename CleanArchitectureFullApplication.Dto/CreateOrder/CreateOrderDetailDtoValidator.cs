using CleanArchitectureFullApplication.Main.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Dto.CreateOrder
{
    public class CreateOrderDetailDtoValidator :
        AbstractValidator<CreateOrderDetailDto>,
        Main.Validators.IValidator<CreateOrderDetailDto>
    {
        public CreateOrderDetailDtoValidator()
        {
            RuleFor(d => d.Quantity).GreaterThan((short)0)
                .WithMessage("Debe especificar la cantidad ordenada del producto.");
            RuleFor(d => d.UnitPrice).GreaterThan(0)
                .WithMessage("Debe especificar el precio del producto.");
        }

        ValidationResult Main.Validators.IValidator<CreateOrderDetailDto>.Validate(CreateOrderDetailDto instance)
        {
            //usando fluent validation
            FluentValidation.Results.ValidationResult result = Validate(instance);
            
            List<ValidationFailure> validations = new List<ValidationFailure>();
                validations.AddRange(result.Errors?
                .Select(e => new ValidationFailure(e.PropertyName, e.ErrorMessage)));

            //usando directamente validador manual
            if (instance.ProdcutId <= 0)
            {
                validations.Add(new ValidationFailure("ProductId", 
                    "Debe especificar el identificador del producto."));
            }

            return new ValidationResult(validations);
        }
    }
}
