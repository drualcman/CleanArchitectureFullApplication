using CleanArchitectureFullApplication.Main.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Dto.CreateOrder
{
    public class CreateOrderDtoValidator :
        AbstractValidator<CreateOrderDto>, Main.Validators.IValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("Debe proporcionar el identificador del cliente")
                .Length(5).WithMessage("La longitud del identificador debe de ser 5.");
            RuleFor(a => a.ShipAddress).NotEmpty().WithMessage("Debe de especificar la direccion de envio.")
                .MaximumLength(60).WithMessage("Direccion demasiado grande. No puede tener mas de 60 caracteres.");
            RuleFor(a => a.ShipCity).NotEmpty().WithMessage("Debe de especificar la ciudad de envio.")
                .MaximumLength(15).WithMessage("Ciudad demasiado grande. No puede tener mas de 15 caracteres.")
                .MinimumLength(3).WithMessage("La ciudad debe de tener mas de 3 caracteres.");
            RuleFor(a => a.ShipCountry).NotEmpty().WithMessage("Debe de especificar el pais de envio.")
                .MaximumLength(15).WithMessage("Pais demasiado grande. No puede tener mas de 15 caracteres.")
                .MinimumLength(3).WithMessage("El pais debe de tener mas de 3 caracteres.");
            RuleFor(a => a.ShipPostalCode).MaximumLength(10).WithMessage("El codigo postal no puede tener mas de 10 caracteres.");
            RuleFor(p => p.OrderDetails).NotNull().WithMessage("Debe de especificar los productos de la orden")
                .NotEmpty().WithMessage("Debe de especificar los productos de la orden");
            RuleForEach(d => d.OrderDetails).SetValidator(new CreateOrderDetailDtoValidator());
        }

        ValidationResult Main.Validators.IValidator<CreateOrderDto>.Validate(CreateOrderDto instance)
        {
            FluentValidation.Results.ValidationResult result = Validate(instance);
            return new ValidationResult(result?.Errors
                .Select(e => new ValidationFailure(e.PropertyName, e.ErrorMessage)));
        }
    }
}
