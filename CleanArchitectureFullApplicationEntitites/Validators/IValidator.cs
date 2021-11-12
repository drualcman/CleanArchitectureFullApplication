using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Validators
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T instance);
    }
}
