using CleanArchitectureFullApplication.Main.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WebExceptionPresenters.ExceptionHandlers
{
    class UpdateExceptionHandler : IExceptionHandler<UpdateException>
    {
        public ValueTask<ProblemDetails> Handle(UpdateException exception)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Error de actualilzacion",
                Detail = exception.Message
            };
            Dictionary<string, string> extensions = new Dictionary<string, string>
            {
                {"entities", string.Join(",", exception.Entries) }
            };
            problemDetails.Extensions.Add("invalid-params", extensions);
            return ValueTask.FromResult(problemDetails);
        }
    }
}
