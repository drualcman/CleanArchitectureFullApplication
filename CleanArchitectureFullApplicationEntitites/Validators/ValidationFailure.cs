using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Validators
{
    public class ValidationFailure
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public ValidationFailure(string propertyName, string errorMessage) =>
            (PropertyName, ErrorMessage) = (propertyName, errorMessage);
    }
}
