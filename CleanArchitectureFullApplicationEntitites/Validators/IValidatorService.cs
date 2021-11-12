using CleanArchitectureFullApplication.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Validators
{
    public interface IValidatorService<Model>
    {
        void Validate(Model instance, IEnumerable<IValidator<Model>> validators, IApplicationStatusLogger logger);
    }
}
