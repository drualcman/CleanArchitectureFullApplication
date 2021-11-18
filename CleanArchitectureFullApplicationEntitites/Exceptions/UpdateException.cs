using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Exceptions
{
    public class UpdateException : Exception
    {
        public IReadOnlyList<string> Entries { get; set; }

        public UpdateException() { }
        public UpdateException(string message) : base(message) { }
        public UpdateException(string message, Exception innerException) :
            base(message, innerException) { }
        public UpdateException(string message, IReadOnlyList<string> entries) : base(message)
            => Entries = entries;
        
    }
}
