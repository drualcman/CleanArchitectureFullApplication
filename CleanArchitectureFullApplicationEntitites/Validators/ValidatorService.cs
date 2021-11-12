using CleanArchitectureFullApplication.Main.Exceptions;
using CleanArchitectureFullApplication.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Validators
{
    public class ValidatorService<Model> : IValidatorService<Model>
    {
        public void Validate(Model instance, 
            IEnumerable<IValidator<Model>> validators, 
            IApplicationStatusLogger logger = null)
        {
            List<ValidationFailure> failures = validators
                .Select(v=> v.Validate(instance))
                .SelectMany(r=> r.Errors)
                .Where(f=> f is not null)
                .ToList();
            if (failures.Any())
            {
                if (logger is not null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("Error en la entrada de datos");
                    foreach (ValidationFailure failure in failures)
                    {
                        stringBuilder.AppendLine($"{failure.PropertyName}:{failure.ErrorMessage}");
                    }
                    logger.Log(stringBuilder.ToString());
                }
                throw new ValidationException(failures);
            }
        }
    }
}
