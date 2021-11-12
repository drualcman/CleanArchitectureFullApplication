using CleanArchitectureFullApplication.Main.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; }
        public ValidationException() { }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception innerException) :
            base(message, innerException)  { }

        public ValidationException(IEnumerable<ValidationFailure> errors) => Errors = errors;
    }
}
