using CleanArchitectureFullApplication.Main.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WebExceptionPresenters.ExceptionHandlers
{
    class GeneralExceptionHandler : IExceptionHandler<GeneralException>
    {
        public ValueTask<ProblemDetails> Handler(GeneralException exception)
        {
            throw new NotImplementedException();
        }
    }
}
