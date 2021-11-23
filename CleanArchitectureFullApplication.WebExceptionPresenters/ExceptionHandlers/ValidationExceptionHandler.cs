using CleanArchitectureFullApplication.Main.Exceptions;
using CleanArchitectureFullApplication.Main.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WebExceptionPresenters.ExceptionHandlers
{
    class ValidationExceptionHandler : IExceptionHandler<ValidationException>
    {
        public ValueTask<ProblemDetails> Handle(ValidationException exception)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status406NotAcceptable,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.6",
                Title = "Error en los datos de entrada",
                Detail = exception.Message
            };
            Dictionary<string, string> extensions = new Dictionary<string, string>();
            foreach (ValidationFailure failure in exception.Errors)
            {
                if (extensions.ContainsKey(failure.PropertyName)) extensions[failure.PropertyName] += " " + failure.ErrorMessage;
                else extensions.Add(failure.PropertyName, failure.ErrorMessage);
            }
            problemDetails.Extensions.Add("invalid-params", extensions);
            return ValueTask.FromResult(problemDetails);
        }
    }
}
