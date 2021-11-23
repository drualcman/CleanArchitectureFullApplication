using CleanArchitectureFullApplication.WebExceptionPresenters.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WebExceptionPresenters.Filters
{
    public class WebExceptioniFilterAttribute : ExceptionFilterAttribute
    {
        readonly ExceptionService Service;

        public WebExceptioniFilterAttribute(ExceptionService service) => 
            Service = service;

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            ProblemDetails problemDetails = await Service.Handle(context.Exception);
            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };
            context.ExceptionHandled = true;
            await base.OnExceptionAsync(context);
        }
    }
}
