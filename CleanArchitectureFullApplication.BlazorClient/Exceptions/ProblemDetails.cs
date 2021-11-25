using System.Collections.Generic;

namespace CleanArchitectureFullApplication.BlazorClient.Exceptions
{
    public class ProblemDetails
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public int Status { get; set; }
        public IDictionary<string, string> InvalidParams { get; set; }
    }
}
