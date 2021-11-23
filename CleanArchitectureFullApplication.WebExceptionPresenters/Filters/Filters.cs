using CleanArchitectureFullApplication.WebExceptionPresenters.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WebExceptionPresenters.Filters
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new WebExceptioniFilterAttribute(new ExceptionService()));
        }
    }
}
