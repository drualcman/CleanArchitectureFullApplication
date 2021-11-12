using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Exceptions
{
    public class GeneralException : Exception
    {
        public string Detail { get; set; }
        public GeneralException() { }
        public GeneralException(string message) : base(message) { }
        public GeneralException(string message, Exception innerException) : 
            base(message, innerException) { }
        public GeneralException(string title, string detail) : base(title) => 
            Detail = detail;
    }
}
