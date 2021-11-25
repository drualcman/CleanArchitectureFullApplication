using System;

namespace CleanArchitectureFullApplication.BlazorClient.Exceptions
{
    public class HttpCustomException : Exception
    {
        public ProblemDetails Problems { get; set; }

        public HttpCustomException() { }
        public HttpCustomException(string message) : base(message) { }
        public HttpCustomException(string message, Exception innerException) :
            base(message, innerException) { }

        public HttpCustomException(ProblemDetails problems):
            base(problems.Title)
        {
            Problems = problems;
        }
    }
}
