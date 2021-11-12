using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Validators
{
    public class ValidationResult
    {
        public IEnumerable<ValidationFailure> Errors { get; }
        public ValidationResult(IEnumerable<ValidationFailure> errors) => Errors = errors;
        public bool IsValid => Errors is null || !Errors.Any();
    }
}
